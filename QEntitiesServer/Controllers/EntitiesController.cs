using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenFeature.Contrib.Providers.Flagd;
using OpenFeature.Model;

namespace QEntitiesServer.Controllers;

[Authorize]
[Route("/")]
public class EntitiesController : Controller
{
    private readonly OpenFeature.FeatureClient _featureClient;

    public EntitiesController()
    {
        var flagdProvider = new FlagdProvider();
        OpenFeature.Api.Instance.SetProvider(flagdProvider);
        _featureClient = OpenFeature.Api.Instance.GetClient(nameof(EntitiesController));
    }

    [HttpGet]
    public async Task<ActionResult> GetEntities(string mapName)
    {
        var context = EvaluationContext.Builder().Set("UserId", mapName).Build();
        string monstersPositionVersion = await _featureClient.GetStringValue(Features.CorrectMonsterPosition, "none", context).ConfigureAwait(false);
        Console.WriteLine($"Read {Features.CorrectMonsterPosition} as {monstersPositionVersion}");

        string entitiesPath;

        switch (monstersPositionVersion)
        {
            case "v1":
                entitiesPath = Path.Combine("Entities", "Entities2.info");
                break;
            case "v2":
                entitiesPath = Path.Combine("Entities", "Entities1.info");
                break;
            default:
                entitiesPath = Path.Combine("Entities", "Entities_NoMonsters.info");
                break;
        }

        string entities = await System.IO.File.ReadAllTextAsync(entitiesPath);

        return Content(entities);
    }
}