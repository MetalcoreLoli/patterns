using System;
using System.Collections.Generic;
using System.Reflection;
using PatternTaskAnswers.Singleton;

namespace PatternTaskAnswers.Adapter
{
    /// <summary>
    /// Строитель создающей сущности и регистрирующий ее в "мире", то есть кэше 
    /// </summary>
    /// <typeparam name="T">Наследник интерфейса IEntity</typeparam>
    public class EntityBuilder<T> where T : IEntity, new ()
    {
        private T _entity;
        private IEntityCacheSingleton _cache;

        public EntityBuilder(IEntityCacheSingleton cache)
        {
            _entity = new T();
            _entity.Companents = new List<ICompanent>();
            _entity.Systems = new List<IActionSystem>();
            _cache = cache;
        }
        
        /// <summary>
        /// Метод, устанавливает имя сущности
        /// </summary>
        /// <param name="name">имя</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Name cannot be null !!!</exception>
        public EntityBuilder<T> Called(string name)
        {
            if (name == null)
                throw new ArgumentNullException("Name cannot be null!!!");
            
            _entity.Name = name;
            return this;
        }
        
        /// <summary>
        /// Данный метод рекомендуется вызывать перед добавлением систем/компонентов,
        /// так как он занимается регистрацией сущности в кэше
        /// </summary>
        /// <returns></returns>
        public EntityBuilder<T> Registry()
        {
            _cache.Registry<T>();
            _entity.Id = _cache.CountOfType<T>();
            _cache.GetOrAdd(_entity); 
            return this;
        }
        
        /// <summary>
        /// Метод создает и добавляет систему сущности
        /// </summary>
        /// <typeparam name="TActionSystem">тип систему, которую необходимо создать</typeparam>
        /// <returns></returns>
        public EntityBuilder<T> AddSystem<TActionSystem>() where TActionSystem : IActionSystem, new ()
        {
            var type = typeof(TActionSystem);
            var actionSystem = Activator.CreateInstance<TActionSystem>();
            _entity.Systems.Add(actionSystem); 
            return this;
        }

        /// <summary>
        /// Метод создает и добавляет компонент сущности 
        /// </summary>
        /// <typeparam name="TComponent">тип компонента, который необходимо создать</typeparam>
        /// <returns></returns>
        public EntityBuilder<T> AddComponent<TComponent>() where TComponent: ICompanent, new ()
        {
            var type = typeof(TComponent);
            ICompanent component = Activator.CreateInstance<TComponent>() ;
            _entity.Companents.Add(component); 
            return this;
        }

        /// <summary>
        /// Метод, который завершает создание сущности
        /// </summary>
        /// <returns></returns>
        public T Construct()
        {
            return _entity;  
        } 
    }
}