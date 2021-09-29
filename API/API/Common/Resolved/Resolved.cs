using API.Common;
using System;

namespace API.Common
{
    public abstract class Resolved
    {
        public IResolvedType Value { get; protected set; }

        public bool IsOk => Value.GetType() == typeof(Ok) || Value.GetType().BaseType == typeof(Ok);

        public bool IsErr => Value.GetType() == typeof(Err) || Value.GetType().BaseType == typeof(Err);

        public static Ok Ok() => new Ok();

        public static Ok<T> Ok<T>(T value) => new Ok<T>(value);

        public static Err<T> Err<T>(T value) => new Err<T>(value);
    }

    public class Resolved<ErrType> : Resolved
    {
        public T Match<T>(Func<T> Ok, Func<ErrType, T> Err)
        {
            if (IsOk)
            {
                return Ok();
            }
            else
            {
                var error = Value as Err<ErrType>;
                return Err(error.Value);
            }
        }

        public Resolved<T> Match<T>(Func<Resolved<T>> Ok, Func<ErrType, Resolved<T>> Err)
        {
            if (IsOk)
            {
                return Ok();
            }
            else
            {
                var error = Value as Err<ErrType>;
                return Err(error.Value);
            }
        }

        public void Match(Action Ok, Action<ErrType> Err)
        {
            if (IsOk)
            {
                Ok();
            }
            else
            {
                var error = Value as Err<ErrType>;
                Err(error.Value);
            }
        }

        public static implicit operator Resolved<ErrType>(Ok value)
        {
            return new Resolved<ErrType> { Value = value };
        }

        public static implicit operator Resolved<ErrType>(Err<ErrType> value)
        {
            return new Resolved<ErrType> { Value = value };
        }
    }

    public class Resolved<OkType, ErrType> : Resolved
    {
        public T Match<T>(Func<OkType, T> Ok, Func<ErrType, T> Err)
        {
            if (IsOk)
            {
                var ok = Value as Ok<OkType>;
                return Ok(ok.Value);
            }
            else
            {
                var error = Value as Err<ErrType>;
                return Err(error.Value);
            }
        }

        public Resolved<OkReturn, ErrReturn> Match<OkReturn, ErrReturn>(Func<OkType, Resolved<OkReturn, ErrReturn>> Ok, Func<ErrType, Resolved<OkReturn, ErrReturn>> Err)
        {
            if (IsOk)
            {
                var ok = Value as Ok<OkType>;
                return Ok(ok.Value);
            }
            else
            {
                var error = Value as Err<ErrType>;
                return Err(error.Value);
            }
        }

        public Resolved<ErrReturn> Match<ErrReturn>(Func<OkType, Resolved<ErrReturn>> Ok, Func<ErrType, Resolved<ErrReturn>> Err)
        {
            if (IsOk)
            {
                var ok = Value as Ok<OkType>;
                return Ok(ok.Value);
            }
            else
            {
                var error = Value as Err<ErrType>;
                return Err(error.Value);
            }
        }

        public void Match(Action<OkType> Ok, Action<ErrType> Err)
        {
            if (IsOk)
            {
                var ok = Value as Ok<OkType>;
                Ok(ok.Value);
            }
            else
            {
                var error = Value as Err<ErrType>;
                Err(error.Value);
            }
        }

        public static implicit operator Resolved<OkType, ErrType>(Ok<OkType> value)
        {
            return new Resolved<OkType, ErrType> { Value = value };
        }

        public static implicit operator Resolved<OkType, ErrType>(Err<ErrType> value)
        {
            return new Resolved<OkType, ErrType> { Value = value };
        }
    }

    public interface IResolvedType { }
}
