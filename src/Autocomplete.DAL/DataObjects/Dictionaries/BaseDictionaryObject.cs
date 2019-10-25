using System.Collections.Generic;

namespace Autocomplete.DAL.DataObjects.Dictionaries
{
    public class BaseDictionaryObject : IDictionary
    {
        public string FilePath { get; set; }

        public List<WordObject> Words { get; set; }
    }
}
