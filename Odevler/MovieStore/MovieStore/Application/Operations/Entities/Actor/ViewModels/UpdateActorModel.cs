namespace MovieStore.Application.Operations.Entities.Actor.ViewModels
{
    public class UpdateActorModel
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
