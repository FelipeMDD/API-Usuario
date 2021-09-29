namespace API.Common
{
    public abstract class Err : IResolvedType { }

    public class Err<T> : Err
    {
        public Err(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
    }
}