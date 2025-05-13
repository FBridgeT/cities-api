using MediatR;
using ZengoApi.Infrastructure.Repositories;

namespace ZengoApi.Application.Cities.Commands.CreateCity
{
    public class CreateCityCommandHandler(
        IRegionsRepository regionsRepository,
        ICitiesRepository citiesRepository)
        : IRequestHandler<CreateCityCommand>
    {
        private readonly IRegionsRepository _regionsRepository = regionsRepository;
        private readonly ICitiesRepository _citiesRepository = citiesRepository;
        public async Task Handle(CreateCityCommand command, CancellationToken cancellationToken)
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

            var isCityExists = await _citiesRepository.IsCityExists(command.Name, command.RegionId, cancellationToken);
            if (isCityExists)
            {
                throw new BadHttpRequestException($"City with Name: {command.Name} already exists");
            }

            await _citiesRepository.CreateCity(command.Name, command.RegionId, cancellationToken);
        }
    }
}
