using AutoMapper;
using MovieStore.Application.Operations.Entities.Customer.ViewModels;
using MovieStore.DBOperations;

namespace MovieStore.Application.Operations.Entities.Customer.Commands.Create
{
    public class CreateCustomerCommand
    {
        public CreateCustomerModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommand( IMovieStoreDbContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle()
        {
            MovieStore.Entities. Customer customer = _context.Customers.SingleOrDefault(customer => customer.Email == Model.Email);
            if (customer is not null)
            {
                throw new InvalidOperationException("Kullanıcı zaten mevcut.");
            }

            customer = _mapper.Map<MovieStore.Entities.Customer>(Model);

            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}
