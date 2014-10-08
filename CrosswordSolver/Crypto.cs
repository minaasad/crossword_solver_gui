using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrosswordSolver
{
    class Crypto
    {
        /// <summary>
        /// Crypto Constructor
        /// </summary>
        public Crypto()
        {
        }

        /// <summary>
        /// This method checks for anagrams by comparing two words.
        /// Ideally those are the dictionary word and the word
        /// entered by the user in the command prompt/terminal 
        /// as the second argument
        /// </summary>
        /// <param name="dictionary_word">The dictionary word</param>
        /// <param name="user_word">The user's word</param>
        /// <returns>True if the words are anagrams of each other</returns>
        public bool IsAnagram(string dictionary_word, string user_word)
        {
            //Validate words
            //Dictionary word must not be empty
            if (string.IsNullOrEmpty(dictionary_word))
            {
                return false;
            }

            //User's word must not be empty
            if (string.IsNullOrEmpty(user_word))
            {
                return false;
            }

            //Both words must be of the same length
            if (dictionary_word.Length != user_word.Length)
            {
                return false;
            }

            foreach (char user_word_char in user_word.ToLower())
            {
                int char_index = dictionary_word.ToLower().IndexOf(user_word_char);

                if (char_index >= 0)
                {
                    dictionary_word = dictionary_word.Remove(char_index, 1);
                }
                else
                {
                    return false;
                }
            }

            return string.IsNullOrEmpty(dictionary_word);
        }

        /// <summary>
        /// This method checks for patterns by comparing a dictionary
        /// word's characters with those fixed user entered characters
        /// (non underscores) by index/position. A word that has the
        /// same length as the dictionary word, and same letters positoned
        /// as in the fixed letters, is considered a word pattern.
        /// </summary>
        /// <param name="dictionary_word">The dictionary word</param>
        /// <param name="fLtrs">A list of string consisting of fixed letters and
        /// their corresponding index positions, separated by the delimiter ':'</param>
        /// <param name="wordLen">The length of the letters entered by the user</param>
        /// <returns>True if the words are patterns of each other</returns>
        public bool IsPattern(string dictionary_word, List<string> fLtrs, int wordLen)
        {
            if (dictionary_word.Length == wordLen)
            {
                foreach (var user_char_value in fLtrs)
                {
                    string[] index_char = user_char_value.ToString().Split(':');
                    char char_at_index = dictionary_word[int.Parse(index_char[0])];

                    if (!(char_at_index.ToString().ToLower().Equals(index_char[1].ToLower())))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
