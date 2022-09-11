using Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguageTechnologies.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProgrammingLanguageTechnology, CreatedProgrammingLanguageTechnologyDto>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, CreateProgrammingLanguageTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, DeletedProgrammingLanguageTechnologyDto>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, UpdatedProgrammingLanguageTechnologyDto>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, UpdateProgrammingLanguageTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, ProgrammingLanguageTechnologyGetByIdDto>().ReverseMap();
            CreateMap<ProgrammingLanguageTechnology, ProgrammingLanguageTechnologyListDto>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguageTechnology>, ProgrammingLanguageTechnologyListModel>().ReverseMap();
        }
    }
}
