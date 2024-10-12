using Assignment.EventArguments;
using Assignment.Extractors;
using Assignment.Models;
using Assignment.Types;
using Assignment.Views;

namespace Assignment.Controllers
{
    public class GameController : ModeController
    {
        private int  CARD_VALUE_LIMIT = 21;
        public GameController(GameModel model, GameView view) : base(model, view)
        {
            var cardExtractor = new CardExtractor();
            model.Cards = cardExtractor.Extract();
            model.OnStatusChange += _handleChangeStatus;
        }

        private void _handleChangeStatus(object? sender, GameStatusChangedEventArgs args) { 
            var model = (GameModel)_model;
            switch(args.Status)
            {
                case GameStatus.START:
                    _prepareHands();
                    _shuffleDeck();
                    model.Status = GameStatus.HIT;
                break;
                case GameStatus.PLAYER_TURN:
                    _checkPlayerTurnInput();
                    break;
                case GameStatus.HIT:
                    _dealCardToPlayer();
                    _dealCardToDealer();
                    _checkExceeds();
                    break;
                case GameStatus.HOLD:
                    _checkWin();
                    break;
                case GameStatus.PLAYER_BUST:
                    model.Status = GameStatus.PLAYER_LOSE;
                    break;
                case GameStatus.DEALER_BUST:
                    model.Status = GameStatus.PLAYER_WIN;
                    break;
                case GameStatus.PLAYER_WIN:
                case GameStatus.PLAYER_LOSE:
                case GameStatus.DRAW:
                    model.Status = GameStatus.END;
                    break;
                case GameStatus.END:
                    _checkEndInput();
                    break;
                case GameStatus.EXIT:
                    break;
            }
        }

        private void _checkWin()
        {
            var model = (GameModel)_model;
            var playerSum = model.GetPlayerSum();
            var dealerSum = model.GetDealerSum();
            if (playerSum == dealerSum)
            {
                model.Status = GameStatus.DRAW;
                return;
            }
            if (playerSum > dealerSum)
            {
                model.Status = GameStatus.PLAYER_WIN;
                return;
            }
            if (dealerSum > playerSum)
            {
                model.Status = GameStatus.PLAYER_LOSE;
                return;
            }
        }


        private void _checkExceeds()
        {
            var model = (GameModel)_model;
            var playerSum = model.GetPlayerSum();
            var dealerSum = model.GetDealerSum();
            var isPLayerExceedsLimit = playerSum > CARD_VALUE_LIMIT;
            var isDealerExceedsLimit = dealerSum > CARD_VALUE_LIMIT;
            if (isPLayerExceedsLimit && isDealerExceedsLimit)
            {
                model.Status = GameStatus.DRAW;
                return;
            }
            if (isPLayerExceedsLimit)
            {
                model.Status = GameStatus.PLAYER_BUST;
                return;
            }
            if(isDealerExceedsLimit)
            {
                model.Status= GameStatus.DEALER_BUST;
                return;
            }
            model.Status = GameStatus.PLAYER_TURN;
        }

        private void _prepareHands()
        {
            var model = (GameModel)_model;
            model.PlayersHand = [];
            model.DealersHand = [];
        }


        private void _checkEndInput()
        {
            var model = (GameModel)_model;
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                model.Status = GameStatus.START;
            }
            else
            {
                model.Status = GameStatus.EXIT;
            }
        }

        private void _checkPlayerTurnInput()
        {
            var model = (GameModel)_model;
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                model.Status = GameStatus.HIT;
            }
            else if ((key.Key == ConsoleKey.D2)) 
            {
                model.Status = GameStatus.HOLD;
            } else
            {
                model.Status = GameStatus.EXIT;
            }
        }

        private void _shuffleDeck()
        {
            var random = new Random();
            var gameModel = (GameModel)_model;
            gameModel.Deck = gameModel.Cards.OrderBy(cardModel => random.Next()).ToList();
        }

        private void _dealCardToPlayer() {
            var gameModel = (GameModel)_model;
            _dealCardTo(gameModel.PlayersHand);
        }

        private void _dealCardToDealer()
        {
            var gameModel =(GameModel)_model;
            _dealCardTo(gameModel.DealersHand);
        }

        private void _dealCardTo(List<CardModel> hand)
        {
            var gameModel = (GameModel)_model;
            var deck = gameModel.Deck;
            var topCard = deck.FirstOrDefault();
            hand.Add(topCard);
            deck.RemoveAt(0);
        }


        public override void Start()
        {
            _setStatusToStart();
        }

        private void _setStatusToStart()
        {
            var gameModel = (GameModel)_model ;
            gameModel.Status = GameStatus.START;
        }

        public override void Stop()
        {

        } 
    }
}
