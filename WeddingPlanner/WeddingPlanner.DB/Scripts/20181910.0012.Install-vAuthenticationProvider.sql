create view weddingplanner.vAuthenticationProvider
as
    select usr.UserId, usr.ProviderName
    from (select UserId = u.UserId,
              ProviderName = 'WeddingPlanner'
          from weddingplanner.tPassword u
         ) usr
          where usr.UserId <> null;

