namespace PatternTaskAnswers.Adapter
{
    /// <summary>
    /// Компонент, который содержит описание место расположения сущности
    /// </summary>
    public struct MovableCreatureComponent : ICompanent
    {
        public (int X, int Y) Location;

        public MovableCreatureComponent(int x, int y)
        {
            Location = (x, y);
        }
    }
}