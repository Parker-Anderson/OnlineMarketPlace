using OnlineMarketPlace.Data;
using OnlineMarketPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketPlace.Services
{
    public class UserService
    {
        private readonly Guid _userId;
        public UserService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    UserID = _userId,
                    Name = model.Name,
                    Email = model.Email,
                    Role = model.Role,
                    DateJoined = model.DateJoined
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Where(e => e.UserID == _userId)
                    .Select(
                        e =>
                        new UserListItem
                        {
                            PersonId = e.PersonId,
                            Name = e.Name,
                            Email = e.Email,
                            Role = e.Role,
                            DateJoined = e.DateJoined,
                        }
                  );
                return query.ToArray();
            }
        }
        public UserDetail GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.PersonId == id && e.UserID == _userId);
                return
                    new UserDetail
                    {
                        PersonId = entity.PersonId,
                        Name = entity.Name,
                        Email = entity.Email,
                        DateJoined = entity.DateJoined,
                        Role = entity.Role
                    };
            }
        }
        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.PersonId == model.PersonId && e.UserID == _userId);
                entity.PersonId = model.PersonId;
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.Role = model.Role;
                entity.DateJoined = model.DateJoined;
                entity.UserID = _userId;

                return ctx.SaveChanges() == 1;

            }
        }
        public bool DeleteUser(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.PersonId == id && e.UserID == _userId);
                ctx.Users.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}