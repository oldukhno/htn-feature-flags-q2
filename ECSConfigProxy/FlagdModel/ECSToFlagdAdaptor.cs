﻿using ECSConfigProxy.ECS;
using Json.Logic;

namespace ECSConfigProxy.FlagdModel
{
    public sealed class ECSToFlagdAdaptor
    {
        public static FlagdFlag CreateFlag(ECSConfig config)
        {
            if (config == null || config.ConfigValues == null || config.ConfigValues.Count == 0)
            {
                throw new ArgumentException("config cannot be null nor empty");
            }

            // sort configuratin values by priority
            List<ConfigValue> configValues = config.ConfigValues.Values.OrderBy(x => x.Priority).ToList();

            var flag = new FlagdFlag { state = "ENABLED" };
            var variants = new Dictionary<string, object>();
            List<Rule> filterRules = new List<Rule>();

            foreach (var configVal in configValues)
            {
                if (configVal.AllocationPercentage < 100)
                {
                    continue;
                }

                variants.Add(configVal.IsDefault ? "default" : configVal.VariantName, configVal.Value);

                if (configVal.Filters != null && configVal.Filters.Count > 0)
                {
                    Filter firstFilter = configVal.Filters[0];
                    Rule firstRule = CreateStringRule(firstFilter);

                    if (configVal.Filters.Count == 1)
                    {
                        filterRules.Add(firstRule);
                    }
                    else
                    {
                        Rule[] restRules = new Rule[configVal.Filters.Count - 1];
                        for (int i = 1; i < configVal.Filters.Count; ++i)
                        {
                            restRules[i-1] = CreateStringRule(configVal.Filters[i]);
                        }

                        filterRules.Add(JsonLogic.And(firstRule, restRules));
                    }

                    filterRules.Add(configVal.VariantName);
                }
            }

            if (variants.Count == 0)
            {
                variants.Add("disabled", "null");
                flag.state = "DISABLED";
            }

            if (variants.ContainsKey("default"))
            {
                flag.defaultVariant = "default";
            }
            else
            {
                flag.defaultVariant = variants.Keys.First();
            }

            if (filterRules.Count > 0)
            {
                filterRules.Add(flag.defaultVariant);
                Rule evaluationRule = JsonLogic.If(filterRules.ToArray());
                flag.targeting = evaluationRule;
            }
            else
            {
                flag.targeting = null;
            }

            flag.variants = variants;

            return flag;
        }

        public static FlagdFlagSet CreateFlagsSetFromECS(IEnumerable<KeyValuePair<string, ECSConfig>> configs)
        {
            if (configs == null)
            {
                throw new ArgumentException("configs cannot be null or empty");
            }

            var dict = new Dictionary<string, FlagdFlag>();
            foreach (var config in configs)
            {
                dict.Add(config.Key, CreateFlag(config.Value));
            }

            return new FlagdFlagSet
            {
                flags = dict
            };
        }

        private static Rule CreateStringRule(Filter filter)
        {
            string condition = filter.value;
            if (condition.StartsWith("*") || condition.EndsWith("*"))
            {
                string substr = condition.Trim('*');
                return JsonLogic.In(substr, JsonLogic.Variable(filter.name));
            }
            else
            {
                return JsonLogic.StrictEquals(JsonLogic.Variable(filter.name), filter.value);
            }
        }
    }
}
