using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    /// <summary>
    /// Обощенный запрос, который возвращает компонент из сущности
    /// </summary>
    /// <typeparam name="T">данный параметр указывает на, то какой компонент будет возвращен</typeparam>
    public interface IEntityComponentQuery<T> : IEntityQuery<T> where T : ICompanent { }
}