using Assignment.EventArguments;
using Assignment.Models;
using Assignment.Types;
using Assignment.Utils;

namespace Assignment.Views
{
    public class GameView: ModeView
    {
        public GameView(GameModel model): base(model)
        {
            model.OnStatusChange += _handleChangeStatus;
        }

        private void _handleChangeStatus(object sender, GameStatusChangedEventArgs args)
        {
            
            var model = (GameModel)_model;
            switch (args.Status)
            {
                case GameStatus.HOLD:
                case GameStatus.START:
                    Console.Clear();
                    break;
                case GameStatus.PLAYER_TURN:
                    Console.Clear();
                    _showPlayerHand();
                    _showHitOrHoldText();
                    break;
                case GameStatus.HIT:
                    Console.Clear();
                    _showPlayerHand();
                    break;
                case GameStatus.PLAYER_BUST:
                    Console.Clear();
                    ConsoleWritter.WriteInRed("You BUST!");
                    break;
                case GameStatus.DEALER_BUST:
                    Console.Clear();
                    ConsoleWritter.WriteInGreen("Dealer BUST!");
                    break;
                case GameStatus.PLAYER_WIN:
                    ConsoleWritter.WriteInGreen("You Won!");
                    break;
                case GameStatus.PLAYER_LOSE:
                    ConsoleWritter.WriteInRed("You lose!");
                    break;
                case GameStatus.DRAW:
                    Console.Clear();
                    ConsoleWritter.WriteInYellow("It's a draw");
                    break;
                case GameStatus.END:
                    _showDealersHand();
                    _showPlayerHand();
                    _showRestartText();
                    break;
                case GameStatus.EXIT:
                    break;
            }
        }

        private void _showRestartText()
        {
            ConsoleWritter.WriteInGreen("Press 1 to Restart");
            ConsoleWritter.WriteInRed("Any other key to EXIT");
        }

        private void _showHitOrHoldText()
        {
            ConsoleWritter.WriteInGreen("Press 1 to Hit");
            ConsoleWritter.WriteInYellow("Press 2 to HOLD");
            ConsoleWritter.WriteInRed("Any other key to EXIT");
        }

        private void _showPlayerHand()
        {
            ConsoleWritter.WriteHeader("Your Hand");
            var model = (GameModel)_model;
            var playerHand = model.PlayersHand;
            _showHand(playerHand);
        }

        private void _showDealersHand()
        {
            ConsoleWritter.WriteHeader("Dealer's Hand");
            var model = (GameModel)_model;
            var dealersHand = model.DealersHand;
            _showHand(dealersHand);
        }

        private void _showHand(List<CardModel> hand)
        {
            hand.ForEach(cardModel => {
                var cardFace = cardModel.Face;
                var cardSuit = cardModel.Suit;
                Console.WriteLine($"{cardFace} of {cardSuit}");
            });
        }

        protected override void _show()
        {
            // throw new NotImplementedException();
        }

        protected override void _hide()
        {
           // throw new NotImplementedException();
        }
    }
}
