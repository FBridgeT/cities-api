using MediatR;

namespace ZengoApi.Application.Cities.Commands.UpdateCity
{
    public sealed record UpdateCityCommand(int Id, string Name, int RegionId) : IRequest;
}
