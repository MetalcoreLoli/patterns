namespace PatternTaskAnswers.Builder
{
    /// <summary>
    /// Пустая конфигурация, класс является закрытым
    /// </summary>
    public sealed class EmptyDungeonConfiguration: IDungeonConfiguration
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int CountOfRooms { get; set; }
        public int MinRoomWidth { get; set; }
        public int MinRoomHeight { get; set; }
        public int MaxRoomWidth { get; set; }
        public int MaxRoomHeight { get; set; }
        public DungeonDifficult Difficult { get; set; }
        public DungeonSymbol Wall { get; set; }
        public DungeonSymbol Floor { get; set; }
    }
}