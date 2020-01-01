// Copyright 2020 Maksym Liannoi
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
using Autocomplete.WindowUI.UI.BL.BusinessObjects;
using Autocomplete.WindowUI.UI.BL.BusinessServices;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;

namespace Autocomplete.WindowUI.UI.BL.ViewModels
{
    public sealed partial class DashboardViewModel : BaseViewModel
    {
        private readonly string buffer = string.Empty;
        private readonly int value;

        public string Buffer
        {
            get => Get(buffer);
            set => Set(value);
        }

        public int Value
        {
            get => Get(value);
            set => Set(value);
        }

        public ICommand ClearCommand => MakeCommand(a => ClearWindow(), c => !IsBufferEmpty());

        public ICommand SetSuggestionsCommand => MakeCommand(a => AsyncFindSuggestions());

        public DashboardViewModel()
        {
            russianWordsSuggestionService = new RussianWordsSuggestionService();
            FirstSuggestion = new SuggestionBusinessObject();
            SecondSuggestion = new SuggestionBusinessObject();
            ThirdSuggestion = new SuggestionBusinessObject();
            AsyncInitialize();
            AsyncIncrement();
            PropertyChanged += DashboardViewModel_PropertyChanged;
        }

        private void DashboardViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.ToUpperInvariant() == nameof(Buffer).ToUpperInvariant())
            {
                BufferPropertyChange();
            }
        }

        private void BufferPropertyChange()
        {
            ClearSugggestions();
            AsyncFindSuggestions();
        }

        private bool IncrementValue()
        {
            while (!asyncInitialize.IsCompleted)
            {
                Value++;
                Thread.Sleep(Consts.SleepWhenInitialize);
            }

            Value = 100;
            return true;
        }

        private bool IsBufferEmpty()
        {
            return Buffer.Length == 0;
        }

        private void ClearWindow()
        {
            Buffer = string.Empty;
            ClearSugggestions();
        }
    }
}
