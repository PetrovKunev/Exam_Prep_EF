

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Data.Models
{
    public class TourPackageGuide
    {
       
        [Required]
        [ForeignKey(nameof(TourPackage))]
        public int TourPackageId { get; set; }

        [Required]
        public TourPackage TourPackage { get; set; } = null!;

       
        [Required]
        [ForeignKey(nameof(Guide))]
        public int GuideId { get; set; }

        [Required]
        public Guide Guide { get; set; } = null!;
    }
}
