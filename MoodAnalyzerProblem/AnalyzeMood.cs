namespace MoodAnalyzerProblem
{
    public class AnalyzeMood
    {
        string message;
        public AnalyzeMood(string message)
        {
            this.message = message;
        }
        public string MoodAnalyze()
        {
            if (message.ToLower().Contains("sad"))
            {
                return "Sad";
            }
            else
            {
                return "Happy";
            }
            return message;
        }
    }
}