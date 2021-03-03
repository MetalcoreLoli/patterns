using System.Collections.Generic;

namespace PatternTaskAnswers.Builder
{
    /// <summary>
    /// Подземелье
    /// </summary>
    public class Dungeon
    {
        /// <summary>
        /// Ширина
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Высота
        /// </summary>
        public int Height { get; set;  }
        /// <summary>
        /// Кол-во комнат
        /// </summary>
        public int CountOfRooms { get; set;  }
        
        /// <summary>
        /// Солжность
        /// </summary>
        public DungeonDifficult Difficult { get; set; }
        /// <summary>
        /// Комнаты
        /// </summary>
        public List<IRoom> Rooms { get; }

        public Dungeon()
            : this (10, 10, 10, DungeonDifficult.Easy, new List<IRoom>())
        {
            
        }
        public Dungeon(int width, int height, int countOfRooms, DungeonDifficult difficult, List<IRoom> rooms)
        {
            Width = width;
            Height = height;
            CountOfRooms = countOfRooms;
            Difficult = difficult;
            Rooms = rooms;
        }
    }
}