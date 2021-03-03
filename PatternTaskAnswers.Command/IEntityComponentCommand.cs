using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    /// <summary>
    /// Интерфейс переставляет реализацю команды, которая работает
    /// толко с компанентами  сущности
    /// </summary>
    public interface IEntityComponentCommand : IEntityCommand<ICompanent> {}
}