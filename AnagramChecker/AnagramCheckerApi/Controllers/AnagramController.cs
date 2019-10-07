using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnagramChecker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnagramCheckerApi.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class AnagramController : ControllerBase
    {


        private readonly IAnagramChecker anagramChecker;
        private readonly ILogger<AnagramController> logger;

        public AnagramController(IAnagramChecker anagramChecker, ILogger<AnagramController> _logger)
        {
            this.anagramChecker = anagramChecker;
            logger = _logger;
        }
    }
}
