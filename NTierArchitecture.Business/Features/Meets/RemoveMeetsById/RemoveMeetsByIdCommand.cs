using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Meets.RemoveMeetsById
{
    public sealed record RemoveMeetsByIdCommand(
    Guid Id) : IRequest;
}
