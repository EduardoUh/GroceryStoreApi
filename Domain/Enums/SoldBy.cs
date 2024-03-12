using System.Runtime.Serialization;

namespace Domain.Enums
{
    public enum SoldBy
    {
        [EnumMember(Value = "Piece")]
        Piece,
        [EnumMember(Value = "Kilogram")]
        Kilogram
    }
}
