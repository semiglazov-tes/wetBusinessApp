using WetBusinessApp.Domain.Entities;
using WetBusinessApp.Infrastructure.Storage.Entity;

namespace WetBusinessApp.Infrastructure.Storage.Mapping;

public static  class Mapper
{
    public static UserEntity UserToUserEntity(this User user)
    {
        return UserEntity.Create(user.UserName, user.UserEmail, user.PasswordHash, user.RefreshToken, user.RefreshTokenExpiryTime);
    }
    
    public static User UserEntityToUser(this UserEntity? userEntity)
    {
        return User.Create(userEntity.Id, userEntity.UserName, userEntity.UserEmail, userEntity.PasswordHash, userEntity.RefreshToken, userEntity.RefreshTokenExpiryTime);
    }
}