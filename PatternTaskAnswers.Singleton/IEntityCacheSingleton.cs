using System;

namespace PatternTaskAnswers.Singleton
{
    public interface IEntityCacheSingleton
    {
        IEntityCacheSingleton Registry<T>();
        IEntityCacheSingleton Drop(object obj);
        IEntityCacheSingleton Drop<T>();

        int CountOfType<T>();
        
        T GetFirstOfType<T>();
        
        bool Contains(object obj);
        bool Contains<T>();
        object GetOrAdd(object obj);
    }
}