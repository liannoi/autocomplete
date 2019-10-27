// Copyright 2019 Maksym Liannoi
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
