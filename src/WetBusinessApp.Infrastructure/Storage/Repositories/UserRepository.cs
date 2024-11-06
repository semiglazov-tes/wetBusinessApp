using Microsoft.EntityFrameworkCore;
using WetBusinessApp.Application.Abstractions;
using WetBusinessApp.Domain.Entities;
using WetBusinessApp.Infrastructure.DB;
using WetBusinessApp.Infrastructure.Storage.Mapping;

namespace WetBusinessApp.Infrastructure.Storage.Repositories
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
            var userEntity = item.UserToUserEntity(); 
            await _dbContext.Users.AddAsync(userEntity);
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task<User> GetByUserName(string userName)
        {
            var userEntity =  await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            var user = userEntity.UserEntityToUser();
            return user;
        }

        public async Task<List<User>> GetAllUser()
        {
            var userEntitys = await _dbContext.Users.ToListAsync();
            List<User> users = new List<User>();
            foreach (var item in userEntitys)
            {
                var user = item.UserEntityToUser();
                users.Add(user);
            }
            return users;
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