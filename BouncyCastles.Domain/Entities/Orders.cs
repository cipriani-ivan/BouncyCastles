using BouncyCastles.WebUI.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BouncyCastles.Domain.Entities
{

    [MetadataType(typeof(Orders))]
    public partial class Order
    {
    }

    public class Orders
    {

        public int OrdersID { get; set; }
        public int CastlesID { get; set; }
        public int ClientsID { get; set; }
        [Required]
        public string AdrStreet { get; set; }
        [Required]
        public string AdrZipCode { get; set; }
        [Required]
        public string AdrCity { get; set; }
        [Required]
        public string AdrRegion { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage="Please enter a date in the future")]
        //[NumericLessThanAttribute("EndDay", AllowEquality = true)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime StartDay { get; set; }
        [Required]
        [NumericGreaterThan("StartDay", AllowEquality = true)]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime EndDay { get; set; }
    }

}