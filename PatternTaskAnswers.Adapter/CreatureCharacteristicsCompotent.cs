namespace PatternTaskAnswers.Adapter
{
    /// <summary>
    /// Компонет, который содержит характеристики сущности
    /// </summary>
    public class CreatureCharacteristicsCompotent: ICompanent
    {
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Mp { get; set; }
        public int MaxMp { get; set; }
    }
}