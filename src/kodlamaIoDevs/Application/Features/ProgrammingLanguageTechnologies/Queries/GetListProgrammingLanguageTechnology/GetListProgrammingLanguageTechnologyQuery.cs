using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology
{
    public class GetListProgrammingLanguageTechnologyQuery:IRequest<ProgrammingLanguageTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
    }

    public class GetListProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetListProgrammingLanguageTechnologyQuery, ProgrammingLanguageTechnologyListModel>
    {
        private readonly IMapper _mapper;
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;

        public GetListProgrammingLanguageTechnologyQueryHandler(IMapper mapper, IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository)
        {
            _mapper = mapper;
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
        }

        public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetListProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
        {
            var programmingLanguageTechnologies = await _programmingLanguageTechnologyRepository
                .GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            return _mapper.Map<ProgrammingLanguageTechnologyListModel>(programmingLanguageTechnologies);
        }
    }
}
