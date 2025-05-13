using MediatR;
using ZengoApi.Infrastructure.Repositories;

namespace ZengoApi.Application.Cities.Commands.DeleteCity
{
    public class DeleteCityCommandHandler(
        ICitiesRepository citiesRepository)
        : IRequestHandler<DeleteCityCommand>
    {
        private readonly ICitiesRepository _citiesRepository = citiesRepository;
        public async Task Handle(DeleteCityCommand command, CancellationToken cancellationToken)
        {
            if (command.Id < 1)
            {
                throw new BadHttpRequestException($"Invalid Id: {command.Id}");
            }

            var originCityExists = await _citiesRepository.IsOriginCityExists(command.Id, cancellationToken);
            if (!originCityExists)
            {
                throw new BadHttpRequestException($"Base city with Id: {command.Id} doen not exists");
            }

            await _citiesRepository.DeleteCity(command.Id, cancellationToken);
        }
    }
}
