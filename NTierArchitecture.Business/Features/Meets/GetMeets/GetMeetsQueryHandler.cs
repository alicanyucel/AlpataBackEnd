using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Meets.GetMeets
{
    internal sealed class GetMeetsQueryHandler : IRequestHandler<GetMeetsQuery, List<Meet>>
    {
        private readonly IMeetRepository _meetsRepository;

        public GetMeetsQueryHandler(IMeetRepository meetsRepository)
        {
            _meetsRepository = meetsRepository;
        }

        public async Task<List<Meet>> Handle(GetMeetsQuery request, CancellationToken cancellationToken)
        {
            return await _meetsRepository.GetAll().OrderBy(p => p.Name).ToListAsync(cancellationToken);
        }
    }
}