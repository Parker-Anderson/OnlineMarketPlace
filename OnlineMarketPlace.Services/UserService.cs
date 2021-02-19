﻿using OnlineMarketPlace.Data;
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
                    UserRole = model.UserRole,
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
                            ID = e.ID,
                            Name = e.Name,
                            Email = e.Email,
                            UserRole = e.UserRole,
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
                        .Single(e => e.ID == id && e.UserID == _userId);
                return
                    new UserDetail
                    {
                        UserId = entity.ID,
                        Name = entity.Name,
                        Email = entity.Email,
                        DateJoined = entity.DateJoined,
                        UserRole = entity.UserRole
                    };
            }
        }
        public bool UpdateUser(UserEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.ID == model.ID && e.UserID == _userId);
                entity.ID = model.ID;
                entity.Name = model.Name;
                entity.Email = model.Email;
                entity.UserRole = model.UserRole;

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
                        .Single(e => e.ID == id && e.UserID == _userId);
                ctx.Users.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}