using Azure.Identity;
using Azure.Storage.Blobs.Specialized;
using System.ComponentModel.DataAnnotations;

namespace QClient
{
    public class AccessSettings
    {
        [Required(ErrorMessage = nameof(TenantId) + " is required.")]
        public string TenantId { get; set; }
        
        [Required(ErrorMessage = nameof(ClientId) + " is required.")]
        public string ClientId { get; set; }

        [Required(ErrorMessage = nameof(ClientSecret) + " is required.")]
        public string ClientSecret { get; set; }

        [Required(ErrorMessage = nameof(ResourceUri) + " is required.")]
        public string ResourceUri { get; set; }

        [Required(ErrorMessage = nameof(EntitiesUri) + " is required.")]
        public string EntitiesUri { get; set; }
    }
}