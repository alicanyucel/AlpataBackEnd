using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.ProfileImage.CreteProfilImage
{
    public sealed record CreateImageCommand(
       string Name,
       string FileUrl
      ) : IRequest<ErrorOr<Unit>>;
}

