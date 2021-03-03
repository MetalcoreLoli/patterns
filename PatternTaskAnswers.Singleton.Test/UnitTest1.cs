using System;
using System.Reflection.Emit;
using NUnit.Framework;
using PatternTaskAnswers.Singleton;

namespace PatternsTaskAnswers.Singleton.Test
{
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {
            var cache = EntityCacheSingleton.Instance.Registry<int>();
            cache.GetOrAdd(1);
            cache.GetOrAdd(2);
        }

        [Test]
        public void InstanceTest()
        {
            var cache = EntityCacheSingleton.Instance;
            var cacheOne = EntityCacheSingleton.Instance;
            
            Assert.That(ReferenceEquals(cache, cacheOne), Is.True);
        }

        [Test]
        public void GetOrAddTest()
        {
            var cache = EntityCacheSingleton.Instance.Registry<int>();
            Assert.AreEqual(1, cache.GetOrAdd(1));
            Assert.AreEqual(2, cache.GetOrAdd(2));
        }

        [Test]
        public void RegistryTest()
        {
            var cache = EntityCacheSingleton.Instance;

            Assert.Throws<TypeAccessException>(() => cache.GetOrAdd("NYA~~~"));
        }

        [Test]
        public void ContainsTest()
        {
            var cache = EntityCacheSingleton.Instance;
            
            Assert.That(cache.Contains(1), Is.True);
            Assert.That(cache.Contains(4), Is.False);
            Assert.That(cache.Contains<string>(), Is.False);
        }
        
        [Test]
        public void DropTest()
        {
            var cache = EntityCacheSingleton.Instance;
            cache.Drop(1);
            Assert.That(cache.Contains(1), Is.False);
            Assert.Throws<TypeAccessException>(() => cache.GetOrAdd("NYA~~~"));
        }


        [Test]
        public void CountOfTypeTest()
        {
            var cache = EntityCacheSingleton.Instance;
            int countOfString = cache.CountOfType<string>();
            int countOfNums = cache.CountOfType<int>();
            
            Assert.AreEqual(2, countOfNums);
            Assert.AreEqual(0, countOfString);
            
        }
    }
}