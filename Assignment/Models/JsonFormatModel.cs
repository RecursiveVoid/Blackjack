namespace Assignment.Models
{
    // Actually, imagine this as an interface for the server response for the cards.

    public struct JsonCardFormat
    {
        public string suit { get; set; }
        public string face { get; set; }
        public int value { get; set; }
    }
    public struct JsonFormatModel
    {
        public List<JsonCardFormat> Card { get; set; }
    }
}
