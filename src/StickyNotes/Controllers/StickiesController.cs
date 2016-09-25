using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StickyNotes.Services;
using StickyNotes.Services.Models;

namespace StickyNotes.Controllers
{
    [Route("api/[controller]")]
    public class StickiesController : Controller
    {
        private StickyService _sService;

        public StickiesController(StickyService ss)
        {
            _sService = ss;
        }

        [HttpGet]
        public IList<StickyDTO> Get()
        {
            return _sService.GetStickies(User.Identity.Name);
        }

        [HttpPost]
        public IActionResult Add([FromBody]StickyDTO sticky)
        {
            if(!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            _sService.AddSticky(sticky, User.Identity.Name);

            return Ok();


        }


        [HttpDelete("{id}")]
        public IActionResult Delete(StickyDTO sticky, int id)
        {
            sticky.Id = id;

            _sService.DeleteSticky(sticky, User.Identity.Name);
            return Ok();


        }



    }
}
