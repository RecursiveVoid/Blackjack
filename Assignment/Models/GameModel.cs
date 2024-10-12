using Assignment.EventArguments;
using Assignment.Types;

namespace Assignment.Models
{
    public class GameModel: ModeModel
    {
        public GameModel() {
            Cards = new List<CardModel>();
            Deck = new List<CardModel>();
            PlayersHand = new List<CardModel>();
            DealersHand = new List<CardModel>();
        }
        private int getCardSum(List<CardModel> cards)
        {
            return cards.Sum(cardModel => cardModel.Value);
        }

        public int getPlayerSum()
        {
            return getCardSum(PlayersHand);
        }

        public int getDealerSum()
        {
            return getCardSum(DealersHand);
        }

        public List<CardModel> Cards;

        public List<CardModel> Deck;

        public List<CardModel> PlayersHand;

        public List<CardModel> DealersHand;

        private GameStatus _status = GameStatus.INIT;

        public GameStatus Status
        {
            get => _status;

            set
            {
                _status = value;
                _emitStatusChange();
            }
        }

        public event EventHandler<GameStatusChangedEventArgs> OnStatusChange;

        private void _emitStatusChange()
        {
            var eventArgs = new GameStatusChangedEventArgs(_status);
            OnStatusChange?.Invoke(this, eventArgs);
        }
    }
}
