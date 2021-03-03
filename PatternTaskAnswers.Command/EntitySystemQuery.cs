using System.Linq;
using PatternTaskAnswers.Adapter;

namespace PatternTaskAnswers.Command
{
    /// <summary>
    /// Запрос, который получает из некой сущности систему, которая была указанна в типе Т.
    /// так же данный запрос зависит от ILogger. и требует реализации метода Write () от
    /// наследника ILogger
    /// </summary>
    /// <typeparam name="T">Тип системы, которую необходимо получить из компанента</typeparam>
    public class EntitySystemQuery<T> : IEntitySystemQuery<T> where T : IActionSystem 
    {
        private readonly IEntity _entity;
        private readonly ILogger _logger;

        public EntitySystemQuery (IEntity entity, ILogger logger)
        {
            _entity = entity;
            _logger = logger;
        }

        public T Execute()
        {
            _logger.Write($"Entity {_entity.Name} make query to get {typeof(T).Name} system");
            return _entity.Systems.OfType<T>().First();   
        }
    }
}