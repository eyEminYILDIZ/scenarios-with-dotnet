using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DistributedMemoryCache.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace DistributedMemoryCache.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CallbackController : ControllerBase
	{
		private readonly ILogger<CallbackController> _logger;
		private readonly IDistributedCache _distributedCache;

		public CallbackController(ILogger<CallbackController> logger, IDistributedCache cache)
		{
			_logger = logger;
			_distributedCache = cache;
		}


		[HttpPost("[action]")]
		public IActionResult SetData([FromBody] CallbackData data)
		{
			var cacheKey = data.UniqueIdentifier.ToString();
			var body = JsonSerializer.Serialize(data);

			var cacheOptions = new DistributedCacheEntryOptions
			{
				AbsoluteExpiration = DateTime.Now.AddSeconds(15)
			};

			_distributedCache.SetString(cacheKey, body, cacheOptions);

			return Ok("Data Set Successfully");
		}
	}
}
