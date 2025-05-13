using MediatR;
using ZengoApi.Domain.Models;

namespace ZengoApi.Application.Regions.Queries
{
    public sealed record GetRegionsQuery() : IRequest<List<Region>>;
}
