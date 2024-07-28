


namespace Invoices.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstraints;
    public class ImportInvoiceDto
    {
        [Required]
        [Range(InvoiceNumberMinValue, InvoiceNumberMaxValue)]
        public int Number { get; set; }

        [Required]
        public string IssueDate { get; set; }
        [Required]
        public string DueDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [Range(InvoiceCurrencyTypeMinValue, InvoiceCurrencyTypeMaxValue)]
        public int CurrencyType { get; set; }

        [Required]
        public int ClientId { get; set; }
    }
}
