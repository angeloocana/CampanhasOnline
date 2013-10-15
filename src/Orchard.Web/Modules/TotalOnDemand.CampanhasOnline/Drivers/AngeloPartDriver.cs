using TotalOnDemand.CampanhasOnline.Models;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement;

namespace TotalOnDemand.CampanhasOnline.Drivers
{
    public class AngeloPartDriver : ContentPartDriver<AngeloPart>
    {
        protected override DriverResult Display(
            AngeloPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_Product",
                () => shapeHelper.Parts_Product(
                    Sku: part.Sku,
                    Price: part.Price));
        }

        protected override string Prefix
        {
            get
            {
                return "Ângelo";
            }
        }

        //GET
        protected override DriverResult Editor(AngeloPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Angelo_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/Angelo",
                    Model: part,
                    Prefix: Prefix));
        }

        //POST
        protected override DriverResult Editor(
            AngeloPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}