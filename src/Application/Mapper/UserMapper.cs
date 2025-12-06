using Application.Dto.Response.Users;
using Domain.Users.Entity;

namespace Application.Mapper
{
    public class UserMapper
    {
        public static UserResponse Map(User user)
        {
            return new UserResponse
            {
                Id = user.Id.Value,
                Name = user.Name,
                LastName = user.LastName,
                UserName = user.UserName,
                Cellphones = user.Cellphones.Map(cell => CellphoneMapper.Map(cell))
            };

        }
    }
}
