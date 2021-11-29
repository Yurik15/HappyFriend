using System;
using System.Threading;
using System.Threading.Tasks;

namespace HFS.Infrastracture.DataAccess
{
    /// <summary>
    /// unit of work interface with async disposable
    /// </summary>
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
