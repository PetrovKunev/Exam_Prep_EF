using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";


        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            var customersDto = (ImportCustomerDto[])serializer.Deserialize(new StringReader(xmlString));

            var customers = new List<Customer>();
            var customersFromDatabase = context.Customers.ToList(); // Fetch existing customers from the database

            foreach (var customerDto in customersDto)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDuplicate = false;

                
                foreach (var existingCustomer in customers)
                {
                    if (existingCustomer.FullName == customerDto.FullName || existingCustomer.Email == customerDto.Email || existingCustomer.PhoneNumber == customerDto.PhoneNumber)
                    {
                        sb.AppendLine(DuplicationDataMessage);
                        isDuplicate = true;
                        break;
                    }
                }

                if (isDuplicate)
                {
                    continue;
                }

                
                foreach (var existingCustomer in customersFromDatabase)
                {
                    if (existingCustomer.FullName == customerDto.FullName || existingCustomer.Email == customerDto.Email || existingCustomer.PhoneNumber == customerDto.PhoneNumber)
                    {
                        sb.AppendLine(DuplicationDataMessage);
                        isDuplicate = true;
                        break;
                    }
                }

                if (isDuplicate)
                {
                    continue;
                }

                var customer = new Customer
                {
                    FullName = customerDto.FullName,
                    Email = customerDto.Email,
                    PhoneNumber = customerDto.PhoneNumber
                };

                customers.Add(customer);
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var bookingsDto = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString);

            var bookings = new List<Booking>();

            foreach (var bookingDto in bookingsDto)
            {
                if (!IsValid(bookingDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime bookingDate;
                if (!DateTime.TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out bookingDate))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = context.Customers.FirstOrDefault(c => c.FullName == bookingDto.CustomerName);
                var tourPackage = context.TourPackages.FirstOrDefault(tp => tp.PackageName == bookingDto.TourPackageName);

                if (customer == null || tourPackage == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var booking = new Booking
                {
                    BookingDate = bookingDate,
                    CustomerId = customer.Id,
                    TourPackageId = tourPackage.Id
                };

                bookings.Add(booking);
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, tourPackage.PackageName, bookingDate.ToString("yyyy-MM-dd")));
            }

            context.Bookings.AddRange(bookings);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
