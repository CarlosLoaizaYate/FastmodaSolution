using Fastmoda.Application.IService;
using Fastmoda.Common.LetterSoup;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fastmoda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LetterSoupController : ControllerBase
    {


        // POST api/<LetterSoupController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        private readonly ILetterSoupService _letterSoupService;

        public LetterSoupController(ILetterSoupService letterSoupService)
        {
            _letterSoupService = letterSoupService;
        }

        // POST api/<LetterSoupController>
        [HttpPost("contieneNombre")]
        public Boolean ContieneNombre(LetterSoupContract letterSoupContract)
        {
            return _letterSoupService.contieneNombre(letterSoupContract.info, letterSoupContract.nombre);
        }
    }
}
