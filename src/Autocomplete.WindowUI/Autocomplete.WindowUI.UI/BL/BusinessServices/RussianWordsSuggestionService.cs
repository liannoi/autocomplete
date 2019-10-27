using Autocomplete.DAL;
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

        public void Find(string buffer, int count)
        {
            Suggestions.ToList().Clear();

            IEnumerable<WordObject> collection = DataServices
                .RussianDictionary
                .Dictionary
                .Words
                .ToList()
                .FindAll(w => w.Word.ToUpperInvariant().Contains(buffer.ToUpperInvariant()) || w.Word.ToUpperInvariant() == buffer.ToUpperInvariant())
                .Take(count);

            foreach (WordObject item in collection)
            {
                Suggestions.Add(item.Word);
            }
        }

        public void Find(string buffer)
        {
            Find(buffer, Consts.CountSuggestions);
        }
    }
}
