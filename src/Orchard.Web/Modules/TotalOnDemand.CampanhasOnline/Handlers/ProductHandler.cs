using Orchard.ContentManagement.Handlers;
using TotalOnDemand.CampanhasOnline.Models;
using Orchard.Data;

namespace TotalOnDemand.CampanhasOnline.Handlers
{
    public class ProductHandler : ContentHandler {
        public ProductHandler(IRepository<ProductPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}