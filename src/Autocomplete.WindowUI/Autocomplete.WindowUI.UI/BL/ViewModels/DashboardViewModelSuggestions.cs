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

using Autocomplete.WindowUI.UI.BL.BusinessObjects;
using Autocomplete.WindowUI.UI.BL.BusinessServices;
using Autocomplete.WindowUI.UI.Helpers;
using System.Windows.Input;

namespace Autocomplete.WindowUI.UI.BL.ViewModels
{
    public sealed partial class DashboardViewModel
    {
        private readonly RussianWordsSuggestionService russianWordsSuggestionService;

        public SuggestionBusinessObject FirstSuggestion { get; set; }

        public SuggestionBusinessObject SecondSuggestion { get; set; }

        public SuggestionBusinessObject ThirdSuggestion { get; set; }

        public ICommand FirstCorrectSuggestionCommand => MakeCommand(a => AddCorrectSuggestion(FirstSuggestion.Word));

        public ICommand SecondCorrectSuggestionCommand => MakeCommand(a => AddCorrectSuggestion(SecondSuggestion.Word));

        public ICommand ThirdCorrectSuggestionCommand => MakeCommand(a => AddCorrectSuggestion(ThirdSuggestion.Word));

        private void AddSuggestion(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return;
            }

            Buffer = StringOperation.ReplaceLastOccurrence(Buffer, StringOperation.LastWord(Buffer), str);
        }

        private void ClearSugggestions()
        {
            FirstSuggestion.Word = null;
            SecondSuggestion.Word = null;
            ThirdSuggestion.Word = null;
        }

        private void AddCorrectSuggestion(string str)
        {
            AsyncAddSuggestion(str);
            ClearSugggestions();
        }
    }
}
