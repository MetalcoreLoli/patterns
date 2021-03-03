namespace PatternTaskAnswers.Builder
{
    /// <summary>
    /// Описание комнаты
    /// </summary>
    public interface IRoom
    {
        int Width { get; }
        int Height { get; }
        int X { get; }
        int Y { get; }

        /// <summary>
        /// Метод провереяет пересекается ли комната с другой комнатой
        /// </summary>
        /// <param name="r">комната</param>
        /// <returns>возвращаяет true, если комнаты пересекаются. false - если комнаты не пересекаются</returns>
        bool Intersect(IRoom r);
    }
}