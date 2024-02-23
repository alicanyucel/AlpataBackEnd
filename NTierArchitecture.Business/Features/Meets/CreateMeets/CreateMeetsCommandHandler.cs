using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Meets.CreateMeets
{
    internal sealed class CreateMeetCommandHandler : IRequestHandler<CreateMeetCommand, ErrorOr<Unit>>
    {
        private readonly IMeetRepository _meetRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMeetCommandHandler(IMeetRepository meetRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _meetRepository = meetRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateMeetCommand request, CancellationToken cancellationToken)
        {
            var isMeetNameExists = await _meetRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if (isMeetNameExists)
            {
                return Error.Conflict("NameIsExists", "Bu toplantı daha önce oluşturulmuş!");
            }

            Meet meet = _mapper.Map<Meet>(request);

            await _meetRepository.AddAsync(meet, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
