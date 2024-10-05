namespace Misaki.DependencyInjection
{
    internal class Options<T> : IOptions<T> where T : class
    {
        public T Value
        {
            get;
        }

        public Options(T value)
        {
            Value = value;
        }
    }
}