using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace TotalOnDemand.CampanhasOnline.Models
{
    public class AngeloPart : ContentPart<AngeloPartRecord>
    {
        public string IMDB_Id
        {
            get { return Record.IMDB_Id; }
            set { Record.IMDB_Id = value; }
        }

        public int YearReleased
        {
            get { return Record.YearReleased; }
            set { Record.YearReleased = value; }
        }

        public MPAARating Rating
        {
            get { return Record.Rating; }
            set { Record.Rating = value; }
        }
    }
}