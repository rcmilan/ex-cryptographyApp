namespace CryptographyApp.DTOs
{
    public class EncryptInput
    {
        public string CreditCardToken { get; set; }
        public string UserDocument { get; set; }
        public long Value { get; set; }
    }
}