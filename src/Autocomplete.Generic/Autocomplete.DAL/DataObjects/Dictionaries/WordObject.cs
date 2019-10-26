using System;

namespace Autocomplete.DAL.DataObjects.Dictionaries
{
    [Serializable]
    public class WordObject : BaseObject
    {
        public string Word { get; set; } = string.Empty;
    }
}
