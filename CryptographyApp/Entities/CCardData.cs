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

        public CCardData(long id, string userDocument, string creditCardToken, long value) : this(userDocument, creditCardToken, value)
        {
            Id = id;
        }

        public CCardData(string userDocument, string creditCardToken, long value) : this()
        {
            UserDocument = userDocument;
            CreditCardToken = creditCardToken;
            Value = value;
        }

        public string CreditCardToken { get; init; } = default!;
        public long Id { get; init; } = default!;
        public string UserDocument { get; init; } = default!;
        public long Value { get; init; } = default!;
    }
}