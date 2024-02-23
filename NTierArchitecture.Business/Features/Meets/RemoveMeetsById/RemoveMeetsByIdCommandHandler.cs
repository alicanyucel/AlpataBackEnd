using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Meets.RemoveMeetsById
{
    internal sealed class RemoveMeetsByIdCommandHandler : IRequestHandler<RemoveMeetsByIdCommand>
    {
        private readonly IMeetRepository _meetRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RemoveMeetsByIdCommandHandler(IMeetRepository meetRepository, IUnitOfWork unitOfWork)
        {
            _meetRepository = meetRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveMeetsByIdCommand request, CancellationToken cancellationToken)
        {
            Meet meet = await _meetRepository.GetByIdAsync(p => p.Id == request.Id, cancellationToken);
            if (meet is null)
            {
                throw new ArgumentException("Toplantı bulunamadı!");
            }

            _meetRepository.Remove(meet);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
