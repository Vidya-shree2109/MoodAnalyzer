using MoodAnalyzerProblem;
using NUnit.Framework;

namespace TestMoodAnalyzer
{
    public class TestMood
    {
        [Test]
        public void GivenInputIsString_WhenTestAnalyseMood_ShouldReturnReturnSad()
        {
            AnalyzeMood analyzer = new AnalyzeMood("I am in Sad Mood");
            string actual = analyzer.MoodAnalyze();
            Assert.Pass(actual, "Sad");
        }
        [Test]
        public void GivenInputIsString_WhenTestAnalyseMood_ShouldReturnReturnHappy()
        {
            AnalyzeMood analyzer = new AnalyzeMood(null);
            string actual = analyzer.MoodAnalyze();
            Assert.Pass(actual, "Happy");
        }
    }
}