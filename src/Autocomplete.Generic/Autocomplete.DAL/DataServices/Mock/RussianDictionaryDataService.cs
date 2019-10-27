using System;

namespace Autocomplete.DAL.DataServices.Mock
{
    /// <summary>
    /// This class is needed only for creating dictionaries in binary format.
    /// He isn't inherited.
    /// </summary>
    public sealed class RussianDictionaryDataService : BaseRussianDictionary
    {
        public RussianDictionaryDataService()
        {
            throw new NotSupportedException("The logic of this class isn't described.");
        }
    }
}
