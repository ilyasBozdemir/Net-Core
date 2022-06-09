using MovieStore.Application.Auth.Models;
using MovieStore.Application.Helpers;
using MovieStore.DBOperations;

namespace MovieStore.Application.Auth.CreateToken
{
    public class CreateTokenCommand
    {
        public LoginModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IConfiguration _configuration;
        public CreateTokenCommand(IMovieStoreDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public Token Handle()
        {
            MovieStore.Entities.Customer customer = _context.Customers.FirstOrDefault(customer => customer.Email == Model.Email);

            if (customer != null && SiteCryptography.MD5Sifrele(Model.Password) == customer.Password)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);
                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.ExpirationDate.AddMinutes(5);

                _context.SaveChanges();
                return token;
            }
            else
                throw new InvalidOperationException("Kulanıcı adı veya şifre yanlış.");

        }
    }
}
