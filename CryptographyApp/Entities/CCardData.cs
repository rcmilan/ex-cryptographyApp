using CryptographyApp.Converters;
using System.ComponentModel;

namespace CryptographyApp.Entities
{
    [TypeConverter(typeof(CCardDataConverter))]
    public class CCardData
    {
        public CCardData()
        {

        }

        public CCardData(string userDocument, string creditCardToken, long value) : this()
        {
            UserDocument = userDocument;
            CreditCardToken = creditCardToken;
            Value = value;
        }

        public string CreditCardToken { get; set; }
        public long Id { get; set; }
        public string UserDocument { get; set; }
        public long Value { get; set; }
    }
}