using BGU.Database.Redis.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
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
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public IActionResult Get()
    {
        return Ok("Redis controller");
    }

    [HttpGet]
    [Route("set")]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public async Task<IActionResult> StringSet(string key, string value)
    {
        return Ok(await _redisStringDal.SetAsync(key, value));
    }

    [HttpGet]
    [Route("get")]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    [SwaggerResponse((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> StringGet(string key)
    {
        var value = await _redisStringDal.GetAsync(key);
        return value != null ? Ok(value) : NotFound();
    }

    [HttpGet]
    [Route("delete")]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public async Task<IActionResult> StringGetAndDeleteAsync(string key)
    {
        return Ok(await _redisStringDal.GetAndDeleteAsync(key));
    }
}
