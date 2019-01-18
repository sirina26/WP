using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;

namespace WeddingPlanner.DAL
{
    public class EventGateway
    {
        readonly string _connectionString;

        public EventGateway( string connectionString )
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<EventData>> GetAll()
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                return await con.QueryAsync<EventData>(
                    @"select s.EventId,
                             s.CustomerId,
                             s.OrganizerId,
                             s.EventName,
                             s.Place,
                             s.MaximumPrice,
                             s.NumberOfGuestes,
                             s.Note,
                             s.WeddingDate
                      from weddingplanner.vEvent s;" );
            }
        }

        public async Task<int> FindId( string email)
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                int id = await con.QueryFirstOrDefaultAsync<int>(
                    @"select UserId
                        from weddingplanner.vUsers
                        where Email = 'sassisirine151@yahoo.fr'" );
                return id;
            }
           

        }
        public async Task<Result<EventData>> FindById( int eventId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                EventData eventi = await con.QueryFirstOrDefaultAsync<EventData>(
                    @"select s.EventId,
                             s.CustomerId,
                             s.OrganizerId,
                             s.EventName,
                             s.Place,
                             s.MaximumPrice,
                             s.NumberOfGuestes,
                             s.Note,
                             s.WeddingDate
                      from weddingplanner.vEvent s
                      where s.EventId = @EventId;",
                    new { EventId = eventId } );

                if( eventi == null ) return Result.Failure<EventData>( Status.NotFound, "event not found." );
                return Result.Success( eventi );
            }
        }

        public async Task<Result<EventOrganizerData>> FindEventOrganizerById( int eventId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                EventOrganizerData eventi = await con.QueryFirstOrDefaultAsync<EventOrganizerData>(
                    @"select s.EventId,
                             s.CustomerId,
                             s.OrganizerId,
                             s.EventName,
                             s.Place,
                             s.MaximumPrice,
                             s.NumberOfGuestes,
                             s.Note,
                             s.WeddingDate
                      from weddingplanner.vEvent s
                      where s.EventId = @EventId;",
                    new { EventId = eventId } );

                if( eventi == null ) return Result.Failure<EventOrganizerData>( Status.NotFound, "Event not found." );
                return Result.Success( eventi );
            }
        }


        public async Task<Result<int>> Create(int userId, string eventName, string place, DateTime weddingDate, float maximumPrice, int numberOfGuestes, string note)
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@userId", userId );
                p.Add( "@eventName", eventName );
                p.Add( "@place", place );
                p.Add( "@weddingDate", weddingDate );
                p.Add( "@maximumPrice", maximumPrice );
                p.Add( "@numberOfGuestes", numberOfGuestes );
                p.Add( "@note", note );
                p.Add( "@EventId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                p.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "weddingplanner.sEventCreate", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Created, p.Get<int>( "@EventId" ) );
            }
        }

        public async Task<Result> Delete( int eventId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@EventId", eventId );
                p.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "weddingplanner.sEventDelete", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Event not found." );

                Debug.Assert( status == 0 );
                return Result.Success();
            }
        }

        public async Task<Result> Update( int eventId, string eventName, string place, DateTime weddingDate, float maximumPrice, int numberOfGuestes, string note)//, int customerId, int organizerId )
        {
         
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();                
                p.Add( "@eventId", eventId );
                p.Add( "@eventName", eventName );
                p.Add( "@place", place );
                p.Add( "@weddingDate", weddingDate );
                p.Add( "@maximumPrice", maximumPrice );
                p.Add( "@numberOfGuestes", numberOfGuestes );
                p.Add( "@note", note );
                p.Add( "@status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "weddingplanner.sEventUpdate", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Event not found." );
          
                Debug.Assert( status == 0 );
                return Result.Success( Status.Ok );
            }
        }

        public async Task AssignOrganizer( int eventId, int organizerId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                await con.ExecuteAsync(
                    "weddingplanner.sAssignOrganizer",
                    new { EventId = eventId, OrganizerId = organizerId },
                    commandType: CommandType.StoredProcedure );
            }
        }
    }
}
