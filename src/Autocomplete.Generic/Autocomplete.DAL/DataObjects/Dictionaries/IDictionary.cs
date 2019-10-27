using System.Collections.Generic;

namespace Autocomplete.DAL.DataObjects.Dictionaries
{
    public interface IDictionary
    {
        public IEnumerable<WordObject> Words { get; }
    }
}
