using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete.DAL.DataObjects.Dictionaries
{
    [Serializable]
    public class BaseDictionaryObject : IDictionary
    {
        public string FilePath { get; protected set; }

        public List<WordObject> Words { get; set; }

        public int LastId
        {
            get
            {
                int id;
                try
                {
                    id = Words.Max(w => w.Id) + 1;
                }
                catch (InvalidOperationException)
                {
                    id = 1;
                }

                return id;
            }
        }
    }
}
