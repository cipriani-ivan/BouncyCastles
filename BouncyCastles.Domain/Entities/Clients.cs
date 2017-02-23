using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BouncyCastles.Domain.Entities
{

    [MetadataType(typeof(Clients))]
    public partial class Client
    {
    }

    public class Clients
    {

        public int ClientsID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Range(0, 999999999)]
        public int PhoneNumber { get; set; }
    }

}