using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CrosswordSolver
{
    class Validator
    {
        /// <summary>
        /// Validator Constructor
        /// </summary>
        public Validator()
        {
        }

        /// <summary>
        /// This method validates a string against
        /// "A" or "P" which are the options available
        /// in this assignment.
        /// </summary>
        /// <param name="dictionary_word">The dictionary word</param>
        /// <returns>True if the words are anagrams of each other</returns>
        public bool IsValidOption(string option)
        {
            if (!(option.Equals("A") | option.Equals("P")))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method checks for the existence and readability
        /// of the filename claimed by the user.
        /// </summary>
        /// <param name="path">The filename</param>
        /// <returns>True if file is readable, false if an error occured</returns>
        public bool IsFileValid(string path)
        {
            try
            {
                if (!File.Exists(path)) return false;
                File.Open(path, FileMode.Open, FileAccess.Read).Dispose();
                return true;
            }
            catch (IOException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// This method checks if any digits exist in a string.
        /// </summary>
        /// <param name="word">string to check</param>
        /// <returns>True if digits were found, false if no digits were found</returns>
        public bool ContainsDigits(string word)
        {
            foreach (char user_word_char in word)
            {
                if (char.IsDigit(user_word_char))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks if any punctuation characters
        /// exist in a string with the exception of the underscore.
        /// </summary>
        /// <param name="word">string to check</param>
        /// <returns>True if punctuation chars were found, otherwise returns false</returns>
        public bool ContainsPunctuations(string word)
        {
            foreach (char user_word_char in word)
            {
                if (user_word_char.Equals('_'))
                {
                    //Do nothing: this punctuation letter is an exception.
                }
                else if (char.IsPunctuation(user_word_char))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks if any illegal characters exist accordingly
        /// </summary>
        /// <param name="word">string to check</param>
        /// <returns>True if illegals were found, false if none were found</returns>
        public bool ContainsIllegalCharacters(string word)
        {
            foreach (char user_word_char in word)
            {
                if (!(char.IsLetter(user_word_char) | user_word_char.Equals('_')))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks if any illegal characters exist accordingly
        /// </summary>
        /// <param name="word">string to check</param>
        /// <returns>True if illegals were found, false if none were found</returns>
        public bool ContainsIllegalCharactersOrPlaceholders(string word)
        {
            foreach (char user_word_char in word)
            {
                if (!(char.IsLetter(user_word_char)))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method checks if any illegal characters exist accordingly
        /// </summary>
        /// <param name="word">string to check</param>
        /// <returns>True if illegals were found, false if none were found</returns>
        public bool ContainsIllegalWordSizeFormat(string word)
        {
            if (word.StartsWith(",") | word.EndsWith(",")) return true;

            for (int i = 0; i < word.Length; i++)
            {
                //Check for illegal characters
                char wordChar;
                if (hasIllegalWordSizeFormatCharacters(word, i, out wordChar)) return true;

                //Check for repeated commas
                if (wordSizeFormatHasRepeatedCommas(word, i, wordChar)) return true;
            }
            return false;
        }

        private static bool hasIllegalWordSizeFormatCharacters(string word, 
                                                                int i, out char wordChar)
        {
            wordChar = word[i];
            if (!(wordChar.Equals(' ') | wordChar.Equals(',') | char.IsNumber(wordChar)))
            {
                return true;
            }
            return false;
        }

        private static bool wordSizeFormatHasRepeatedCommas(string word, int i, char wordChar)
        {
            if ((i + 1) <= word.Length)
            {
                if ((wordChar.Equals(',')) && (word[i + 1].Equals(',')))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
