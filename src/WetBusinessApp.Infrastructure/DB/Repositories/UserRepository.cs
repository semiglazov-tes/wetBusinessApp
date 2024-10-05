using WetBusinessApp.Application.Abstractions;
using WetBusinessApp.Domain;
using WetBusinessApp.Infrastructure.DB.Entity;

namespace WetBusinessApp.Infrastructure.DB.Repositories
{
    public class UserRepository : IUserRepository
    {
        private bool _disposed = false;
        private readonly WetBusinessDContext _dbContext;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _dbContext.DisposeAsync();
            }
            _disposed = true;
        }

        public UserRepository(WetBusinessDContext dbcontext)
        {   
            _dbContext = dbcontext;
        }

        ~UserRepository()
        {
            Dispose(false);
        }

        public async Task Create(User item)
        {
            var user = new UserEntity()
            {
                Id = item.Id,
                UserName = item.UserName,
                UserEmail = item.UserEmail,
                PasswordHash = item.PasswordHash
            };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            
        }

        public Task<User> GetByUserEmail(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(User item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}