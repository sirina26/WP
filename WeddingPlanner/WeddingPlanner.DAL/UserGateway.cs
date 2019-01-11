using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;
namespace WeddingPlanner.DAL
{
    public class UserGateway
    {
        readonly string _connectionString;

        public UserGateway( string connectionString )
        {
            _connectionString = connectionString;
        }

        public async Task<UserData> FindById( int userId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                return await con.QueryFirstOrDefaultAsync<UserData>(
                    "select u.UserId, u.Email, u.[Password] from weddingplanner.vUsers u where u.UserId = @UserId",
                    new { UserId = userId } );
            }
        }

        public async Task<bool> IsOrganizer( int userId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                return await con.QuerySingleAsync<bool>(
                "select u.IsOrganizer from weddingplanner.vUsers u where u.UserId = @UserId",
                new { UserId = userId } );
            }
        }

        public async Task<UserData> FindByEmail( string email )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                return
                    await con.QueryFirstOrDefaultAsync<UserData>(
                    "select u.UserId, u.Email,u.[Password] from weddingplanner.vUsers u where u.Email = @Email",
                    new { Email = email } );
            }
        }

        public async Task<Result<int>> CreatePasswordUser( string FirstName, string LastName, string email, byte[] password,bool userType )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                int id;
                var p = new DynamicParameters();
                p.Add( "@Email", email );
                p.Add( "@Password", password );
                p.Add( "@FirstName", FirstName );
                p.Add( "@LastName", LastName );
                p.Add( "@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                p.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "weddingplanner.sPasswordUserCreate", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure<int>( Status.BadRequest, "An account with this email already exists." );

                Debug.Assert( status == 0 );
               
                id= p.Get<int>( "@UserId" );
                var c = new DynamicParameters();

                if( userType == true )
                {
                    c.Add( "@CustomerId", id );
                    c.Add( "@EventId", 0 );
                    await con.ExecuteAsync( "weddingplanner.sCustomersCreate", c, commandType: CommandType.StoredProcedure );

                }
                else
                {
                    c.Add( "@OrganizerId", id );
                    c.Add( "@PhoneNumber", 0 );
                    await con.ExecuteAsync( "weddingplanner.sOrganizersCreate", c, commandType: CommandType.StoredProcedure );
                }
                return Result.Success( p.Get<int>( "@UserId" ) );

            }
        }        

        public async Task<IEnumerable<string>> GetAuthenticationProviders( string userId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                return await con.QueryAsync<string>(
                    "select p.ProviderName from weddingplanner.vAuthenticationProvider p where p.UserId = @UserId",
                    new { UserId = userId } );
            }
        }

        public async Task Delete( int userId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                await con.ExecuteAsync( "weddingplanner.sUserDelete", new { UserId = userId }, commandType: CommandType.StoredProcedure );
            }
        }

        public async Task UpdateEmail( int userId, string email )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                await con.ExecuteAsync(
                    "weddingplanner.sUserUpdate",
                    new { UserId = userId, Email = email },
                    commandType: CommandType.StoredProcedure );
            }
        }

        public async Task UpdatePassword( int userId, byte[] password )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                await con.ExecuteAsync(
                    "weddingplanner.sPasswordUserUpdate",
                    new { UserId = userId, Password = password },
                    commandType: CommandType.StoredProcedure );
            }
        }
    }
}
