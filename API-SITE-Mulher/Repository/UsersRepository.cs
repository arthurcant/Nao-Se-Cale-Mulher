using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Context;
using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Data.Converter.Implementations;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace API_SITE_Mulher.Repository
{
    public class UsersRepository : IUsersRepository
    {
        public MySQLContext context;
        public UsuarioConverter converter;

        public UsersRepository(MySQLContext context, UsuarioConverter converter)
        {
            this.context = context;
            this.converter = converter;
        }

        public tb_usuario ValidateCredentials(UserVO user)
        {
            var pass = ComputerHash(user.password, new SHA256CryptoServiceProvider());
            return context.tb_usuarios.FirstOrDefault(u => u.Email == user.email  &&  u.Senha == pass);
        }

        public string ComputerHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public tb_usuario ValidateCredentials(string email)
        {
            return context.tb_usuarios.FirstOrDefault(u => u.Email == email);
        }

        public Usuario RefreshUserInfo(Usuario user)
        {
            if (!context.tb_usuarios.Any(u => u.Id.Equals(user.Id))) return null;

            var element = context.tb_usuarios.SingleOrDefault(t => t.Id.Equals(user.Id));

            var usuarioComDadosAtuais = converter.Parse(user);

            if (element != null)
            {
                try
                {
                    context.Entry(element).CurrentValues.SetValues(usuarioComDadosAtuais);
                    context.SaveChanges();
                    return user;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return user;
        }

        public bool RevokeToken(string email)
        {
            var user = context.tb_usuarios.SingleOrDefault(u => (u.Email == email));
            if (user is null) return false;
            user.RefreshToken = null;
            context.SaveChanges();
            return true;
        }

    }
}
