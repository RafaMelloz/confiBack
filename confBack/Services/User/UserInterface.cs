using confBack.Dto;
using confBack.Models;

namespace confBack.Services.User
{
    public interface UserInterface
    {
        Task<ResponseModel<List<UserModel>>> ToListUsers();
        Task<ResponseModel<List<UserModel>>> CreateUser(CreateUserDto createUserDto);

        Task<ResponseModel<List<UserModel>>> EditUser(EditUserDto editUserDto);
        Task<ResponseModel<List<UserModel>>> RemoveUser(int idUser);


    }
}
