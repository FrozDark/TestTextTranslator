using System.Globalization;

namespace Models
{
    public class PhraseModel
    {
        public string? Language { get; set; }
        public Dictionary<string, string>? Translates { get; set; }
    }
}
