using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DBOperations;

namespace MovieStore.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public OrdersController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {

            return Ok();
        }
    }
}
