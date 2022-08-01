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
    private readonly IRedisDal _redisDal;

    public RedisController(ILogger<RedisController> logger, IRedisDal redisDal)
    {
        _logger = logger;
        _redisDal = redisDal;
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
        return await _redisDal.StringSetAsync(key, value);
    }

    [HttpGet]
    [Route("get")]
    public async Task<string?> StringGet(string key)
    {
        return await _redisDal.StringGetAsync(key);
    }
}
