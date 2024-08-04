

namespace TravelAgency.DataProcessor.ExportDtos
{
    public class ExportCustomerDto
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public List<ExportBookingDto> Bookings { get; set; }
    }
}
