using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieStore.DBOperations;
using Microsoft.AspNetCore.Authorization;
namespace MovieStore.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomersController(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public IActionResult CreateCustomer()
        {
            return Ok();
        }



        [HttpGet]
        public IActionResult GetCustomers()
        {

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            return Ok();
        }

        [Authorize(Roles = "Customer"), HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {

            return Ok();
        }
        [Authorize, HttpPost("login")]
        public IActionResult CreateToken(int id)
        {

            return Ok();
        }


        [HttpGet("refresh-token")]
        public IActionResult RefreshToken(int id)
        {

            return Ok();
        }

        [Authorize(Roles = "Customer"), HttpPost("buymovie/{id}")]
        public IActionResult BuyMovie(int id)
        {
            return BadRequest();
        }
    }
}