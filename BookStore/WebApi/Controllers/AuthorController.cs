using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Application.AuthorOperations.Commands;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext context , IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetAuthors()
        {
            return Ok();
        }
        [HttpGet("id")]
        public ActionResult GetAuthorDetail(int id)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorModel model)
        {
            return Ok();
        }
        [HttpPost("id")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel model)
        {
          
            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeleteGenre(int id)
        {
        
            return Ok();
        }
    }
}
