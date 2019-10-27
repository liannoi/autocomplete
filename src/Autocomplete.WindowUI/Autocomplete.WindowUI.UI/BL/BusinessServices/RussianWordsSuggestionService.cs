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

using Autocomplete.DAL;
using Autocomplete.DAL.DataObjects.Dictionaries;
using Autocomplete.DAL.DataServices;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete.WindowUI.UI.BL.BusinessServices
{
    public sealed class RussianWordsSuggestionService
    {
        public List<string> Suggestions { get; private set; }

        public RussianWordsSuggestionService()
        {
            Suggestions = new List<string>();
        }

        public void Find(string buffer, int count)
        {
            Suggestions.ToList().Clear();

            IEnumerable<WordObject> collection = DataServices
                .RussianDictionary
                .Dictionary
                .Words
                .ToList()
                .FindAll(w => w.Word.ToUpperInvariant().Contains(buffer.ToUpperInvariant()) || w.Word.ToUpperInvariant() == buffer.ToUpperInvariant())
                .Take(count);

            foreach (WordObject item in collection)
            {
                Suggestions.Add(item.Word);
            }
        }

        public void Find(string buffer)
        {
            Find(buffer, Consts.CountSuggestions);
        }
    }
}
