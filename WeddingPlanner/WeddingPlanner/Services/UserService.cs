using WeddingPlanner.DAL;
using System.Threading.Tasks;

namespace WeddingPlanner.WebApp.Services
{
    public class UserService
    {
        readonly UserGateway _userGateway;
        readonly PasswordHasher _passwordHasher;

        public UserService( UserGateway userGateway, PasswordHasher passwordHasher )
        {
            _userGateway = userGateway;
            _passwordHasher = passwordHasher;
        }

        public Task<Result<int>> CreatePasswordUser( string firstName, string lastName, string email, string password, bool userType )
        {
            return _userGateway.CreatePasswordUser( firstName, lastName, email, _passwordHasher.HashPassword( password ), userType );
        }

        public async Task<UserData> FindUser( string email, string password )
        {
            UserData user = await _userGateway.FindByEmail( email );
            if( user != null && _passwordHasher.VerifyHashedPassword( user.Password, password ) == PasswordVerificationResult.Success )
            {
                return user;
            }

            return null;
        }
        public async Task<UserData> FindUserType( int id )
        {
            //UserData user = await _userGateway.FindByEmail( id );
            //if( user != null && _passwordHasher.VerifyHashedPassword( user.Password, password ) == PasswordVerificationResult.Success )
            //{
            //    return user;
            //}

            return null;
        }

    }
}


