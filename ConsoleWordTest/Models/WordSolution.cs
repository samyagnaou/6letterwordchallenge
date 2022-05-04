using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ConsoleWordTest.Interface;

namespace ConsoleWordTest.Models
{
    public class WordSolution : ILetterWords
    {
        #region Fields
        private string? wordSolution;
        #endregion

        #region Constructors
        public WordSolution(string word)
        {
            SetWord(word);
        }
        #endregion

        #region Properties
        public string GetWord()
        {
            return wordSolution;
        }

        public void SetWord(string word)
        {
            if(word == null || word == "") throw new ArgumentException("word may not be empty!");
            this.wordSolution = word;
        }
        #endregion
    }
}
