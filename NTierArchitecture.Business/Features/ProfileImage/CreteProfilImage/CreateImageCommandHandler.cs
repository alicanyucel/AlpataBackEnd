using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArchitecture.Business.Features.Meets.CreateMeets;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.ProfileImage.CreteProfilImage
{
    internal sealed class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, ErrorOr<Unit>>
    {
        private readonly IImageRepository _imageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateImageCommandHandler(IImageRepository imageRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            var isMeetNameExists = await _imageRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if (isMeetNameExists)
            {
                return Error.Conflict("NameIsExists", "Bu resim daha önce oluşturulmuş!");
            }

            Image image = _mapper.Map<Image>(request);

            await _imageRepository.AddAsync(image, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
