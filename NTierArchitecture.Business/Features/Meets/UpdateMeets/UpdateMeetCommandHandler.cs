using AutoMapper;
using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Meets.UpdateMeets
{
    internal sealed class UpdateMeetCommandHandler : IRequestHandler<UpdateMeetCommand>
    {
        private readonly IMeetRepository _meetRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMeetCommandHandler(IMeetRepository meetRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _meetRepository = meetRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateMeetCommand request, CancellationToken cancellationToken)
        {
            Meet meet = await _meetRepository.GetByIdAsync(p => p.Id == request.Id, cancellationToken);
            if (meet is null)
            {
                throw new ArgumentException("Toplantı bulunamadı!");
            }

            if (meet.Name != request.Name)
            {
                var isMeetNameExists = await _meetRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

                if (isMeetNameExists)
                {
                    throw new ArgumentException("Bu toplantı daha önce oluşturulmuş!");
                }
            }

            _mapper.Map(request, meet);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}