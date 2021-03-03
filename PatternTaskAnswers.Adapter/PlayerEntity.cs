using System.Collections.Generic;

namespace PatternTaskAnswers.Adapter
{
    /// <summary>
    /// Cущность игрока 
    /// </summary>
    public class PlayerEntity : IEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<ICompanent> Companents { get; set; }
        public List<IActionSystem> Systems { get; set; }
    }
}