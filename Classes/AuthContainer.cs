using HorizonREST.Models;

namespace HorizonREST.Classes
{
    internal class AuthContainer
    {
        [ThreadStatic]
        private static AuthContainer s_instance;
        public static AuthContainer Instance => s_instance ??= new();
        public AuthResponse LastAuthResponse { get; set; }
    }
        
  
}
