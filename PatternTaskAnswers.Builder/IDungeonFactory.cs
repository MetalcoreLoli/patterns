namespace PatternTaskAnswers.Builder
{
    /// <summary>
    /// Фабрика, которая описывате создание частей подземелья
    /// </summary>
    public interface IDungeonFactory
    {
        /// <summary>
        /// Метод описывает создание комнаты
        /// </summary>
        /// <param name="width">ширина комнаты</param>
        /// <param name="height">высота комнаты</param>
        /// <param name="x">ее расположение по х</param>
        /// <param name="y">ее расположение y</param>
        /// <returns>Созданная комната</returns>
        IRoom MakeRoom(int width, int height, int x, int y);
        
        /// <summary>
        /// Метод описывает создание пути от комнаты a в комнату b 
        /// </summary>
        /// <param name="a">от куда</param>
        /// <param name="b">куда</param>
        /// <param name="dir">тип пути</param>
        /// <returns>путь</returns>
        IPath MakePathFromTo(IRoom a, IRoom b, PathType dir); 
    }
}