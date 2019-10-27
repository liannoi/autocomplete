using Autocomplete.DAL.DataObjects.Dictionaries;

namespace Autocomplete.DAL.DataServices
{
    public class BaseRussianDictionary
    {
        public RussianDictionaryObject Dictionary { get; protected set; }

        protected BaseRussianDictionary()
        {
            Dictionary = new RussianDictionaryObject();
        }
    }
}
