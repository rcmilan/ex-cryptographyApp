namespace CryptographyApp.DTOs
{
    public class EncryptOutput
    {
        public string CreditCardToken { get; set; } = default!;
        public long Id { get; set; }
        public string UserDocument { get; set; } = default!;
        public long Value { get; set; }
    }
}