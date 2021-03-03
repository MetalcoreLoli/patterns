using PatternTaskAnswers.Singleton;

namespace PatternTaskAnswers.Command
{
    public interface ILogger
    {
        void Write(string message);
    }
}