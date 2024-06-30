using posApp.DB;
using posApp.Models;

namespace posApp.Services
{
    public class UserService
    {

        private readonly DataContext _dtContext;
        public UserService(DataContext dtcontext)
        {
            _dtContext = dtcontext;
        }
        public List<User> GetUsers()
        {
            return _dtContext.users.ToList();
        }

        public User? FindUser(string email)
        {
            return _dtContext.users.FirstOrDefault(user => user.email == email);
        }

        public void AddUser(User newUser)
        {
            _dtContext.users.Add(newUser);
            _dtContext.SaveChanges();
            /*Console.WriteLine("User added successfully.");*/
        }

        public User? AuthenticateUser(string email, string password)
        {
            return _dtContext.users.FirstOrDefault(user => user.email == email && user.password == password);
        }

        public bool AuthorizeUser(string email, string reqRole)
        {
            User? user = FindUser(email);
            return user?.role == reqRole;
        }

        public void DeleteUser(string email)
        {
            User? user = FindUser(email);
            if (user != null)
            {
                _dtContext.users.Remove(user);
                _dtContext.SaveChanges();
                Console.WriteLine("User removed successfully.");
            }
        }

        public User? UpdateUserRole(string email, string role)
        {
            User? existingUser = FindUser(email);
            existingUser.role = role;
            _dtContext.SaveChanges();
            return existingUser;
        }





    }

}
