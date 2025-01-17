﻿

using Invoices.Data.Models.Enums;

namespace Invoices.Data
{
    public static class DataConstraints
    {
        public const byte ProductNameMinLength = 9;
        public const byte ProductNameMaxLength = 30;
        public const string ProductPriceMinValue = "5.00";
        public const string ProductPriceMaxValue = "1000.00";
        public const int ProductCategoryTypeMinValue = (int)CategoryType.ADR;
        public const int ProductCategoryTypeMaxValue = (int)CategoryType.Tyres;

        public const byte AddressStreetNameMinLength = 10;
        public const byte AddressStreetNameMaxLength = 20;

        public const byte AddressCityMinLength = 5;
        public const byte AddressCityMaxLength = 15;

        public const byte AddressCountryMinLength = 5;
        public const byte AddressCountryMaxLength = 15;

        public const int InvoiceNumberMinValue = 1_000_000_000;
        public const int InvoiceNumberMaxValue = 1_500_000_000;
        public const int InvoiceCurrencyTypeMinValue = (int)CurrencyType.BGN;
        public const int InvoiceCurrencyTypeMaxValue = (int)CurrencyType.USD;

        public const byte ClientNameMinLength = 10;
        public const byte ClientNameMaxLength = 25;

        public const byte ClientNumberVatMinLength = 10;
        public const byte ClientNumberVatMaxLength = 15;


    }
}
