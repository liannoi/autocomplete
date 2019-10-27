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
using System.Linq;

namespace Autocomplete.WindowUI.UI.Helpers
{
    public static class StringOperation
    {
        public static string ReplaceLastOccurrence(string source, string find, string replace)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("Inappropriate argument passed", nameof(source));
            }

            if (string.IsNullOrWhiteSpace(find))
            {
                throw new ArgumentException("Inappropriate argument passed", nameof(find));
            }

            int place = source.LastIndexOf(find, StringComparison.InvariantCulture);
            if (place == -1)
            {
                return source;
            }

            string result = source.Remove(place, find.Length).Insert(place, replace);
            return result;
        }

        public static string LastWord(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("Inappropriate argument passed", nameof(source));
            }

            string result = source.Split().Last();
            return result;
        }
    }
}
