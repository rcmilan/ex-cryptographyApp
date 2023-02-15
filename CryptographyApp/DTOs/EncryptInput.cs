using CryptographyApp.Mapper.CryptographyAttributes;

namespace CryptographyApp.DTOs
{
    public class EncryptInput
    {
        [SensitiveInfo]
        public string CreditCardToken { get; set; }

        [SensitiveInfo]
        public string UserDocument { get; set; }

        public long Value { get; set; }
    }
}