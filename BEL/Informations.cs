using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class Informations
    {
        private string _name;
        private string _dob;
        private string _username;
        private string _password;
        private string _gender;
        private string _email;
        private string _address;

        public string Name { get => _name; set => _name = value; }
        public string Dob { get => _dob; set => _dob = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Gender { get => _gender; set => _gender = value; }
        public string Email { get => _email; set => _email = value; }
        public string Address { get => _address; set => _address = value; }
    }
}
