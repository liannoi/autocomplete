using Autocomplete.DAL.DataObjects.Dictionaries;
using Autocomplete.DAL.DataServices;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete.WindowUI.UI.BL.BusinessServices
{
    public sealed class RussianWordsSuggestionService
    {
        public List<string> Suggestions { get; private set; }

        public RussianWordsSuggestionService()
        {
            Suggestions = new List<string>();
        }

        public void Find(string buffer, int count = 3)
        {
            Suggestions.Clear();

            IEnumerable<WordObject> collection = DataServices
                .RussianDictionary
                .Dictionary
                .Words
                .FindAll(w => w.Word.ToLowerInvariant().Contains(buffer.ToLowerInvariant()) || w.Word.ToLowerInvariant() == buffer.ToLowerInvariant())
                .Take(count);

            foreach (WordObject item in collection)
            {
                Suggestions.Add(item.Word);
            }
        }
    }
}
