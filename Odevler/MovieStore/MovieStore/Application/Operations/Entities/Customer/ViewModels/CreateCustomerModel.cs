namespace MovieStore.Application.Operations.Entities.Customer.ViewModels
{
    public class CreateCustomerModel
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value.Trim(); }
        }
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value.Trim(); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value.Trim(); }
        }
        public string Password { get; set; }
    }
}
