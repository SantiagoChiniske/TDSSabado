using dto;
using System.Net.Http;
using System.Threading.Tasks;

namespace front.Services;

    public class UserServices
    {
        HttpClient client;
        public UserServices(string server){
            client = new HttpClient();
            client.BaseAddress = new Uri(server);
        }
        public async Task Register (string name,
            string userId,
            DateTime birth,
            string Password)
        {
           UsuarioDTO user = new UsuarioDTO();
           user.Name = name;
           user.UserId = userId;
           user.Password = Password;
           user.BirthDate = birth; 

           var result = await client.PostAsJsonAsync("user/Register", user);
        }
    }