using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;

namespace WeddingPlanner.DAL
{
    public class CommentGateway
    {
        readonly string _connectionString;

        public CommentGateway( string connectionString )
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<CommentData>> GetAll()
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                return await con.QueryAsync<CommentData>(
                    @" select
                             u.FirstName,
							 u.Email,                            
							 s.PropositionId,
                             s.EventId,
                             s.OrganizerId,
                             s.Proposition,
                             s.PropositionDate                            
                      from weddingplanner.vProposition s
                      join weddingplanner.vUsers u
					  on UserId = OrganizerId
					  where s.OrganizerId = u.UserId;" );
            }
        }

        public async Task<Result<CommentData>> FindById( int propositionId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                CommentData commenti = await con.QueryFirstOrDefaultAsync<CommentData>(
                    @"select s.PropositionId,
                             s.EventId,
                             s.OrganizerId,
                             s.Proposition,
                             s.PropositionDate                            
                      from weddingplanner.vProposition s
                      where s.PropositionId = @PropositionId;",
                    new { PropositionId = propositionId } );

                if( commenti == null ) return Result.Failure<CommentData>( Status.NotFound, "comment not found." );
                return Result.Success( commenti );
            }
        }

        public async Task<Result<int>> Create( int eventId, int organizerId, string proposition, DateTime propositionDate )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@eventId", eventId );
                p.Add( "@organizerId", organizerId );
                p.Add( "@proposition", proposition );
                p.Add( "@propositionDate", propositionDate );
                p.Add( "@PropositionId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                p.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "weddingplanner.sPropositionCreate", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Created, p.Get<int>( "@EventId" ) );
            }
        }
        public async Task<Result> Delete( int propositionId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@PropositionId", propositionId );
                p.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "weddingplanner.sPropositionDelete", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Comment not found." );

                Debug.Assert( status == 0 );
                return Result.Success();
            }
        }
        public async Task<Result> Update( int propositionId, int eventId, int organizerId,string proposition, DateTime propositionDate )
        {

            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@propositionId", propositionId );
                p.Add( "@eventId", eventId );
                p.Add( "@organizerId", organizerId );
                p.Add( "@proposition", proposition );
                p.Add( "@propositionDate", propositionDate );
                p.Add( "@status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "weddingplanner.sPropositionUpdate", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Comment not found." );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Ok );
            }
        }
     

    }
}
