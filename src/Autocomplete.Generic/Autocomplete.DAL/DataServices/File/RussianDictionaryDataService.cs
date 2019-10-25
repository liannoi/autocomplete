using Autocomplete.DAL.DataObjects.Dictionaries;
using Autocomplete.DAL.Helpers;

namespace Autocomplete.DAL.DataServices.File
{
    public class RussianDictionaryDataService : BaseRussianDictionary
    {
        public RussianDictionaryDataService()
        {
            Deserialize();
        }

        private void Deserialize()
        {
            Dictionary = BinarySerializationDictionary.Deserialize<RussianDictionaryObject>(Consts.RussianDictionaryFilePath);
        }
    }
}
