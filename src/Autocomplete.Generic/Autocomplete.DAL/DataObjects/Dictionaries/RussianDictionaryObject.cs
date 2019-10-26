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
            Add(word.Word);
        }

        public void Add(string word)
        {
            Words.Add(new WordObject
            {
                Id = LastId,
                Word = word
            });
        }

        public void AddRange(params WordObject[] words)
        {
            Words.AddRange(words);
        }

        public void AddRange(IEnumerable<string> words)
        {
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
