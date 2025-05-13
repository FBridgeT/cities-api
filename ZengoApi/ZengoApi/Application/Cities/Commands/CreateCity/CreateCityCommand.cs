using MediatR;
using ZengoApi.Domain.Models;

namespace ZengoApi.Application.Cities.Commands.CreateCity
{
    public sealed record CreateCityCommand(string Name, int RegionId) : IRequest;
}
