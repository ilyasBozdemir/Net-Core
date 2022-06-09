using AutoMapper;
using MovieStore.Application.Operations.Entities.Actor.ViewModels;
using MovieStore.Entities;

namespace MovieStore.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateActorModel, Actor>();

        }  
    }
}
