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

        /// <summary>
        /// This method initializes the Form component
        /// "CrosswordForm" and instantiates required
        /// dictionary and validation classes.
        /// </summary>
        public CrosswordForm()
        {
            InitializeComponent();
            myValidator = new Validator();
            myDictionary = new WordDictionary();
        }

        /// <summary>
        /// This method is a delegate to the form's
        /// OnLoad action event. It includes necessary
        /// operations such as loading the dictioanry.
        /// </summary>
        private void CrosswordForm_Load(object sender, EventArgs e)
        {
            LoadDictionary();
        }

        /// <summary>
        /// This method uses the WordDictionary class to
        /// load a txt file with words (dictionary) from 
        /// the application's directory. It also checks 
        /// for the existence of the file at runtime.
        /// </summary>
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

        /// <summary>
        /// This method retrieves all field inputs
        /// from CrosswordForm and stores them in
        /// accesible class strings accordingly.
        /// </summary>
        private void LoadFieldValues()
        {
            uAnagram = txtAnagram.Text.ToString().ToLower();
            uPattern = txtPattern.Text.ToString().ToLower();
            rawWordSizeFormat = txtWordSize.Text.ToString().ToLower();
        }

        /// <summary>
        /// This method is a delegate to the search
        /// button in CrosswordForm. It is called when
        /// a user clicks the button.
        /// </summary>
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

        /// <summary>
        /// This method helps evaluate results and starts/
        /// stops a timer while at it as well. It will 
        /// call appropriate evaluation methods accordingly.
        /// </summary>
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

        /// <summary>
        /// This method evaluates the word size format required
        /// by the user and returns a list of sets that adhere
        /// to the requirements.
        /// </summary>
        /// <param name="rawFormat">String letters that define a word size format</param>
        /// <returns>List of sets that adhere to the word size format</returns>
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

        /// <summary>
        /// This method is a delegate to the clear
        /// button. It is called when a user clicks 
        /// the button.
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        /// <summary>
        /// This method clears the multi-line textbox
        /// of results, as well as all the other 
        /// informative labels.
        private void ClearAll()
        {
            txtResults.Clear();
            lblWords.Text = "";
            lblTimer.Text = "";
            lblMaxLetters.Text = "";
        }

        /// <summary>
        /// This method evaluates the user's input and checks for anagrams 
        /// (if required) against the dictionary words. It also writes in 
        /// the multi-line textbox its results accordingly as well as keeps
        /// track of how many matches were found.
        /// </summary>
        /// <param name="param">String letters entered by user</param>
        /// <param name="wordSet">List of word sets to check</param>
        /// <param name="doAnagram">Whether to check for anagrams</param>
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

        /// <summary>
        /// This method determines and displays results based on several
        /// parameters. It uses Crypto class to check the validity of
        /// anagrams if required.
        /// </summary>
        /// <param name="param">String letters entered by user</param>
        /// <param name="doAnagram">Whether to check for anagrams</param>
        /// <param name="matchesFound">The latest number of matches found</param>
        /// <param name="dictionary_words_splitted">A permutated row of strings</param>
        private bool matchFound(string param, bool doAnagram, int matchesFound, 
                                    string[] dictionary_words_splitted)
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

        /// <summary>
        /// This method combines words (permutation) from multiple
        /// word sets to return a single row of concatenated words
        /// </summary>
        /// <param name="existingSets">List of word sets to loop through</param>
        /// <param name="resultSetCount">The number of existing sets</param>
        /// <param name="allPosValues">Index of value to loop through</param>
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
        /// This method evaluates the user's innput and checks it for patterns against 
        /// specific dictionary words from a list of word sets.
        /// </summary>
        /// <param name="param">String letters and placeholders of pattern</param>
        /// <param name="wordSet">List of word sets to check</param>
        /// <returns>List of modified word sets with the correct pattern</returns>
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
        /// This method simply prepares match results to be written
        /// out to the multi-line result textbox
        /// </summary>
        /// <param name="matchNumber">Number of match found</param>
        /// <param name="dictionary_word">Match string that has been found</param>
        private void WriteOutMatch(int matchNumber, object dictionary_word)
        {
            string value;
            /*Assuming no more than 1000 matches can be found at once,
             * all match numbers will have appropriate zero preceedings 
             * at the beginning in favor of proper alignment when displayed*/
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
        /// This method simply writes out to the multi-line result textbox
        /// a line that has been passed to it
        /// </summary>
        /// <param name="text">Result string</param>
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
        /// This method simply writes out to the 
        /// toolstrip statusbar a string of text
        /// </summary>
        /// <param name="text">Status mesage</param>
        private void WriteOutStatus(string text)
        {
            toolStripStatusLabel1.Text = text;
        }

        /// <summary>
        /// This method validates arguments passed to my crosswords forms application.
        /// </summary>
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
        /// This method validates the anagram letters entered.
        /// </summary>
        /// <param name="param">anagram letters</param>
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
        /// This method validates the pattern letters entered.
        /// </summary>
        /// <param name="param">pattern string</param>
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
        /// This method validates the word size format entered.
        /// </summary>
        /// <param name="param">raw word size string</param>
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
