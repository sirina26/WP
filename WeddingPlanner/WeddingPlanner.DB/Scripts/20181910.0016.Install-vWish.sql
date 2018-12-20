create view weddingplanner.vWish
as
    select

         TaskId     = t.TaskId,
         CustomerId = t.CustomerId,
         Task       = t.Task ,
         StateTask  = t.StateTask 
    
    from weddingplanner.tWish t
