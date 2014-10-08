using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private static string dictionaryPath = Path.Combine(Application.StartupPath, "dict.txt");
        private static Validator myValidator = new Validator();
        private static WordDictionary myDictionary;

        public CrosswordForm()
        {
            InitializeComponent();
        }

        private void CrosswordForm_Load(object sender, EventArgs e)
        {
            LoadDictionary();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //If validation method returns false, exit
            //if (!IsArgsValid(args)) return;

            FindAll();
        }

        private void FindAll()
        {
            int matchesFound = 0;
            string uAnagram = txtAnagram.Text.ToString();
            //switch ("a")
            //{
            //    //Anagrams
            //    case "A":
            //        matchesFound = WriteOutAnagrams(userWord, matchesFound);
            //        break;

            //    //Patterns
            //    case "P":
            //        matchesFound = WriteOutPatterns(userWord, matchesFound);
            //        break;
            //}
            //Console.WriteLine("Matches: " + matchesFound);
        }

        /// <summary>
        /// This method validates arguments passed to my crosswords console application.
        /// The format should consist of the following command line arguments:
        /// [A|P] [dictionary] [letters]
        /// </summary>
        /// <param name="args">String array of arguments</param>
        /// <returns>True if arguments are valid or false is there is something wrong</returns>
        //private static Boolean IsArgsValid(string[] args)
        //{
        //    string userOption = args[iArgOption];
        //    string userDict = args[iArgDictionary];
        //    string userWord = args[iArgLetters];
        //    Validator myValidator = new Validator();

        //    try
        //    {
        //        if (args.Length != numExpectedArgs)
        //        {
        //            Console.WriteLine("Invalid arguments! Use:");
        //            Console.WriteLine("m_crossword [A|P] [dictionary] [letters]");
        //            return false;
        //        }

        //        if (!IsOptionValid(userOption, myValidator)) return false;
        //        if (!IsDictionaryValid(userDict, myValidator)) return false;
        //        if (!IsLettersValid(userWord, myValidator)) return false;
        //    }
        //    catch (Exception m)
        //    {
        //        Console.WriteLine("Exception: '" + m + "'");
        //        return false;
        //    }
        //    return true;
        //}

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
        /// This method should performed if first argument is "A" (anagram).
        /// It passes the user's word and checks it for anagrams against 
        /// the dictionary words. It also writes in the console output its'
        /// results as well as keeps track of how many matches were found.
        /// </summary>
        /// <param name="user_word">String letters that user entered</param>
        /// <param name="counter">Starting position of counter. Ideally 0</param>
        /// <returns>Number of anagram matches found</returns>
        //private static int WriteOutAnagrams(string user_word, int counter)
        //{
        //    Crypto cChecker = new Crypto();
        //    foreach (var dictionary_word in newDictionary.dictionary_words)
        //    {
        //        string dict_word = dictionary_word.ToString();
        //        if (cChecker.IsAnagram(dict_word, user_word))
        //        {
        //            counter++;
        //            WriteOutMatch(counter, dictionary_word);
        //        }
        //    }
        //    return counter;
        //}

        /// <summary>
        /// This method should performed if first argument is "P" (pattern).
        /// It passes the user's word and checks it for patterns against 
        /// the dictionary words. It also writes in the console output its'
        /// results as well as keeps track of how many matches were found.
        /// </summary>
        /// <param name="user_word">String letters that user entered</param>
        /// <param name="counter">Starting position of counter. Ideally 0</param>
        /// <returns>Number of pattern matches found</returns>
        //private static int WriteOutPatterns(string user_word, int counter)
        //{
        //    Crypto cChecker = new Crypto();
        //    ArrayList fixedLetters = new ArrayList();

        //    for (int i = 0; i < user_word.Length; i++)
        //    {
        //        if (user_word[i] != '_')
        //        {
        //            fixedLetters.Add(i + ":" + user_word[i]);
        //        }
        //    }

        //    foreach (var dictionary_word in newDictionary.dictionary_words)
        //    {
        //        string dict_word = dictionary_word.ToString();
        //        if (cChecker.IsPattern(dict_word, fixedLetters, user_word.Length))
        //        {
        //            counter++;
        //            WriteOutMatch(counter, dictionary_word);
        //        }
        //    }
        //    return counter;
        //}

        /// <summary>
        /// This method simply writes out to the console a line that
        /// contains a match number and match content (i.e the word)
        /// </summary>
        /// <param name="matchNumber">Number of match found</param>
        /// <param name="dictionary_word">Match string that has been found</param>
        //private static void WriteOutMatch(int matchNumber, object dictionary_word)
        //{
        //    /*Assuming no more than 100 matches can be found at once,
        //     * all single match numbers will have a zero at the beginning 
        //     * in favor of proper alignment when shown in the prompt*/
        //    if (matchNumber < doubleDigit)
        //    {
        //        Console.WriteLine("0" + matchNumber + ": " + dictionary_word);
        //    }
        //    else
        //    {
        //        Console.WriteLine(matchNumber + ": " + dictionary_word);
        //    }
        //}
    }
}
