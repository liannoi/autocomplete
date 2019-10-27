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
