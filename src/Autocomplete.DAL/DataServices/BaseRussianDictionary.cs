using Autocomplete.DAL.DataObjects.Dictionaries;

namespace Autocomplete.DAL.DataServices
{
    public abstract class BaseRussianDictionary
    {
        public RussianDictionaryObject Dictionary { get; protected set; }
    }
}