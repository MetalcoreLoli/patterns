using PatternTaskAnswers.Singleton;

namespace PatternTaskAnswers.Command
{
    /// <summary>
    /// Интерфес предоставляющий реализацию систему логгирования для команд
    /// </summary>
    public interface ILogger
    {
        void Write(string message);
    }
}