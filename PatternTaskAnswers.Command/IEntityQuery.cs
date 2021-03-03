namespace PatternTaskAnswers.Command
{
    /// <summary>
    /// Интерфейс реализующие особый вид команды - запрос.
    /// Запрос отличается от обычной команды, тем что в отличие от нее
    /// он не ничего не изменяте, а только возвращает. В данном
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityQuery <T>
    {
        T Execute();
    }
}