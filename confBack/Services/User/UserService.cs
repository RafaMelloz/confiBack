using confBack.Data;
using confBack.Dto;
using confBack.Models;
using Microsoft.EntityFrameworkCore;

namespace confBack.Services.User
{
    public class UserService : UserInterface
    {   
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<UserModel>>> CreateUser(CreateUserDto createUserDto)
        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();

            try
            {
                var user = new UserModel()
                {
                    Name = createUserDto.Name,
                    LastName = createUserDto.LastName,
                    Email = createUserDto.Email,
                    Birthdate = createUserDto.Birthdate,
                    Schooling = createUserDto.Schooling
                };

                _context.Add(user);
                await _context.SaveChangesAsync();

                response.Data = await _context.Users.ToListAsync();
                response.Message = "Usuario cadastrado";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> EditUser(EditUserDto editUserDto)
        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(userDb => userDb.Id == editUserDto.Id);

                if (user == null)
                {
                    response.Message = "Nenhum user localizado";
                    return response;
                }

                user.Name = editUserDto.Name;
                user.LastName = editUserDto.LastName;
                user.Email = editUserDto.Email;
                user.Birthdate = editUserDto.Birthdate;
                user.Schooling = editUserDto.Schooling;


                _context.Update(user);
                await _context.SaveChangesAsync();

                response.Data = await _context.Users.ToListAsync();
                response.Message = "User editado";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> RemoveUser(int idUser)
        {
            ResponseModel < List < UserModel >> response = new ResponseModel<List<UserModel>>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(userDb => userDb.Id == idUser);

                if (user == null)
                {
                    response.Message = "Nenhum user localizado";
                    return response;
                }

                _context.Remove(user);
                await _context.SaveChangesAsync();

                response.Data= await _context.Users.ToListAsync();
                response.Message = "User deletado";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> ToListUsers()
        {

            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();
            try
            {

                var users = await _context.Users.ToListAsync();
                response.Data = users;
                response.Message = "Users retornando";
                return response;
            }
            catch (Exception ex) { 
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
