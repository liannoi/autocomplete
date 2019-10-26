using Autocomplete.WindowUI.UI.BL.BusinessObjects;
using Autocomplete.WindowUI.UI.BL.BusinessServices;
using System.Windows.Input;

namespace Autocomplete.WindowUI.UI.BL.ViewModels
{
    public sealed partial class DashboardViewModel
    {
        private readonly RussianWordsSuggestionService russianWordsSuggestionService;

        public SuggestionBusinessObject FirstSuggestion { get; set; }
        
        public SuggestionBusinessObject SecondSuggestion { get; set; }
        
        public SuggestionBusinessObject ThirdSuggestion { get; set; }

        public ICommand FirstCorrectSuggestionCommand => MakeCommand(a => AsyncAddSuggestion(FirstSuggestion.Word));

        public ICommand SecondCorrectSuggestionCommand => MakeCommand(a => AsyncAddSuggestion(SecondSuggestion.Word));

        public ICommand ThirdCorrectSuggestionCommand => MakeCommand(a => AsyncAddSuggestion(ThirdSuggestion.Word));

        private void AddSuggestion(string str)
        {
            if(str == string.Empty)
            {
                return;
            }

            Buffer = $"{Buffer} {str}";
        }
    }
}
