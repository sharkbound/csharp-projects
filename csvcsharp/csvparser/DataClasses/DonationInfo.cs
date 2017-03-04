using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace csvparser.DataClasses
{
    [DelimitedRecord(","), IgnoreEmptyLines(), IgnoreFirst()]
    public class PaypalInfo
    {
        
        public string Date;
        public string Time;
        public string TimeZone;
        public string Desc;
        public string Currency;
        [FieldQuoted('"')]
        public double Gross;
        [FieldQuoted('"')]
        public string Fee;
        [FieldQuoted('"')]
        public string Net;
        [FieldQuoted('"')]
        public string Balance;
        public string TransactionId;
        public string SenderEmail;
        [FieldQuoted('"')]
        public string OrganizationName;
        public string Name;
        public string BankName;
        public string BankAccount;
        [FieldQuoted('"')]
        public double ShippingAndHandlingAmount;
        [FieldQuoted('"')]
        [FieldNullValue(typeof(double), "0.00")]
        public double SalesTax;
        [FieldOptional]
        public string InvoiceId;
        [FieldOptional]
        public string ReferenceTxnId;
    }
}
