using MoodAnalyzerProblem;
using NUnit.Framework;

namespace TestMoodAnalyzer
{
    public class TestMood
    {
        [Test]
        public void GivenInputIsString_WhenTestMoodAnalyze_ShouldReturnReturnEmpty()
        {
            try
            {
                AnalyzeMood analyzer = new AnalyzeMood("");
                string actual = analyzer.MoodAnalyze();
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(ex.Message, "message is Empty");
            }
        }
        [Test]
        public void GivenInputIsString_WhenTestMoodAnalyze_ShouldReturnReturnNull()
        {
            try
            {
                AnalyzeMood analyzer = new AnalyzeMood(null);
                string actual = analyzer.MoodAnalyze();
            }
            catch (MoodAnalyzerException ex)
            {
                Assert.AreEqual(ex.Message, "Message is Null");
            }
        }
        [Test]
        public void GivenAnalyzeMoodClassName_ShouldReturnMoodAnalyzeObject()
        {
            object expected = new AnalyzeMood();
            object obj = MoodAnalyzerFactory.CreateAnalyzeMood("MoodAnalyzerProblem.AnalyzeMood", "AnalyzeMood");
            expected.Equals(obj);
        }
        [Test]
        public void GivenAnalyzeMoodClassName_ShouldReturnMoodAnalyzeObject_UsingParameterizedConstrctor()
        {
            object expected = new AnalyzeMood("HAPPY");
            object obj = MoodAnalyzerFactory.CreateMoodAnalyzerUsingParameterizedConstructor("MoodAnalyzerProblem.AnalyzeMood", "AnalyzeMood", "HAPPY");
            expected.Equals(obj);
        }
        [Test]
        public void GivenHappyMoodShouldReturnHappy()
        {
            string expected = "Happy";
            string mood = MoodAnalyzerFactory.InvokeAnalyzeMood("Happy", "MoodAnalyze");
            Assert.AreEqual(expected, mood);
        }
    }
}