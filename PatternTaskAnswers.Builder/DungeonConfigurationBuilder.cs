namespace PatternTaskAnswers.Builder
{
    /// <summary>
    /// Сторитель упрощающий создание конфигурации подземелья
    /// </summary>
    /// <typeparam name="T">дочерний класс от интерфейса IDungeonConfiguration</typeparam>
    public class DungeonConfigurationBuilder<T> where T : IDungeonConfiguration, new()
    {
        protected T _configuration;

        public DungeonConfigurationBuilder()
        {
            _configuration = new T();
        }
        /// <summary>
        /// Метод, который устанавливает значения высоты и ширины
        /// </summary>
        /// <param name="width">высота</param>
        /// <param name="height">ширина</param>
        /// <returns></returns>
        public DungeonConfigurationBuilder<T> WithSize(int width, int height)
        {
            return this.WithWidth(width).WithHeight(height);
        }

        /// <summary>
        /// Установка высоты
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public DungeonConfigurationBuilder<T> WithHeight(int height)
        {
            _configuration.Height = height;
            return this;
        }

        /// <summary>
        /// Установка ширины
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public DungeonConfigurationBuilder<T> WithWidth(int width)
        {
            _configuration.Width = width;
            return this;
        }
        
        /// <summary>
        /// Установка минимальных размеров комнаты
        /// </summary>
        /// <param name="width">минимальная ширина</param>
        /// <param name="height">минимальная высота</param>
        /// <returns></returns>
        public DungeonConfigurationBuilder<T> WithRoomMinSize(int width, int height)
        {
            return this.WithRoomMinHeight(height).WithRoomMinWidth(width);
        }
        
        /// <summary>
        /// Установки минимальной высоты комнаты
        /// </summary>
        /// <param name="value">минимальная высота</param>
        /// <returns></returns>
        public DungeonConfigurationBuilder<T> WithRoomMinHeight(int value)
        {
            _configuration.MinRoomHeight = value;
            return this;
        }
        
        /// <summary>
        /// Установка минимальной ширины комнаты
        /// </summary>
        /// <param name="value">минимальная ширина</param>
        /// <returns></returns>
        public DungeonConfigurationBuilder<T> WithRoomMinWidth(int value)
        {
            _configuration.MinRoomWidth = value;
            return this;
        }

        /// <summary>
        /// Установка максимальных размеров комнаты
        /// </summary>
        /// <param name="width">максимальная ширина</param>
        /// <param name="height">максимальная высота</param>
        /// <returns></returns>
        public DungeonConfigurationBuilder<T> WithRoomMaxSize(int width, int height)
        {
            return this.WithRoomMaxHeight(height).WithRoomMaxWidth(width);
        }
        
        /// <summary>
        /// Установка максимальной высоты комнаты
        /// </summary>
        /// <param name="value">максимальная высота</param>
        /// <returns></returns>
        public DungeonConfigurationBuilder<T> WithRoomMaxHeight(int value)
        {
            _configuration.MaxRoomHeight = value;
            return this;
        }
        
        /// <summary>
        /// Установка максимальной ширины комнаты
        /// </summary>
        /// <param name="value">максимальная ширина</param>
        /// <returns></returns>
        public DungeonConfigurationBuilder<T> WithRoomMaxWidth(int value)
        {
            _configuration.MaxRoomWidth = value;
            return this;
        }
        
        /// <summary>
        /// Установка максимального количества комнат
        /// </summary>
        /// <param name="value">кол-во комнат</param>
        /// <returns></returns>
        public DungeonConfigurationBuilder<T> CountOfRoomsAre(int value)
        {
            _configuration.CountOfRooms = value;
            return this;
        }

        /// <summary>
        /// Установка символа стены
        /// </summary>
        /// <param name="symbol">символ стены</param>
        /// <returns></returns>
        public DungeonConfigurationBuilder<T> WallSymbolIs(DungeonSymbol symbol)
        {
            _configuration.Wall = symbol;
            return this;
        }
        
        /// <summary>
        /// Установка символа пола
        /// </summary>
        /// <param name="symbol">символ пола</param>
        /// <returns></returns>
        public DungeonConfigurationBuilder<T> FloorSymbolIs(DungeonSymbol symbol)
        {
            _configuration.Floor = symbol;
            return this;
        }
        
        /// <summary>
        /// Установка сложности подземелья
        /// </summary>
        /// <param name="difficult">сложность</param>
        /// <returns></returns>
        public DungeonConfigurationBuilder<T> DifficultIs(DungeonDifficult difficult)
        {
            _configuration.Difficult = difficult;
            return this;
        }
        
        /// <summary>
        /// Метод, который завершает строительство
        /// </summary>
        /// <returns></returns>
        public T Build() => _configuration;
    }
}