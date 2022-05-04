using ConsoleWordTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWordTest
{
    public class CompleteWords
    {
        #region Fields
        private List<WordCombination> _listTextCombinations = new();
        private List<WordSolution> _listSolCombinations = new();
        #endregion

        #region Constructors
        public CompleteWords(List<string> list, string path, int lengthWordSolution)
        {
            List = list;
            Path = path;
            LengthWordSolution = lengthWordSolution;
            filterListSolAndCombination();
        }
        #endregion

        #region Properties
        private List<string> List { get; }
        private string Path { get; }
        private int LengthWordSolution { get; }


        //add wordobjects to the required list, one list contains the words that might only be available as output for the solution and one to combine all possible combinations
        private void filterListSolAndCombination()
        {
            List.ForEach(s => {
                if(s.Length == LengthWordSolution)
                {
                    _listSolCombinations.Add(new WordSolution(s));
                }
                else
                {
                    _listTextCombinations.Add(new WordCombination(s));
                }
            });


        }

        public void printSolutionList()
        {
            _listSolCombinations.ForEach(e => Console.WriteLine(e.GetWord()));
        }
        public void printPossibleWords()
        {
            _listTextCombinations.ForEach(e => Console.WriteLine(e.GetWord()));
        }
        public void printWordsFromFile()
        {
            List.ForEach(e => Console.WriteLine(e));
        }

        public void printResults()
        {
            // call method and give the lists as parameter and the length
            List<string> result = CombineWordsFromLists(_listTextCombinations, _listSolCombinations, LengthWordSolution);
            Console.WriteLine("The results of the test:");
            result.ForEach(e => Console.WriteLine(e));
        }

        private List<string> CombineWordsFromLists(List<WordCombination> textCombinations, List<WordSolution> solCombinations, int lengthWordSolution)
        {
            //temp lists
            List<string> allowedSolutions = new();
            List<string> words = new();
            List<string> wordsReverse = new();
            List<string> generatedOutput = new();
            List<string> finalList = new();

            //filling lists
            foreach(WordCombination wordCombination in textCombinations)
            {
                words.Add(wordCombination.GetWord());
                wordsReverse.Add(wordCombination.GetWord());
            }
            wordsReverse.Reverse();
            //convert list to stringlist solutions
            solCombinations.ForEach(e => allowedSolutions.Add(e.GetWord()));

            //concat the strings from both list to get all possible outcome
            IEnumerable<string> e = words.SelectMany(a => wordsReverse.Select(b => a + b));

            //filter based on lenght parameter
            generatedOutput = e.Where(r => r.Length <= lengthWordSolution).ToList();

            //filter the outcome based on allowed words list and remove double
            finalList = generatedOutput.Intersect(allowedSolutions).Distinct().ToList();
            return finalList;
        }



    }
    #endregion

}
