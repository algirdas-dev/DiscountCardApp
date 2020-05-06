using System;
using System.Collections.Generic;
using System.Linq;
using DiscountCardApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiscountCardApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly ILogger<DiscountController> _logger;
        private readonly DiscountService _service;

        public DiscountController(ILogger<DiscountController> logger, DiscountService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("[action]/{code}")]
        public List<string> GetProductList(string code)
        {
            return _service.GetList(code);
        }
    }
}
