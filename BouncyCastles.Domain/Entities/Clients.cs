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
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
    }

}