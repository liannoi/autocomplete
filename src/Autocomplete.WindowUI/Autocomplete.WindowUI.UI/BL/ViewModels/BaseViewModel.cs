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

using Autocomplete.WindowUI.UI.Helpers;
using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Autocomplete.WindowUI.UI.BL.ViewModels
{
    public class BaseViewModel : Bindable
    {
        private readonly ConcurrentDictionary<string, ICommand> _cachedCommands;

        public BaseViewModel()
        {
            _cachedCommands = new ConcurrentDictionary<string, ICommand>();
        }

        protected ICommand MakeCommand(Action<object> commandAction, [CallerMemberName] string propertyName = null)
        {
            return GetCommand(propertyName) ?? SaveCommand(new RelayCommand(commandAction), propertyName);
        }

        protected ICommand MakeCommand(Action<object> commandAction, Func<object, bool> func, [CallerMemberName] string propertyName = null)
        {
            return GetCommand(propertyName) ?? SaveCommand(new RelayCommand(commandAction, func), propertyName);
        }

        private ICommand SaveCommand(ICommand command, string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (!_cachedCommands.ContainsKey(propertyName))
            {
                _cachedCommands.TryAdd(propertyName, command);
            }

            return command;
        }

        private ICommand GetCommand(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            return _cachedCommands.TryGetValue(propertyName, out ICommand cachedCommand)
                ? cachedCommand
                : null;
        }
    }
}
