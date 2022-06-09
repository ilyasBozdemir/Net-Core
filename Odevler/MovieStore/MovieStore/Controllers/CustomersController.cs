using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieStore.DBOperations;
using Microsoft.AspNetCore.Authorization;
using MovieStore.Application.Operations.Entities.Customer.Commands.Create;
using MovieStore.Application.Operations.Entities.Customer.ViewModels;
using FluentValidation;
using MovieStore.Application.Operations.Entities.Customer.Queries.GetCustomers;
using MovieStore.Application.Operations.Entities.Customer.Commands.Delete;
using MovieStore.Application.Auth.CreateToken;
using MovieStore.Application.Auth.Models;
using MovieStore.Application.Auth;
using MovieStore.Application.Operations.Entities.Customer.Queries.GetById;

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
        public IActionResult CreateCustomer([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = newCustomer;

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            GetCustomersQuery query = new GetCustomersQuery(context: _context, mapper: _mapper);
            List<CustomerViewModel> result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {

            GetCustomerByIdQuery query = new GetCustomerByIdQuery(_context, _mapper);
            query.Id = id;

            GetCustomerByIdQueryValidator validator = new GetCustomerByIdQueryValidator();
            validator.ValidateAndThrow(query);

            GetCustomerByIdViewModel result = query.Handle();

            return Ok(result);
        }

        [Authorize(Roles = "Customer"), HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context, _httpContextAccessor);
            command.Id = id;

            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }
        [Authorize, HttpPost("login")]
        public ActionResult<Token> CreateToken([FromBody] LoginModel loginInfo)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _configuration);
            command.Model = loginInfo;

            CreateTokenCommandValidator validator = new CreateTokenCommandValidator();
            validator.ValidateAndThrow(command);

            Token token = command.Handle();

            return token;
        }


        [HttpGet("refresh-token")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(context:_context, configuration: _configuration);
            command.RefreshToken = token;
            Token resultAccessToken = command.Handle();
            return resultAccessToken;
        }

        [Authorize(Roles = "Customer"), HttpPost("buymovie/{id}")]
        public IActionResult BuyMovie(int id)
        {
            return NotFound();//gelcek devamý
        }
    }
}