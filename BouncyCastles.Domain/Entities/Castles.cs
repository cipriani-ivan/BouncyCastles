using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BouncyCastles.Domain.Entities
{

    [MetadataType(typeof(Castles))]
    public partial class Castle
    {
        public bool CheckBoxValue { get; set; }
    }

    public class Castles
    {
        public int CastlesID { get; set; }
        [Required]
        public string Type { get; set; }
        public int MaxCapacity { get; set; }
        public int NumStock { get; set; }
        public int PriceForDay { get; set; }
    }

}
