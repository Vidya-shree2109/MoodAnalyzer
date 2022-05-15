using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzerFactory
    {
        public static object CreateAnalyzeMood(string className, string ConstructorName)
        {
            string pattern = @"." + ConstructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "Constructor Not Found");
            }
        }
        public static object CreateMoodAnalyzerUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(AnalyzeMood);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
                }
            }
            else
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_CLASS, "Class not found");
            }
        }
        public static string InvokeAnalyzeMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzerProblem.AnalyzeMood");
                object moodAnalyzerObject = MoodAnalyzerFactory.CreateMoodAnalyzerUsingParameterizedConstructor("MoodAnalyzerProblem.AnalyzeMood", "AnalyzeMood", message);
                MethodInfo analyzerMoodInfo = type.GetMethod(methodName);
                object mood = analyzerMoodInfo.Invoke(moodAnalyzerObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "Method is not found");
            }
        }
    }
}