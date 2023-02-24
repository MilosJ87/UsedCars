using Microsoft.Extensions.Caching.Distributed;
using System.Runtime.CompilerServices;

namespace UsedCars.Extensions
{
    public static class DistributingCachingExtensions
    {
        public async static Task SetCacheValueAsync<T>(this IDistributedCache distributedCache,
            string key, T value,
            CancellationToken token = default(CancellationToken))
        {
            await distributedCache.SetAsync(key, value.ToByteArray(), token);
        }

        public async static Task<T> GetCacheValueAsync<T>(this IDistributedCache distributedCache,
            string key,
            CancellationToken token = default(CancellationToken)) where T : class
        {
            var result = await distributedCache.GetAsync(key, token);
            return result.FromByteArray<T>();
        }
    }
}
