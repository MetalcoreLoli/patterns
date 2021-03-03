using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    /// <summary>
    /// Интерфейс, который предоставляет реализацию команд,
    /// для работы с системами сущности
    /// </summary>
    public interface IEntitySystemCommand : IEntityCommand<IActionSystem> {}
}