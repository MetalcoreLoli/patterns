namespace PatternTaskAnswers.Adapter
{
    /// <summary>
    /// Системы - это логику работы сущности
    /// </summary>
    public interface IActionSystem
    {
        /// <summary>
        /// Метод, приводит в действие систему
        /// </summary> 
        void Execute();
    }
}