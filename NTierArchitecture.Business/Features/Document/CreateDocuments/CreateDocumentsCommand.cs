using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Document.CreateDocuments
{
    public sealed record CreatDocumentsCommand(
        string Name,
        string FileUrl
       ) : IRequest<ErrorOr<Unit>>;
}
