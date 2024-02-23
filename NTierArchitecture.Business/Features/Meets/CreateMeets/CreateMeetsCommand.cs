using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Meets.CreateMeets
{
    public sealed record CreateMeetCommand(
        string Name,
        string FileUrl,
        string Description,
        DateTime StartTime,
        DateTime EndTime) : IRequest<ErrorOr<Unit>>;
}
