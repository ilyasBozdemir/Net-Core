namespace MovieStore.Application.Operations.Entities.Actor.ViewModels
{
    public class GetActorByIdViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ActorViewModel> Movies { get; set; }
    }
}
