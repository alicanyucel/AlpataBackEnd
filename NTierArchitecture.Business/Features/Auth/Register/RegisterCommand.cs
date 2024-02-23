using MediatR;
using Microsoft.AspNetCore.Http;

namespace NTierArchitecture.Business.Features.Auth.Register;
public sealed record RegisterCommand(
    string Name,
    string Lastname,
    string Email,
    string UserName,
    string Password,
    string PhoneNumber,
    string ImageUrl
   ) : IRequest<Unit>;
