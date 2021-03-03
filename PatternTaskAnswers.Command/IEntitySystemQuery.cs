using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    /// <summary>
    /// Запрос, который вытаскивает из сущности систему
    /// </summary>
    /// <typeparam name="T">система, которую необходимо вытащить</typeparam>
    public interface IEntitySystemQuery<T> : IEntityQuery<T> where T : IActionSystem { }
}