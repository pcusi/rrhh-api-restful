using System;

namespace rrhh_api_restful.Models
{
    public interface IIdIdentity<T> where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        T Id { get; set; }
    }
}