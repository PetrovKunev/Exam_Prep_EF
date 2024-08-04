using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DataProcessor.ImportDtos
{
    public class ImportBookingDto
    {
        [Required]
        public string BookingDate { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string TourPackageName { get; set; }
    }
}
