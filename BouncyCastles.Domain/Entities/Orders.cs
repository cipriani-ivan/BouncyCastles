using BouncyCastles.WebUI.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

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
        [MaxLength(50)]
        [DisplayName("Address")]
        public string AdrStreet { get; set; }
        [Required]
        [RegexFromConfigValidator]
        [DisplayName("Zip Code")]
        public string AdrZipCode { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("City")]
        public string AdrCity { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Region")]
        public string AdrRegion { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage="Please enter a date in the future")]
        [DisplayName("Start Day")]
        public System.DateTime StartDay { get; set; }
        [Required]
        [NumericGreaterThan("StartDay", AllowEquality = true)]
        [DataType(DataType.Date)]
        [DisplayName("End Day")]
        public System.DateTime EndDay { get; set; }
    }
}