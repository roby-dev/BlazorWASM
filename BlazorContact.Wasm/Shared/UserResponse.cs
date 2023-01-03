using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorContact.Wasm.Shared {
    public class UserResponse {
        public bool ok { get; set; }
        public User user { get; set; }
    }
}
