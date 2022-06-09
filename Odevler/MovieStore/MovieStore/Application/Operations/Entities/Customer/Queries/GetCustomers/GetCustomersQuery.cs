using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Operations.Entities.Customer.ViewModels;
using MovieStore.DBOperations;

namespace MovieStore.Application.Operations.Entities.Customer.Queries.GetCustomers
{
    public class GetCustomersQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersQuery(IMapper mapper, IMovieStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<CustomerViewModel> Handle()
        {
            List<MovieStore.Entities.Customer> customers = _context.Customers.Include(customer => customer.Orders).ThenInclude(order => order.Movie).Include(customer => customer.FavoriteGenres).OrderBy(customer => customer.Id).ToList<MovieStore.Entities.Customer>();
            List<CustomerViewModel> customersVM = _mapper.Map<List<CustomerViewModel>>(customers);

            return customersVM;
        }
    }
}
