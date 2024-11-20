using Microsoft.EntityFrameworkCore;
using WetBusinessApp.Application.Abstractions.Storage;
using WetBusinessApp.Domain.Entities;
using WetBusinessApp.Domain.ValueObjects;
using WetBusinessApp.Infrastructure.DB;
using WetBusinessApp.Infrastructure.Storage.Entity;
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

        public async Task<Result> Create(User item)
        {
            var userEntity = item.UserToUserEntity();

            try
            {
                using (_dbContext)
                {
                    await _dbContext.Users.AddAsync(userEntity);
                    await _dbContext.SaveChangesAsync();
                }
                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail("Ошибка регистрации");
            }
        }

        public async Task<Result<User>> GetByUserName(string userName)
        {
            try
            {
                UserEntity? userEntity;
                using (_dbContext)
                {
                    userEntity =  await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
                    if (userEntity == null)
                    {
                        return Result<User>.Fail("Данный пользователь не существует");
                    }
                    
                }
                var user = userEntity.UserEntityToUser();
                return Result<User>.Ok(user);
            }
            catch (Exception e)
            {
                return Result<User>.Fail("Ошибка при получении пользователя");
            }
           
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
        
        public Task<Result> Update(User item)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Delete(Guid id)
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