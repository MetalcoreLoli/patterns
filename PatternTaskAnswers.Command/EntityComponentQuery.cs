using System.Linq;
using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    public class EntityComponentQuery<T> : IEntityComponentQuery<T> where T : ICompanent
    {
        private readonly IEntity _entity;
        private readonly ILogger _logger;

        public EntityComponentQuery (IEntity entity, ILogger logger)
        {
            _entity = entity;
            _logger = logger;
        }

        public T Execute()
        {
            _logger.Write($"Entity {_entity.Name} make query to get {typeof(T).Name} component");
            return _entity.Companents.OfType<T>().First();   
        }
    }
}