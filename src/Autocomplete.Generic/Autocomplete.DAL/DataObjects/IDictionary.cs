using System.Collections.Generic;

namespace Autocomplete.DAL.DataObjects
{
    public interface IDictionary
    {
        public List<WordObject> Words { get; set; }
    }
}
