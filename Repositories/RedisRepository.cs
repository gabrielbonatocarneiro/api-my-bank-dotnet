using System;
using System.Runtime.Remoting;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace api_my_bank_dotnet.Repositories
{
  public class RedisRepository
  {
    private IConnectionMultiplexer redis;

    private IDatabase db;

    public RedisRepository(IConnectionMultiplexer redis)
    {
      this.redis = redis;
      this.db = redis.GetDatabase();
    }

    public async Task<string> GetAsync(string key)
    {
      var value = await db.StringGetAsync(key);

      return value.ToString();
    }

    public async Task<string> CreateAsync(string key, dynamic value)
    {
      string serializedData = value is String ? value : JsonConvert.SerializeObject(value);

      await db.StringAppendAsync(key, serializedData);

      return await GetAsync(key);
    }

    public async Task DeleteAsync(string key)
    {
      await db.KeyDeleteAsync(key);
    }
  }
}
