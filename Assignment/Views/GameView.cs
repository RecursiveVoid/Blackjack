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
            switch (args.status)
            {
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
                case GameStatus.HOLD:
                    Console.Clear();
                    break;
                case GameStatus.PLAYER_BUST:
                    Console.Clear();
                    _showPlayerLoseText();
                    _showDealersHand();
                    _showPlayerHand();
                    break;
                case GameStatus.DEALER_BUST:
                    Console.Clear();
                    _showPlayerWinText();
                    _showDealersHand();
                    _showPlayerHand();
                    break;
                case GameStatus.DRAW:
                    Console.Clear();
                    _showDrawText();
                    _showDealersHand();
                    _showPlayerHand();
                    break;
                case GameStatus.END:
                    _showRestartText();
                    break;
                case GameStatus.EXIT:
                    break;
            }
        }

        private void _showPlayerWinText()
        {
            ConsoleWritter.WriteHeader("Congratulations! YOU WIN!");
        }

        private void _showPlayerLoseText()
        {
            ConsoleWritter.WriteHeader("You Lose");
        }

        private void _showDrawText()
        {
            ConsoleWritter.WriteHeader("It's a draw");
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
