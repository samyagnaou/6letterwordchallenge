using System;
using Xunit;

namespace TestConsoleWordTest
{
    public class UnitTest1
    {
        [Fact]
        public void NewWordCombination_EmptyString_Fails()
        {
            Assert.Throws<ArgumentException>(() => new WordCombination(string.Empty));
        }

        [Fact]
        public void NewWordCombination_Null_Fails()
        {
            Assert.Throws<ArgumentException>(() => new WordCombination(null));
        }

        [Fact]
        public void NewWordSolution_EmptyString_Fails()
        {
            Assert.Throws<ArgumentException>(() => new WordSolution(string.Empty));
        }

        [Fact]
        public void NewWordSolution_Null_Fails()
        {
            Assert.Throws<ArgumentException>(() => new WordSolution(null));
        }
    }
}
}