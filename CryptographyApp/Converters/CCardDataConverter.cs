using CryptographyApp.DTOs;
using CryptographyApp.Entities;
using System.ComponentModel;
using System.Globalization;

namespace CryptographyApp.Converters
{
    public class CCardDataConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return sourceType == typeof(EncryptInput) || base.CanConvertFrom(context, sourceType);
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            var casted = value as EncryptInput;

            return casted != null
                ? new CCardData(casted.UserDocument, casted.CreditCardToken, casted.Value)
                : base.ConvertFrom(context, culture, value);
        }
    }
}
