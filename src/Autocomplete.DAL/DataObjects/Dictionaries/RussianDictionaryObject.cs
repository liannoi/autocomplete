using System.Collections.Generic;

namespace Autocomplete.DAL.DataObjects.Dictionaries
{
    public class RussianDictionaryObject : IDictionary
    {
        public List<WordObject> Words { get; set; }
    }
}
