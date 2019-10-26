using System.Collections.Generic;

namespace Autocomplete.DAL.DataObjects.Dictionaries
{
    public interface IDictionary
    {
        public List<WordObject> Words { get; set; }
    }
}
