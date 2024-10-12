using Assignment.Interfaces;
using Assignment.Types;

namespace Assignment.Models
{
    public struct CardModel: ICardModel
    {
        public SuitType Suit { get; set; }
        public FaceType Face { get; set; } 
        public int Value { get; set; }

        public CardModel(ICardModel options) { 
            Suit = options.Suit;
            Face = options.Face;
            Value = options.Value;
        }

    }
}
