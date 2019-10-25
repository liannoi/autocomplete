using Autocomplete.DAL.DataObjects;
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
            DataServices.Initialize(false);
            Suggestions = new List<string>();
        }

        public void Find(string buffer, int count = 3)
        {
            Clear();

            IEnumerable<WordObject> collection = DataServices
                .BaseRussianDictionary
                .Dictionary
                .Words
                .FindAll(w => w.Word.ToLowerInvariant().Contains(buffer.ToLowerInvariant()))
                .Take(count);

            foreach (WordObject item in collection)
            {
                Suggestions.Add(item.Word);
            }
        }

        public void Clear()
        {
            Suggestions.Clear();
        }
    }
}
