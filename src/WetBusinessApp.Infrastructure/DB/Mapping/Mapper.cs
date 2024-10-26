using WetBusinessApp.Domain.Entities;
using WetBusinessApp.Infrastructure.DB.Entity;

namespace WetBusinessApp.Infrastructure.DB.Mapping;

public static  class Mapper
{
    public static UserEntity UserToUserEntity(this User user)
    {
        return UserEntity.Create(user.UserName, user.UserEmail, user.PasswordHash);
    }
    
    public static User UserEntityToUser(this UserEntity userEntity)
    {
        return User.Create(userEntity.Id, userEntity.UserName, userEntity.UserEmail, userEntity.PasswordHash);
    }
}