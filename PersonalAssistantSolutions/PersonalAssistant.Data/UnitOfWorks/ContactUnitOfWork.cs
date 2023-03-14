using Microsoft.EntityFrameworkCore.Storage;
using PersonalAssistant.Data.Context;
using PersonalAssistant.Data.UnitOfWorks.Interfaces;

namespace PersonalAssistant.Data.UnitOfWorks
{
    public class ContactUnitOfWork : IContactUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private readonly PersonalAssistantDatabaseContext _context;

        public ContactUnitOfWork(PersonalAssistantDatabaseContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _transaction?.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _transaction?.RollbackAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            try
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    _context?.Dispose();
                    _transaction?.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
