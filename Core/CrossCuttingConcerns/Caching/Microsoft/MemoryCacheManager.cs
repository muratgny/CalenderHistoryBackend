using Core.Utilities.Ioc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        IMemoryCache _cache;//We cannot assign it in the constructor because it is not the dependency chain. We are in core and we have to define it in the CoreModule
        public MemoryCacheManager()
        {
            _cache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }
        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public void Add(string key, object data, int duration)
        {
            _cache.Set(key, data, TimeSpan.FromMinutes(duration));
        }

        public bool IsAdd(string key)
        {
            return _cache.TryGetValue(key, out _);// "out _" is to not get the value from the TryGetValue method.
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// Ex usagefor pattern: ICastoryService.Get 
        /// </summary>
        /// <param name="pattern"></param>
        public void RemoveByPattern(string pattern)
        {
            var coherentState = typeof(MemoryCache).GetField("_coherentState", BindingFlags.NonPublic | BindingFlags.Instance);

            var coherentStateValue = coherentState.GetValue(_cache);
            var cacheEntriesCollectionDefinition = coherentStateValue.GetType().GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);


            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(coherentStateValue) as ICollection;

            var cacheCollectionValues = new List<string>();

            if (cacheEntriesCollection != null)
            {
                foreach (var item in cacheEntriesCollection)
                {
                    var methodInfo = item.GetType().GetProperty("Key");

                    var val = methodInfo.GetValue(item);

                    cacheCollectionValues.Add(val.ToString());
                }
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d)).Select(d => d)
                .ToList();
            foreach (var key in keysToRemove)
            {
                _cache.Remove(key);
            }
        }
    }
}
