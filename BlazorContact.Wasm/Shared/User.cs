using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorContact.Wasm.Shared {
    public class User {
        public string name { get; set; } = "";
        public string lastname { get; set; } = "";
        public string DNI { get; set; } = ""; 
        public string email { get; set; } = "";
        public string statusAccount { get; set; } = "";
        public string role { get; set; } = "";
        public string image { get; set; } = "";
        public string password { get; set; } = "";
        public string phone { get; set; } = "";
        public string? _id { get; set; } = "";

        public string fullName {
            get {
                return lastname + ", "+name;
            }
        }

        public string getRole {
            get {
                if (role == "CIUDADANO")
                    return "Ciudadano";
                if (role == "BASE_SEGURIDAD")
                    return "Base Seguridad";
                if (role == "PERSONAL_SEGURIDAD")
                    return "Personal Seguridad";
                return "Admin";
            }
        }
    }
}
