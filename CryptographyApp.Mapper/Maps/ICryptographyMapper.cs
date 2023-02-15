namespace CryptographyApp.Mapper.Maps
{
    public interface ICryptographyMapper
    {
        public TResult Map<TSource, TResult>(in TSource source)
            where TResult : class
            where TSource : class;
    }
}