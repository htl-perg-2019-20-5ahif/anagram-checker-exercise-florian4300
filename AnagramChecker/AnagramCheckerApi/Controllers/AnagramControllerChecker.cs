using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnagramChecker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnagramCheckerApi.Controllers
{
    public partial class AnagramController
    {

        [HttpPost]
        [Route("checkAnagram")]
        public ActionResult CheckAnagram([FromBody] Words wordType)
        {
            string[] words = { wordType.w1, wordType.w2 };
            if (anagramChecker.Check(words))
            {
                return Ok();
            }
            return BadRequest();

        }
    }
}
