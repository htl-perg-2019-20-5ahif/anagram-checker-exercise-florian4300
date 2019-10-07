using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramCheckerApi.Controllers
{
    public partial class AnagramController
    {
        [HttpPost]
        [Route("getPermutations")]
        public ActionResult GetPermutations([FromQuery] string w)
        {
            var anagrams = anagramChecker.GetPermutations(w);
            if (anagrams.ToList().Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(anagrams);
            }

        }
    }
}
