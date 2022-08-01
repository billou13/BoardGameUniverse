using BGU.Database.Redis.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.DeckService.Controllers;

[ApiController]
[Route("[controller]")]
public class RedisController : ControllerBase
{
    private readonly ILogger<RedisController> _logger;
    private readonly IRedisStringDal _redisStringDal;

    public RedisController(ILogger<RedisController> logger, IRedisStringDal redisStringDal)
    {
        _logger = logger;
        _redisStringDal = redisStringDal;
    }

    [HttpGet]
    public string Get()
    {
        return "Redis controller";
    }

    [HttpGet]
    [Route("set")]
    public async Task<bool> StringSet(string key, string value)
    {
        return await _redisStringDal.SetAsync(key, value);
    }

    [HttpGet]
    [Route("get")]
    public async Task<string?> StringGet(string key)
    {
        return await _redisStringDal.GetAsync(key);
    }

    [HttpGet]
    [Route("delete")]
    public async Task<string?> StringGetAndDeleteAsync(string key)
    {
        return await _redisStringDal.GetAndDeleteAsync(key);
    }
}
