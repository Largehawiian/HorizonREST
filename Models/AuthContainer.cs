namespace HorizonREST.Models
{
    internal class AuthContainer
    {
        private static AuthContainer s_instance;
        public static AuthContainer Instance => s_instance ??= new();
        public AuthResponse LastAuthResponse { get; set; }
    }
        
  
}
