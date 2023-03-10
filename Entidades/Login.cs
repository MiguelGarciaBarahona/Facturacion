namespace Entidades
{
    public class Login
    {
        public string CodigoUsuario { set; get; }

        public string Contraseña { set; get; }


        public Login()
        {
        }

        public Login(string codigoUsuario, string contraseña)
        {
            CodigoUsuario = codigoUsuario;
            Contraseña = contraseña;

        }
    }
}
