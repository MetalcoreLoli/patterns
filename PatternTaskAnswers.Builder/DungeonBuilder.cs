using System;
using System.IO;

namespace PatternTaskAnswers.Builder
{
    /// <summary>
    /// Строитель упрощающий создание подземелье
    /// </summary>
    public class DungeonBuilder
    {
        private Dungeon _dungeon;
        private readonly IDungeonFactory _factory;
        private readonly IDungeonConfiguration _configuration;

        /// <summary>
        /// АХТУНГ
        /// сюда не смотрите пропускайте
        /// !!!!
        /// </summary>
        /// <param name="factory">фабрика, описывающая создание частей подземелья</param>
        /// <param name="builder">функция, которая создает конфигурацию</param>
        public DungeonBuilder (
            IDungeonFactory factory, 
            Func<DungeonConfigurationBuilder<EmptyDungeonConfiguration>, IDungeonConfiguration> builder)
            : this (factory, builder.Invoke(new DungeonConfigurationBuilder<EmptyDungeonConfiguration>()))
        {}

        /// Для своей работы использует фабрику и конфигурацию
        /// <summary>
        /// Конструктор строителя, принанимает два зависимости - фабрику благодаря,
        /// которой генерирует подземелье и конфигурациею, которая помогает фабрике с генерацией 
        /// </summary>
        /// <param name="factory">фабрика</param>
        /// <param name="configuration">конфигурация</param>
        public DungeonBuilder(IDungeonFactory factory, IDungeonConfiguration configuration)
        {
            _dungeon = new Dungeon();
            _configuration = configuration;
            _factory = factory;
        }

        /// <summary>
        /// Метод, который генерирует одну комнату.
        /// Для своей работы использует фабрику и конфигурацию
        /// </summary>
        /// <returns></returns>
        private IRoom GenerateRoom()
        {
             int width = new Random().Next(_configuration.MinRoomWidth, _configuration.MaxRoomWidth);
             int height = new Random().Next(_configuration.MinRoomHeight, _configuration.MaxRoomHeight);
             int x = new Random().Next(0, _configuration.Width - width);
             int y = new Random().Next(0, _configuration.Height - height);
            
             return _factory.MakeRoom(width, height, x, y);
        }

        /// <summary>
        /// Метод, соединяет все сгенерированные комнаты
        /// </summary>
        /// <returns></returns>
        public DungeonBuilder ConnectAllRooms()
        {
            for (int i = 1; i < _dungeon.CountOfRooms; i++)
            {
                var prev = _dungeon.Rooms[i - 1];
                var current = _dungeon.Rooms[i];
                ConnectTwoRooms(prev, current);
            }
            return this;
        }

        /// <summary>
        /// Метод, который соединяет две комнаты
        /// </summary>
        /// <param name="prev">Первая комната</param>
        /// <param name="current">Вторая комната</param>
        /// <returns>Возвращяает путь</returns>
        /// <exception cref="ArgumentOutOfRangeException">Бросает исключение, если значение
        /// пути не описывается enum'ом</exception>
        private IPath ConnectTwoRooms(IRoom prev, IRoom current)
        {
            var dir = (PathType)new Random().Next(0, 2);
            switch (dir)
            {
                case PathType.Vertical:
                    return _factory.MakePathFromTo(prev, current, PathType.Vertical);
                case PathType.Horizontal:
                    return _factory.MakePathFromTo(prev, current, PathType.Horizontal);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Метод, который генерирует комнаты
        /// </summary>
        /// <returns>Возвращяет строителя</returns>
        public DungeonBuilder GenerateRooms()
        {
            for (int i = 0; i < _dungeon.CountOfRooms + 1; i++)
            {
                var room = GenerateRoom();
                while (_dungeon.Rooms.Exists(r => room.Intersect(r)))
                    room = GenerateRoom();
                _dungeon.Rooms.Add(room);
            }
            return this;
        }
        
        /// <summary>
        /// Метод, который завершает создание подземелья
        /// </summary>
        /// <returns></returns>
        public Dungeon Construct()
        {
            return _dungeon;
        }
    }
}