namespace Misaki.DependencyInjection
{
    public interface IOptions<out T> where T : class
    {
        public T Value
        {
            get;
        }
    }
}