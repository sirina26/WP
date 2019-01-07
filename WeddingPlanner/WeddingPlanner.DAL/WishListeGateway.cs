using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;

namespace WeddingPlanner.DAL
{
    public class WishListeGateway
    {
        readonly string _connectionString;

        public WishListeGateway( string connectionString )
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<WishListeData>> GetAll()
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                return await con.QueryAsync<WishListeData>(
                    @"select s.TaskId,
                             s.CustomerId,
                             s.Task,
                             s.StateTask
                      from weddingplanner.vWish s;" );
            }
        }

        public async Task<Result<WishListeData>> FindById( int taskId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                WishListeData WLD = await con.QueryFirstOrDefaultAsync<WishListeData>(
                     @"select s.TaskId,
                             s.CustomerId,
                             s.Task,
                             s.StateTask
                      from weddingplanner.vWish s
                      where s.TaskId = @TaskId;",
                    new { TaskId = taskId } );

                if( WLD == null ) return Result.Failure<WishListeData>( Status.NotFound, "event not found." );
                return Result.Success( WLD );
            }
        }

        public async Task<Result<EventOrganizerData>> FindEventOrganizerById( int taskId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                EventOrganizerData WishsData = await con.QueryFirstOrDefaultAsync<EventOrganizerData>(
                     @"select s.TaskId,
                             s.CustomerId,
                             s.Task,
                             s.StateTask
                      from weddingplanner.vWish s
                      where s.TaskId = @TaskId;",
                    new { TaskId = taskId } );

                if( WishsData == null ) return Result.Failure<EventOrganizerData>( Status.NotFound, "wish not found." );
                return Result.Success( WishsData );
            }
        }

        public async Task<Result<int>> Create( string task, int customerId, byte stateTask )
        {

            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@Task", task );
                p.Add( "@CustomerId", customerId );
                p.Add( "@StateTask", stateTask );
                p.Add( "@TaskId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                await con.ExecuteAsync( "weddingplanner.sWishListCreate", p, commandType: CommandType.StoredProcedure );

                return Result.Success( Status.Created, p.Get<int>( "@TaskId" ) );
            }
        }

        public async Task<Result> Delete( int taskId )
        {
            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@TaskId", taskId );
                p.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "weddingplanner.sWishDelete", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Task not found." );

                Debug.Assert( status == 0 );
                return Result.Success();
            }
        }

        public async Task<Result> Update(int taskId, string task, int customerId, byte stateTask )
        {

            using( SqlConnection con = new SqlConnection( _connectionString ) )
            {
                var p = new DynamicParameters();
                p.Add( "@task", task );
                p.Add( "@customerId", customerId );
                p.Add( "@stateTask", stateTask );
                await con.ExecuteAsync( "weddingplanner.vWish", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure( Status.NotFound, "Task not found." );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Ok );
            }
        }

    }
}
