using Microsoft.EntityFrameworkCore;
using WetBusinessApp.Application.Abstractions.Storage;
using WetBusinessApp.Domain.Entities;
using WetBusinessApp.Domain;
using WetBusinessApp.Infrastructure.DB;
using WetBusinessApp.Infrastructure.Storage.Entity;
using WetBusinessApp.Infrastructure.Storage.Mapping;

namespace WetBusinessApp.Infrastructure.Storage.Repositories
{
    public class UserStorage : IUserStorage
    {
        private readonly WetBusinessDContext _dbContext;
        
        public UserStorage(WetBusinessDContext dbcontext)
        {   
            _dbContext = dbcontext;
        }
        
        public async Task<Result> Create(User user)
        {
            var userEntity = user.UserToUserEntity();

            try
            {
                await _dbContext.Users.AddAsync(userEntity);
                await _dbContext.SaveChangesAsync();
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
                var userEntity =  await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
                if (userEntity == null)
                {
                    return Result<User>.Fail("Данный пользователь не существует");
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
        
        public async Task<Result> UpdateRefreshTokenData(Guid userId, string refreshToken, DateTime refreshTokenExpiryTime)
        {
            try
            {
                var userEntity =  await _dbContext.Users.FirstAsync(u => u.Id == userId);
                userEntity.RefreshToken = refreshToken;
                userEntity.RefreshTokenExpiryTime = refreshTokenExpiryTime;
                
                _dbContext.Attach(userEntity);
                _dbContext.Entry(userEntity).Property(u => u.RefreshToken).IsModified = true;
                _dbContext.Entry(userEntity).Property(u => u.RefreshTokenExpiryTime).IsModified = true;

                await _dbContext.SaveChangesAsync();
                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail("Ошибка при обновлении данных Refresh Token");
            }
            
        }
    }
}