using Autocomplete.WindowUI.UI.BL.BusinessObjects;
using Autocomplete.WindowUI.UI.BL.BusinessServices;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Windows.Input;

namespace Autocomplete.WindowUI.UI.BL.ViewModels
{
    public sealed class DashboardViewModel : BaseViewModel
    {
        private IAsyncResult async;
        private readonly string buffer = string.Empty;
        private readonly RussianWordsSuggestionService russianWordsSuggestionService;

        public string Buffer
        {
            get => Get(buffer);
            set => Set(value);
        }

        public SuggestionBusinessObject FirstSuggestion { get; set; }

        public SuggestionBusinessObject SecondSuggestion { get; set; }

        public SuggestionBusinessObject ThirdSuggestion { get; set; }

        public ICommand ClearCommand => MakeCommand(a => ClearWindow(), c => !IsBufferEmpty());

        public ICommand SetSuggestionsCommand => MakeCommand(a => AsyncFindSuggestions());

        public DashboardViewModel()
        {
            russianWordsSuggestionService = new RussianWordsSuggestionService();
            FirstSuggestion = new SuggestionBusinessObject();
            SecondSuggestion = new SuggestionBusinessObject();
            ThirdSuggestion = new SuggestionBusinessObject();
        }

        private void AsyncFindSuggestions()
        {
            FindSuggestionAsync.FindSuggestionAsyncDelegate findSuggestion = russianWordsSuggestionService.Find;
            async = findSuggestion.BeginInvoke(Buffer, 3, CallbackFindSuggestions, null);
        }

        private void CallbackFindSuggestions(IAsyncResult iAsyncResult)
        {
            AsyncResult asyncResult = iAsyncResult as AsyncResult;
            FindSuggestionAsync.FindSuggestionAsyncDelegate caller = asyncResult.AsyncDelegate as FindSuggestionAsync.FindSuggestionAsyncDelegate;
            caller.EndInvoke(iAsyncResult);

            List<string> collection = russianWordsSuggestionService.Suggestions;
            try
            {
                FirstSuggestion.Word = collection[0];
                SecondSuggestion.Word = collection[1];
                ThirdSuggestion.Word = collection[2];
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
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
