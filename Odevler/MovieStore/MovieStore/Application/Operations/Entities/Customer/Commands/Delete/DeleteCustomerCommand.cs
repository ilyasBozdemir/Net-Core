using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DBOperations;

namespace MovieStore.Application.Operations.Entities.Customer.Commands.Delete
{
    public class DeleteCustomerCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public int Id { get; set; }

        public DeleteCustomerCommand(IMovieStoreDbContext context, IHttpContextAccessor httpContextAccessor)
        {

            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public void Handle()
        {
            MovieStore.Entities. Customer customer = _context.Customers.Include(customer => customer.Orders).SingleOrDefault(customer => customer.Id == Id);
            if (customer is null)
            {
                throw new InvalidOperationException("Müşteri bulunamadı.");
            }

            int requestOwnerId = int.Parse(_httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == "customerId").Value);
            if (requestOwnerId != customer.Id)
            {
                throw new InvalidOperationException("Yalnızca kendi hesabınızı silebilirsiniz.");
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
