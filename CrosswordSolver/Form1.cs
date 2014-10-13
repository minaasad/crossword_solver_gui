using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrosswordSolver
{
    public partial class CrosswordForm : Form
    {
        private const int doubleDigit = 10;
        private const int tripleDigit = 100;
        private const int quadrupleDigit = 1000;
        private const int maxResults = 1000;

        private static bool doPattern, doAnagram;

        private static string dictionaryPath = Path.Combine(Application.StartupPath, "dict.txt");
        private static string uAnagram, uPattern, rawWordSizeFormat;

        private static Validator myValidator;
        private static WordDictionary myDictionary;

        public CrosswordForm()
        {
            InitializeComponent();
            myValidator = new Validator();
            myDictionary = new WordDictionary();
        }

        private void CrosswordForm_Load(object sender, EventArgs e)
        {
            LoadDictionary();
        }

        private static void LoadDictionary()
        {
            if (!myValidator.IsFileValid(dictionaryPath))
            {
                MessageBox.Show("Dictionary 'dict.txt' not found. \n Please make sure it's placed in the same directoy as this executable.", "Error");
                Application.Exit();
            }
            else
            {
                myDictionary.LoadFromFile(dictionaryPath);
            }
        }

        private void LoadFieldValues()
        {
            uAnagram = txtAnagram.Text.ToString().ToLower();
            uPattern = txtPattern.Text.ToString().ToLower();
            rawWordSizeFormat = txtWordSize.Text.ToString().ToLower();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            doPattern = true;
            doAnagram = true;
            LoadFieldValues();
            ClearAll();

            //If validation ok, then commence evaluations
            if (IsArgsValid())
            {
                if (uPattern == "")
                {
                    for (int i = 0; i < int.Parse(lblMaxLetters.Text); i++)
                    {
                        uPattern += "_";
                    }
                    doPattern = false;
                }
                else if (uPattern.Distinct().Count() == 1)
                {
                    doPattern = false;
                }
                else if (uAnagram == "")
                {
                    doAnagram = false;
                }

                FindResults();
            }
            return;
        }

        private void FindResults()
        {
            var stopwatch = Stopwatch.StartNew();

            //Evaluate based on word size format
            ListResultSet originalSets = FindSets(rawWordSizeFormat);

            if (doAnagram && !doPattern)
            {
                //Only do anagram
                WriteOutCombinedResults(uAnagram, originalSets, doAnagram);
            }
            else
            {
                ListResultSet patternedSets = GetPatternListSet(uPattern, originalSets);
                WriteOutCombinedResults(uAnagram, patternedSets, doAnagram);
            }

            //Stop the timer
            stopwatch.Stop();
            lblTimer.Text = stopwatch.ElapsedMilliseconds + " ms";
        }

        private ListResultSet FindSets(string rawFormat)
        {
            ListResultSet resultSets = new ListResultSet();

            int[] wordSizes = Array.ConvertAll<string, int>(rawFormat.Split(','), int.Parse);
            foreach (int wordSize in wordSizes)
            {
                resultSets.AddNew(myDictionary.getWordsWithSize(wordSize));
            }
            return resultSets;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtResults.Clear();
            lblWords.Text = "";
            lblTimer.Text = "";
            lblMaxLetters.Text = "";
        }

        /// <summary>
        /// This method should performed if first argument is "A" (anagram).
        /// It passes the user's word and checks it for anagrams against 
        /// the dictionary words. It also writes in the console output its'
        /// results as well as keeps track of how many matches were found.
        /// </summary>
        /// <param name="user_word">String letters that user entered</param>
        /// <param name="counter">Starting position of counter. Ideally 0</param>
        /// <returns>Number of anagram matches found</returns>
        private void WriteOutCombinedResults(string param, ListResultSet wordSet, bool doAnagram)
        {
            int matchesFound = 0;
            List<WordResultSet> existingSets = wordSet.GetAllSets();
            
            int resultSetCount = existingSets.Count;
            List<int> allPosValues = new List<int>();
            for (int i = 0; i < resultSetCount; i++)
            {
                allPosValues.Add(0);
            }

            //loop through string rows/permutations across word sets
            while ((true) && (matchesFound < maxResults))
            {
                if (matchFound(param, doAnagram, matchesFound, 
                    GetCombinedWords(existingSets, resultSetCount, allPosValues)))
                {
                    matchesFound++;
                }

                int upIndex = resultSetCount - 1;
                while (upIndex >= 0 && ++allPosValues[upIndex] >= wordSet.GetAllSets()[upIndex].GetCount())
                {
                    allPosValues[upIndex] = 0;
                    upIndex--;
                }

                if (upIndex < 0)
                {
                    break;
                } 
            }

            WriteOutStatus("Found " + matchesFound + " matches");
        }

        private bool matchFound(string param, bool doAnagram, int matchesFound, string[] dictionary_words_splitted)
        {
            Crypto cChecker = new Crypto();
            bool matchFound = false;

            if (doAnagram)
            {
                if (cChecker.IsAnagram(string.Join("", dictionary_words_splitted).ToLower(), param))
                {
                    matchFound = true;
                    WriteOutMatch(++matchesFound, string.Join(" ", dictionary_words_splitted));
                }
            }
            else
            {
                matchFound = true;
                WriteOutMatch(++matchesFound, string.Join(" ", dictionary_words_splitted));
            }
            return matchFound;
        }

        private static string[] GetCombinedWords(List<WordResultSet> existingSets, int resultSetCount, List<int> allPosValues)
        {
            string[] dictionary_words_splitted = new string[resultSetCount];
            for (int i = 0; i < resultSetCount; i++)
            {
                dictionary_words_splitted[i] = existingSets[i].GetAllWords()[allPosValues[i]];
            }
            return dictionary_words_splitted;
        }

        /// <summary>
        /// This method should performed if first argument is "P" (pattern).
        /// It passes the user's word and checks it for patterns against 
        /// the dictionary words. It also writes in the console output its'
        /// results as well as keeps track of how many matches were found.
        /// </summary>
        /// <param name="user_word">String letters that user entered</param>
        /// <param name="counter">Starting position of counter. Ideally 0</param>
        /// <returns>Number of pattern matches found</returns>
        private ListResultSet GetPatternListSet(string param, ListResultSet wordSet)
        {
            ListResultSet simplifiedSet = new ListResultSet();
            int indexStartSize = 0;

            for (int k = 0; k < wordSet.GetAllSets().Count; k++)
            {
                WordResultSet wrs = wordSet.GetAllSets()[k];
                WordResultSet newSet = new WordResultSet();

                Crypto cChecker = new Crypto();
                List<string> fixedLetters = new List<string>();

                int currWordSize = wrs.GetWordSize();
                if ((k - 1) >= 2)
                {
                    indexStartSize =    wordSet.GetAllSets()[k - 1].GetWordSize() +
                                        wordSet.GetAllSets()[k - 2].GetWordSize() +
                                        wordSet.GetAllSets()[k - 3].GetWordSize();
                }
                else if (((k - 1) > 0) & ((k - 1) < 2))
                {
                    indexStartSize =    wordSet.GetAllSets()[k - 1].GetWordSize() +
                                        wordSet.GetAllSets()[k - 2].GetWordSize();
                }
                else if ((k - 1) == 0)
                {
                    indexStartSize =    wordSet.GetAllSets()[k - 1].GetWordSize();
                }

                string intendedWord = param.Substring(indexStartSize, currWordSize).ToLower();
                for (int i = 0; i < intendedWord.Length; i++)
                {
                    if (intendedWord[i] != '_')
                    {
                        fixedLetters.Add(i + ":" + intendedWord[i]);
                    }
                }

                foreach (var dictionary_word in wrs.GetAllWords())
                {
                    string dict_word = dictionary_word.ToString().ToLower().Trim();
                    if (cChecker.IsPattern(dict_word, fixedLetters, intendedWord.Length))
                    {
                        newSet.AddNew(dictionary_word);
                    }
                }
                simplifiedSet.AddNew(newSet);
            }

            return simplifiedSet;
        }

        /// <summary>
        /// This method simply writes out to the console a line that
        /// contains a match number and match content (i.e the word)
        /// </summary>
        /// <param name="matchNumber">Number of match found</param>
        /// <param name="dictionary_word">Match string that has been found</param>
        private int WriteOutMatches(WordResultSet matches)
        {
            int counter = 0;
            foreach (string result in matches.GetAllWords())
            {
                counter++;
                WriteOutMatch(counter, result);
            }
            return counter;
        }

        /// <summary>
        /// This method simply writes out to the console a line that
        /// contains a match number and match content (i.e the word)
        /// </summary>
        /// <param name="matchNumber">Number of match found</param>
        /// <param name="dictionary_word">Match string that has been found</param>
        private void WriteOutMatch(int matchNumber, object dictionary_word)
        {
            string value;
            /*Assuming no more than 100 matches can be found at once,
             * all single match numbers will have a zero at the beginning 
             * in favor of proper alignment when shown in the prompt*/
            if (matchNumber < doubleDigit)
            {
                value = "000" + matchNumber + ": " + dictionary_word;
            }
            else if ((matchNumber >= doubleDigit) && (matchNumber < tripleDigit))
            {
                value = "00" + matchNumber + ": " + dictionary_word;
            }
            else if ((matchNumber >= tripleDigit) && (matchNumber < quadrupleDigit))
            {
                value = "0" + matchNumber + ": " + dictionary_word;
            }
            else
            {
               value = matchNumber + ": " + dictionary_word;
            }

            WriteOut(value);
        }

        /// <summary>
        /// This method simply writes out to the console a line that
        /// contains a match number and match content (i.e the word)
        /// </summary>
        /// <param name="matchNumber">Number of match found</param>
        /// <param name="dictionary_word">Match string that has been found</param>
        private void WriteOut(string text)
        {
            if (txtResults.Text.Length == 0)
            {
                txtResults.Text = text;
            }  
            else
            {
                txtResults.AppendText("\r\n" + text);
            }
        }

        /// <summary>
        /// This method simply writes out to the console a line that
        /// contains a match number and match content (i.e the word)
        /// </summary>
        /// <param name="matchNumber">Number of match found</param>
        /// <param name="dictionary_word">Match string that has been found</param>
        private void WriteOutStatus(string text)
        {
            toolStripStatusLabel1.Text = text;
        }

        /// <summary>
        /// This method validates arguments passed to my crosswords console application.
        /// The format should consist of the following command line arguments:
        /// [A|P] [dictionary] [letters]
        /// </summary>
        /// <param name="args">String array of arguments</param>
        /// <returns>True if arguments are valid or false is there is something wrong</returns>
        private bool IsArgsValid()
        {
            try
            {
                if (rawWordSizeFormat == "")
                {
                    MessageBox.Show("Word size format cannot be empty.",
                                    "Invalid Input");
                    return false;
                }

                if (uAnagram == "" && uPattern == "")
                {
                    MessageBox.Show("Anagrams and patterns cannot both be empty.",
                                    "Invalid Input");
                    return false;
                }

                if ((uAnagram.Length != uPattern.Length) && 
                    ((uPattern.Length > 0) && (uAnagram.Length > 0)))
                {
                    MessageBox.Show("Anagrams and patterns must be the same length.",
                                   "Invalid Input");
                    return false;
                }

                if (!IsAnagramLettersValid(uAnagram))
                {
                    MessageBox.Show("Anagram word invalid.",
                                    "Invalid Input");
                    return false;
                }

                if (!IsPatternLettersValid(uPattern))
                {
                    MessageBox.Show("Pattern word invalid.",
                                    "Invalid Input");
                    return false;
                }

                if (!IsWordSizeFormatValid(rawWordSizeFormat))
                {
                    return false;
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message,
                                "Invalid Input");
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method validates the third argument: the letters
        /// [letters]
        /// </summary>
        /// <param name="userWord">letters</param>
        /// <param name="myValidator">Validator object to use against</param>
        /// <returns>True if argument is valid, otherwise false</returns>
        private static bool IsAnagramLettersValid(string param)
        {
            if (myValidator.ContainsIllegalCharactersOrPlaceholders(param))
            {
                Console.WriteLine("Illegal characters!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method validates the third argument: the letters
        /// [letters]
        /// </summary>
        /// <param name="userWord">letters</param>
        /// <param name="myValidator">Validator object to use against</param>
        /// <returns>True if argument is valid, otherwise false</returns>
        private static bool IsPatternLettersValid(string param)
        {
            if (myValidator.ContainsIllegalCharacters(param))
            {
                Console.WriteLine("Illegal pattern!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method validates the third argument: the letters
        /// [letters]
        /// </summary>
        /// <param name="userWord">letters</param>
        /// <param name="myValidator">Validator object to use against</param>
        /// <returns>True if argument is valid, otherwise false</returns>
        private bool IsWordSizeFormatValid(string param)
        {
            if (myValidator.ContainsIllegalWordSizeFormat(param))
            {
                MessageBox.Show("Word size format invalid.",
                                "Invalid Input");
                return false;
            }

            string[] tempVals = rawWordSizeFormat.Split(',');
            if (tempVals.Length > 4)
            {
                MessageBox.Show("You cannot have more than 4 words.",
                                "Invalid Input");
                return false;
            }
            else
            {
                lblWords.Text = tempVals.Length.ToString();
                int maxLetters = 0;
                foreach (var item in tempVals)
                {
                    int x = int.Parse(item);
                    if (x > 30)
                    {
                        MessageBox.Show("Word size limit is 30 characters.",
                                        "Invalid Input");
                        return false;
                    }
                    else
                    {
                        maxLetters = maxLetters + x;
                    }
                }
                lblMaxLetters.Text = maxLetters.ToString();
                if (((uPattern.Length != maxLetters) && uPattern.Length > 0) |
                    ((uAnagram.Length != maxLetters) && uAnagram.Length > 0))
                {
                    MessageBox.Show("Word size sum does not match anagram or pattern length",
                                    "Invalid Input");
                    return false;
                }
            }

            return true;
        }
    }
}
