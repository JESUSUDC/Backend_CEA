using Application.Dto.Response.Users;
using Domain.Users.Entity;

namespace Application.Mapper
{
    public class UserMapper
    {
        public static UserResponse Map(User user)
        {
            return new UserResponse(
                user.Id.Value,
                user.Name,
                user.LastName,
                user.UserName,
                user.Cellphones.Select(cell => CellphoneMapper.Map(cell)).ToList()
            );
        }
    }
}
