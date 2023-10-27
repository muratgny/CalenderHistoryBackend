using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        //TODO - We will activate later commented parts
        //public List<string> Claims { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        //public string RefreshToken { get; set; }
    }
}
