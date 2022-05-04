using ConsoleWordTest.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWordTest.Models
{
    public class WordCombination : ILetterWords
    {
        #region Fields
        private string? word;
        #endregion

        #region Contructors
        public WordCombination(string word)
        {
            SetWord(word);
        }
        #endregion

        #region Properties
        public string GetWord()
        {
            return word;
        }

        public void SetWord(string word)
        {
            if(word == null || word == "") throw new ArgumentException("word may not be empty!");
            this.word = word;
        }
        #endregion
    }
}
