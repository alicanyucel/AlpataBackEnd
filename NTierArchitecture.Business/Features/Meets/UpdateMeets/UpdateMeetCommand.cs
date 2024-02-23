using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Meets.UpdateMeets
{
    public sealed record UpdateMeetCommand(
    Guid Id,
    string Name,
    DateTime StartTime,
    string Description,
    string FileUrl,
    DateTime EndTime) : IRequest;
}
