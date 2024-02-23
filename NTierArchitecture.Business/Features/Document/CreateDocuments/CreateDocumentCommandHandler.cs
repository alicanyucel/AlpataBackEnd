using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Business.Features.ProfileImage.CreteProfilImage;
using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Document.CreateDocuments
{
    internal sealed class CreateDocumentCommandHandler : IRequestHandler<CreatDocumentsCommand, ErrorOr<Unit>>
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDocumentCommandHandler(IDocumentRepository documentRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _documentRepository = documentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ErrorOr<Unit>> Handle(CreatDocumentsCommand request, CancellationToken cancellationToken)
        {

            var isDocumentNameExists = await _documentRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if (isDocumentNameExists)
            {
                return Error.Conflict("NameIsExists", "Bu döküman daha önce oluşturulmuş!");
            }

         //   Document document = _mapper.Map<Document>(request);

          //  await _documentRepository.AddAsync(document, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}