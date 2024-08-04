using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [XmlAttribute("phoneNumber")]
        [Required]
        [RegularExpression(@"^\+\d{12}$")]
        public string PhoneNumber { get; set; }

        [XmlElement("FullName")]
        [Required]
        [StringLength(60, MinimumLength = 4)]
        public string FullName { get; set; }

        [XmlElement("Email")]
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Email { get; set; }

    }
}
