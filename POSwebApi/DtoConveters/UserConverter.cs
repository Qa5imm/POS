using posApp;
using POSwebApi.Dtos;

namespace POSwebApi.DtoConveters
{
    public static class UserConverter
    {
        public static UserDTO ToDTO(User user)
        {
            return new UserDTO
            {
                name = user.name,
                email = user.email,
                role = user.role
            };
        }

        public static List<UserDTO> ToDTOList(IEnumerable<User> users)
        {
            return users.Select(u => ToDTO(u)).ToList();
        }

        public static User ToUser(UserDTO userDTO)
        {
            return new User
            {
                name = userDTO.name,
                email = userDTO.email,
                role = userDTO.role
            };
        }
    }
}


