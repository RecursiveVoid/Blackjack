using Assignment.Types;

namespace Assignment.Interfaces
{
    public interface ICardModel
    {
        SuitType Suit { get; set; }
        FaceType Face { get; set; }
        int Value { get; set; }
    }
}
