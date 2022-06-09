namespace MovieStore.Application.Operations.Entities.Director.ViewModels
{
    public class UpdateDirectorModel
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
    }
}

