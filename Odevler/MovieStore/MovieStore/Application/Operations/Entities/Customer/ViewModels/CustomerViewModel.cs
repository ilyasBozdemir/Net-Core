﻿namespace MovieStore.Application.Operations.Entities.Customer.ViewModels
{
    public class CustomerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public List<GenreViewModel> FavoriteGenres { get; set; }
    }
}
