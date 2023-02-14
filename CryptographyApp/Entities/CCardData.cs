using CryptographyApp.Converters;
using System.ComponentModel;

namespace CryptographyApp.Entities
{
    [TypeConverter(typeof(CCardDataConverter))]
    public class CCardData
    {
        public CCardData(long id, string userDocument, string creditCardToken, long value) : this(userDocument, creditCardToken, value)
        {
            Id = id;
        }

        public CCardData(string userDocument, string creditCardToken, long value)
        {
            UserDocument = userDocument;
            CreditCardToken = creditCardToken;
            Value = value;
        }

        public string CreditCardToken { get; private set; }
        public long Id { get; private set; }
        public string UserDocument { get; private set; }
        public long Value { get; private set; }
    }
}