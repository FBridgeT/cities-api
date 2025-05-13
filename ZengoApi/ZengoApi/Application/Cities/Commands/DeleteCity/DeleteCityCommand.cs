using MediatR;

namespace ZengoApi.Application.Cities.Commands.DeleteCity
{
    public sealed record DeleteCityCommand(int Id) : IRequest;
}
