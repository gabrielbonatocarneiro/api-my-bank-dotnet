using System.Threading.Tasks;
using api_my_bank_dotnet.Dtos;
using api_my_bank_dotnet.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace api_my_bank_dotnet.Controllers
{
  [Route("api/redis")]
  public class RedisController : ControllerBase
  {
    private RedisRepository repository;

    public RedisController(IConnectionMultiplexer redis)
    {
      repository = new RedisRepository(redis);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(string key)
    {
      var value = await repository.GetAsync(key);

      if (value is null)
      {
        return NotFound(new
        {
          message = "Key não encontrada no Redis"
        });
      }

      var valueOfKey = value;

      if ((value.StartsWith("{") && value.EndsWith("}")) || (value.StartsWith("[") && value.EndsWith("]")))
      {
        valueOfKey = JsonConvert.DeserializeObject<dynamic>(value);
      }

      return new ObjectResult(new
      {
        key = key,
        value = valueOfKey
      });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateValeuRedisDto redisDto)
    {
      var value = await repository.CreateAsync(redisDto.key, redisDto.value);

      var valueOfKey = value;

      if ((value.StartsWith("{") && value.EndsWith("}")) || (value.StartsWith("[") && value.EndsWith("]")))
      {
        valueOfKey = JsonConvert.DeserializeObject<dynamic>(value);
      }

      return new ObjectResult(new
      {
        key = redisDto.key,
        value = valueOfKey
      });
    }

    [HttpDelete("{key}")]
    public async Task<IActionResult> DeleteAsync(string key)
    {
      await repository.DeleteAsync(key);

      return new ObjectResult(new
      {
        message = "Key deleta com sucesso"
      });
    }
  }
}
