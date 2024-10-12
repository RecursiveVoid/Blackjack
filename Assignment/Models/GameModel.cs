using Assignment.EventArguments;
using Assignment.Types;

namespace Assignment.Models
{
    public class GameModel: ModeModel
    {
        public GameModel() {
            Cards = [];
            Deck = [];
            PlayersHand = [];
            DealersHand = [];
        }
        private int GetCardSum(List<CardModel> cards)
        {
            return cards.Sum(cardModel => cardModel.Value);
        }

        public int GetPlayerSum()
        {
            return GetCardSum(PlayersHand);
        }

        public int GetDealerSum()
        {
            return GetCardSum(DealersHand);
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

        public event EventHandler<GameStatusChangedEventArgs>? OnStatusChange;

        private void _emitStatusChange()
        {
            var eventArgs = new GameStatusChangedEventArgs(_status);
            OnStatusChange?.Invoke(this, eventArgs);
        }
    }
}
