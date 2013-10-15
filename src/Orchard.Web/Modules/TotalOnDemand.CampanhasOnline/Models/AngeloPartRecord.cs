using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace TotalOnDemand.CampanhasOnline.Models
{
    public class AngeloPartRecord : ContentPartRecord
    {
        public virtual string IMDB_Id { get; set; }
        public virtual int YearReleased { get; set; }
        public virtual MPAARating Rating { get; set; }
    }
}