namespace PatternTaskAnswers.Builder
{
    /// <summary>
    /// Описание настроек конфигурации
    /// </summary>
    public interface IDungeonConfiguration
    {
        int Width { get; set; }
        int Height { get; set;  }
        
        int CountOfRooms { get; set; }
        
        int MinRoomWidth { get; set; }
        int MinRoomHeight { get; set; }
        
        int MaxRoomWidth { get; set; }
        int MaxRoomHeight { get; set; }
        
        /// <summary>
        /// Сложность
        /// </summary>
        DungeonDifficult Difficult { get; set; }
        /// <summary>
        /// Стена
        /// </summary>
        DungeonSymbol Wall { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        DungeonSymbol Floor { get; set; }
    }
}