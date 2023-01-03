using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorContact.Wasm.Shared {
    public class UsersResponse {
        public bool ok { get; set; }
        public IEnumerable<User> users { get; set; }
    }
}
