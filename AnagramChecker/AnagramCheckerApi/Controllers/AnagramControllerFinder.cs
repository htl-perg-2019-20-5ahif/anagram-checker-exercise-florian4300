using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramCheckerApi.Controllers
{
    public partial class AnagramController
    {
        [HttpPost]
        [Route("getKnown")]
        public ActionResult getKnown([FromQuery] string w)
        {
            var anagrams = anagramChecker.GetKnown(w);
            if (anagrams.Count == 0)
            {
                logger.LogError("No Anagrams found");
                return NotFound();
            }
            else
            {
                return Ok(anagrams);
            }

        }
    }
}
