namespace PatternTaskAnswers.Builder
{
    /// <summary>
    /// Путь соединяющий комнаты
    /// </summary>
    public interface IPath
    {
        int Start { get; }
        int End { get; }
        PathType Type { get; }
    }
}