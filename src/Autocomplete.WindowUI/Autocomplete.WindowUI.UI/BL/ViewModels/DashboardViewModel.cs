using Autocomplete.WindowUI.UI.BL.BusinessObjects;
using Autocomplete.WindowUI.UI.BL.BusinessServices;
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
        }

        private bool IncrementValue()
        {
            while (!asyncInitialize.IsCompleted)
            {
                Value++;
                Thread.Sleep(500);
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
            FirstSuggestion.Word = null;
            SecondSuggestion.Word = null;
            ThirdSuggestion.Word = null;
        }
    }
}
