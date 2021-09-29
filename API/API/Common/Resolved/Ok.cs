namespace API.Common
{
    public class Ok : IResolvedType { }

    public class Ok<T> : Ok
    {
        public Ok(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
    }
}

