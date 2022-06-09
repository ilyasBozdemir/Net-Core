using AutoMapper;
using MovieStore.Application.Operations.Entities.Customer.ViewModels;
using MovieStore.DBOperations;

namespace MovieStore.Application.Operations.Entities.Customer.Queries.GetById
{
    public class GetCustomerByIdQuery
    {
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerByIdQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetCustomerByIdViewModel Handle()
        {
            MovieStore.Entities. Customer customer = _context.Customers.Where(customer => customer.Id == Id).Include(customer => customer.FavoriteGenres).Include(customer => customer.Orders).ThenInclude(order => order.Movie).SingleOrDefault();
            if (customer is null)
            {
                throw new InvalidOperationException("Müşteri bulunamadı.");
            }
            GetCustomerByIdViewModel movieVM = _mapper.Map<GetCustomerByIdViewModel>(customer);
            return movieVM;
        }
    }
}
