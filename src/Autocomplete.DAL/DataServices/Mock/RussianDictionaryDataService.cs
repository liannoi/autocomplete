using Autocomplete.DAL.DataObjects.Dictionaries;
using Autocomplete.DAL.Helpers;

namespace Autocomplete.DAL.DataServices.Mock
{
    public class RussianDictionaryDataService : BaseRussianDictionary
    {
        public RussianDictionaryDataService()
        {
            Serialize();
        }

        private void Serialize()
        {
            Dictionary.Serialize();
        }
    }
}
