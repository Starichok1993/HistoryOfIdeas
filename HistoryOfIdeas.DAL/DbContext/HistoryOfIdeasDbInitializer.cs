﻿using System.Data.Entity;
using System.Web.Helpers;
using HistoryOfIdeas.DAL.Entity;

namespace HistoryOfIdeas.DAL.DbContext
{
    public class HistoryOfIdeasDbInitializer:DropCreateDatabaseAlways<HistoryOfIdeasContext>
    {
        //create and initialization database
        protected override void Seed(HistoryOfIdeasContext context)
        {
            base.Seed(context);

            context.Users.Add(new User
            {
                Name = "Alex",
                Surname = "Star",
                Email = "star@n1.by",
                Password = Crypto.HashPassword("123123")
            });

            context.SaveChanges();
        }
    }
}
