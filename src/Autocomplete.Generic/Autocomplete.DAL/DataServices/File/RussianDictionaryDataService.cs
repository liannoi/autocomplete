using Autocomplete.DAL.DataObjects;
using Autocomplete.DAL.DataObjects.Dictionaries;
using Autocomplete.DAL.Helpers;
using System;
using System.Collections.Generic;

namespace Autocomplete.DAL.DataServices.File
{
    public class RussianDictionaryDataService : BaseRussianDictionary
    {
        public RussianDictionaryDataService()
        {
            Deserialize();
        }

        public List<WordObject> FindAll()
        {
            // TODO: Implement.
            throw new NotImplementedException("This method has not yet been implemented.");
        }

        public WordObject Find()
        {
            // TODO: Implement.
            throw new NotImplementedException("This method has not yet been implemented.");
        }

        private void Deserialize()
        {
            Dictionary = BinarySerializationDictionary.Deserialize<RussianDictionaryObject>(Consts.RussianDictionaryFilePath);
        }
    }
}
