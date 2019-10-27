using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete.DAL.DataObjects.Dictionaries
{
    [Serializable]
    public class RussianDictionaryObject : BaseDictionaryObject
    {
        public RussianDictionaryObject()
        {
            FilePath = Consts.RussianDictionaryFilePath;
            Words = new List<WordObject>();
        }

        public void Add(WordObject word)
        {
            if (word is null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            Add(word.Word);
        }

        public void Add(string word)
        {
            Words
                .ToList()
                .Add(new WordObject
                {
                    Id = LastId,
                    Word = word
                });
        }

        public void AddRange(params WordObject[] words)
        {
            Words
                .ToList()
                .AddRange(words);
        }

        public void AddRange(IEnumerable<string> words)
        {
            if (words is null)
            {
                throw new ArgumentNullException(nameof(words));
            }

            foreach (string word in words)
            {
                Add(word);
            }
        }

        public void Distinct()
        {
            Words = Words
                .Distinct()
                .ToList();
        }
    }
}
