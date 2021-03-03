using System.Linq;
using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    /// <summary>
    /// Запрос, который получает из некой сущности компонент, который был указана в типе Т.
    /// так же данный запрос зависит от ILogger. и требует реализации метода Write () от
    /// наследника ILogger
    /// </summary>
    /// <typeparam name="T">Тип компонета, который необходимо получить из сущности</typeparam>
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