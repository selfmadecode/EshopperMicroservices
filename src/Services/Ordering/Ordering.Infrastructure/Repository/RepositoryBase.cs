using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Common;

namespace Ordering.Infrastructure.Repository
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
    }
}
