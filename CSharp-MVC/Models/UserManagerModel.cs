using Microsoft.Extensions.Configuration.UserSecrets;

namespace CSharp_MVC.Models
{
    public class UserManagerModel
    {
        public int idUser { get; set; }
        public string username { get; set; }

        public UserManagerModel(int idUser,string username) {
        this.idUser = idUser;
            this.username = username;
        }
    }
}
