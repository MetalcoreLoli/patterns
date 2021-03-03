namespace PatternTaskAnswers.Command
{
    /// <summary>
    /// Интерфейс описывающий реализацию команды 
    /// </summary>
    public interface IEntityCommand<T>
    {
        void Execute(T parametric);
        bool CanExecute(T parametr);
    }
}