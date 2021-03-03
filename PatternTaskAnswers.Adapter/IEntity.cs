using System.Collections.Generic;

namespace PatternTaskAnswers.Adapter
{
    /// <summary>
    /// Сущность
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Имя сущности
        /// </summary>
        string Name { get; set; }
        int Id { get; set; }

        /// <summary>
        /// Компoненты, которые относятся к сущности
        /// </summary>
        List<ICompanent> Companents { get; set; }
        
        /// <summary>
        /// Системы, которые от носятся к системе
        /// </summary>
        List<IActionSystem> Systems { get; set; }
    }
}