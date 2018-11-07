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
                    @"select e.EventId,
                             e.CustomerId,
                             e.OrganizerId,
                             e.EventName,
                             e.EventName,
                             e.Place,
                             e.MaximumPrice,
                             e.NumberOfGuestes,
                             e.Note,
                             e.WeddingDate,
                      from weddingplanner.vEvent e;" );
            }
        }

        public async Task<Result<EventData>> FindById( int eventId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                EventData event1 = await con.QueryFirstOrDefaultAsync<EventData>(

                     @"select e.EventId,
                             e.EventName,
                             e.Place,
                             e.WeddingDate,
                      from weddingplanner.vEvent e;
                    
                      where e.EventId = @EventId;",
                    new { EventId = eventId } );

                if( event1 == null ) return Result.Failure<EventData>( Status.NotFound, "Event not found." );
                return Result.Success( event1 );
            }
        }

        public async Task<Result<EventClassData>> FindEventClassById( int eventId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                EventClassData student = await con.QueryFirstOrDefaultAsync<EventClassData>(


                     @"select e.EventId,
                             e.EventName,
                             e.Place,
                             e.WeddingDate,
                             e.OrganizerId,
                      from weddingplanner.vEvent e                    
                      where e.EventId = @EventId;",
                  
                    new { EventId = eventId } );

                if( student == null ) return Result.Failure<EventClassData>( Status.NotFound, "Event not found." );
                return Result.Success( student );
            }
        }


        public Task<Result<int>> Create( string eventName, string place, DateTime WeddingDate )
        {
            return Create( eventName, place, WeddingDate);
        }

        public async Task<Result<int>> Create( string eventName, string place,float maximumPrice, int numberOfGuestes, string Note,  DateTime WeddingDate)
        {
            if( !IsNameValid( eventName ) ) return Result.Failure<int>( Status.BadRequest, "The first name is not valid." );
            if( !IsNameValid( place ) ) return Result.Failure<int>( Status.BadRequest, "The last name is not valid." );

            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@EventName", eventName );
                p.Add( "@Place", place );
                p.Add( "@MaximumPrice", maximumPrice );
                p.Add( "@NumberOfGuestes", numberOfGuestes );
                p.Add( "@Note", Note );
                p.Add( "@WeddingDate", WeddingDate );
                p.Add( "@EventId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                p.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
              

                await con.ExecuteAsync( "iti.sStudentCreate", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure<int>( Status.BadRequest, "A student with this name already exists." );
                if( status == 2 ) return Result.Failure<int>( Status.BadRequest, "A student with GitHub login already exists." );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Created, p.Get<int>( "@StudentId" ) );
            }
        }

        public async Task<Result> Delete( int studentId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@StudentId", studentId );
                p.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "iti.sStudentDelete", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );
                if (status == 1) return Result.Failure( Status.NotFound, "Student not found." );

                Debug.Assert( status == 0 );
                return Result.Success();
            }
        }

        public async Task<Result> Update( int studentId, string firstName, string lastName, DateTime birthDate, string gitHubLogin )
        {
            if( !IsNameValid( firstName ) ) return Result.Failure( Status.BadRequest, "The first name is not valid." );
            if( !IsNameValid( lastName ) ) return Result.Failure( Status.BadRequest, "The last name is not valid." );

            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@StudentId", studentId );
                p.Add( "@FirstName", firstName );
                p.Add( "@LastName", lastName );
                p.Add( "@BirthDate", birthDate );
                p.Add( "@GitHubLogin", gitHubLogin ?? string.Empty );
                p.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "iti.sStudentUpdate", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Student not found." );
                if( status == 2 ) return Result.Failure( Status.BadRequest, "A student with this name already exists." );
                if( status == 3 ) return Result.Failure( Status.BadRequest, "A student with this GitHub login already exists." );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Ok );
            }
        }

        public async Task AssignClass( int studentId, int classId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                await con.ExecuteAsync(
                    "iti.sAssignClass",
                    new { StudentId = studentId, ClassId = classId },
                    commandType: CommandType.StoredProcedure );
            }
        }

        bool IsNameValid( string name ) => !string.IsNullOrWhiteSpace( name );
    }
}
