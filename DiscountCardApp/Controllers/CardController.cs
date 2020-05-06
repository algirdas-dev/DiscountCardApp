using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountCardApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiscountCardApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly CardService _service;

        public CardController(ILogger<CardController> logger, CardService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("[action]/{cardNo}")]
        public List<string> GetProductList(string cardNo)
        {
            return _service.GetList(cardNo);
        }
    }
}
