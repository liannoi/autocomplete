using Autocomplete.DAL.Helpers;

namespace Autocomplete.DAL.DataServices.Mock
{
    public class RussianDictionaryDataService : BaseRussianDictionary
    {
        public RussianDictionaryDataService()
        {
            InitializeDictionary();
            Serialize();
        }

        private void Serialize()
        {
            Dictionary.Serialize();
        }

        private void InitializeDictionary()
        {
            Dictionary.AddRange(FileOperation.ReadByLine(Consts.ResourceRussainDictionaryFilePath));
        }
    }
}
