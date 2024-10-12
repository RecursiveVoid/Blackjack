using Assignment.Models;
using Assignment.Types;
using System.Text.Json;

namespace Assignment.Extractors
{
    public class CardExtractor
    {
       private string _extractFromJson(string path) {
            if (!File.Exists(path)) {
                return "";
            }
            return File.ReadAllText(path);
        }

        public List<CardModel> Extract() {
            // I hard coded the path, its super bad practice but, for the static assignment json i do it anyways.
            // If this won't work, please include Data/TecnicalTaskCards.json in debug/bin, on release, Release/bin.
            var path = Path.Combine(AppContext.BaseDirectory, "Data", "TechnicalTaskCards.json");
            var jsonString = _extractFromJson(path);
            if (string.IsNullOrEmpty(jsonString)) { 
                return [];
            }
            try {
                var deserilizedJson = JsonSerializer.Deserialize<JsonFormatModel>(jsonString);
                if(deserilizedJson.Card == null)
                {
                    return [];
                }
                return _convertToCardModels(deserilizedJson.Card);
            }
            catch(JsonException ex) {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                return [];
            }
        }

        private List<CardModel> _convertToCardModels(List<JsonCardFormat> jsonCardFormats)
        {
            var cardModels = new List<CardModel>();
            jsonCardFormats.ForEach(jsonCardFormat =>
            {
                cardModels.Add(new CardModel
                {
                    Suit = _convertSuitType(jsonCardFormat.suit),
                    Face = _convertFaceType(jsonCardFormat.face),
                    Value = jsonCardFormat.value
                });
            });
            return cardModels;
        }

        // https://stackoverflow.com/questions/3334138/combine-return-and-switch-in-c-sharp
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
        // I could also map it in a dictionary with the key as the enum number and the string itself but it would be hard to read.
        private SuitType _convertSuitType(string suit)
        {
            return suit.ToLower() switch
            {
                "hearts" => SuitType.HEARTS,
                "diamonds" => SuitType.DIAMONDS,
                "clubs" => SuitType.CLUBS,
                "spades" => SuitType.SPADES,
                _ => throw new ArgumentException($"Invalid suit: {suit}")
            };
        }

        private FaceType _convertFaceType(string face)
        {
            return face.ToLower() switch
            {
                "2" => FaceType.TWO,
                "3" => FaceType.THREE,
                "4" => FaceType.FOUR,
                "5" => FaceType.FIVE,
                "6" => FaceType.SIX,
                "7" => FaceType.SEVEN,
                "8" => FaceType.EIGHT,
                "9" => FaceType.NINE,
                "10" => FaceType.TEN,
                "jack" => FaceType.JACK,
                "queen" => FaceType.QUEEN,
                "king" => FaceType.KING,
                "ace" => FaceType.ACE,
                _ => throw new ArgumentException($"Invalid face: {face}")
            };
        }
    }
}
