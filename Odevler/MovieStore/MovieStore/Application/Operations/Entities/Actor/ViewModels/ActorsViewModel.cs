﻿namespace MovieStore.Application.Operations.Entities.Actor.ViewModels
{
    public class ActorsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ActorsViewModel> Movies { get; set; }
    }
}
