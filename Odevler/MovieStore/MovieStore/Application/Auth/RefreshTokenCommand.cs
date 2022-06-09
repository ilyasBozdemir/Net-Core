using MovieStore.DBOperations;

namespace MovieStore.Application.Auth
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IConfiguration _configuration;

        public RefreshTokenCommand(IConfiguration configuration, IMovieStoreDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public Token Handle()
        {
            MovieStore.Entities.Customer customer = _context.Customers.FirstOrDefault(customer => customer.RefreshToken == RefreshToken && customer.RefreshTokenExpireDate > DateTime.Now);
            if (customer is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.ExpirationDate.AddMinutes(5);
                _context.SaveChanges();

                return token;
            }
            else
            {
                throw new InvalidOperationException("Geçerli bir Refresh Token bulunamadı.");
            }
        }
    }
}
