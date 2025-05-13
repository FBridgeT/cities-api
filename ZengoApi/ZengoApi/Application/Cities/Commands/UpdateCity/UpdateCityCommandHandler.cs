using MediatR;
using ZengoApi.Infrastructure.Repositories;

namespace ZengoApi.Application.Cities.Commands.UpdateCity
{
    public class UpdateCityCommandHandler(
        ICitiesRepository citiesRepository,
        IRegionsRepository regionsRepository)
        : IRequestHandler<UpdateCityCommand>
    {
        private readonly IRegionsRepository _regionsRepository = regionsRepository;
        private readonly ICitiesRepository _citiesRepository = citiesRepository;
        public async Task Handle(UpdateCityCommand command, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(command.Name) || command.RegionId < 1)
            {
                throw new BadHttpRequestException($"Invalid Name: {command.Name} or RegionId: {command.RegionId}");
            }

            var isRegionExists = await _regionsRepository.IsRegionExists(command.RegionId, cancellationToken);
            if (!isRegionExists)
            {
                throw new BadHttpRequestException($"Region with RegionId: {command.RegionId} does not exists");
            }

            var originCityExists = await _citiesRepository.IsOriginCityExists(command.Id, cancellationToken);
            if (!originCityExists)
            {
                throw new BadHttpRequestException($"Base city with Id: {command.Id} doen not exists");
            }

            var isCityExists = await _citiesRepository.IsCityExists(command.Name, command.RegionId, cancellationToken);
            if (isCityExists)
            {
                throw new BadHttpRequestException($"City with Name: {command.Name} doen not exists");
            }

            await _citiesRepository.UpdateCity(command.Name, command.Id, cancellationToken);
        }
    }
}
