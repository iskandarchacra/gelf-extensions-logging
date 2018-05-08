﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gelf.Extensions.Logging.Samples.AspNetCore2.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
            _logger.LogDebug("Values controller initialising");
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            using (_logger.BeginScope(("method_name", nameof(Get))))
            {
                var result = new[] {"foo", "bar"};

                _logger.LogInformation("Returning {value1} and {value2} from controller", result[0], result[1]);

                return result;
            }
        }
    }
}
