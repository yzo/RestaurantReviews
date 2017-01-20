using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Dining.DAL;
using Dining.Models;

namespace Dining.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<Dining.DAL.DiningContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DiningContext context)
        {
            context.dining_restaurants.AddOrUpdate(
                     r => r.name,
                     new Restaurant
                     {
                         name = "Alby's Cafe",
                         city ="Pittsburgh",
                         state = "PA"
                     },
                     new Restaurant
                     {
                         name = "Peter's Cafe",
                         city = "New York",
                         state ="NY"
                     },
                     new Restaurant
                     {
                         name = "Young's Pizzeria",
                         city = "Baltimore",
                         state = "MD"
                     }
                );
            context.dining_restaurant_reviews.AddOrUpdate(
                   new Restaurant_Review
                   {
                        user_name = "Alex",
                        rating = 4,
                        comment = "Great place!",                         
                        restaurant_Id = 1
                   },
                   new Restaurant_Review
                   {
                       user_name = "Alex",
                       rating = 2,
                       comment = "Great location!",
                       restaurant_Id = 2
                   },
                   new Restaurant_Review
                   {
                       user_name = "Alex",
                       rating = 3,
                       comment = "Good home cooking!",
                       restaurant_Id = 3
                   },
                   new Restaurant_Review
                   {
                       user_name = "Toby",
                       rating = 2,
                       comment = "Do not eat here!",
                       restaurant_Id = 2
                   },
                   new Restaurant_Review
                   {
                       user_name = "Toby",
                       rating = 5,
                       comment = "Highly enjoyed all the food!",
                       restaurant_Id = 1
                   },
                   new Restaurant_Review
                   {
                       user_name = "Toby",
                       rating = 3,
                       comment = "Average service!",
                       restaurant_Id = 3
                   },

                   new Restaurant_Review
                   {
                       user_name = "Mac",
                       rating = 5,
                       comment = "Excellent cuisine!",
                       restaurant_Id = 3
                   },
                   new Restaurant_Review
                   {
                       user_name = "Mac",
                       rating = 2,
                       comment = "Food too greasy!",
                       restaurant_Id = 2
                   },

                   new Restaurant_Review
                   {
                       user_name = "Mac",
                       rating = 3,
                       comment = "So much food given!",
                       restaurant_Id = 1
                   }
                );
            context.SaveChanges();
            //  this method will be called after migrating to the latest version.

            //  you can use the dbset<t>.addorupdate() helper extension method 
            //  to avoid creating duplicate seed data. e.g.
            //
            //    context.people.addorupdate(
            //      p => p.fullname,
            //      new person { fullname = "andrew peters" },
            //      new person { fullname = "brice lambson" },
            //      new person { fullname = "rowan miller" }
            //    );
            //
        }
    }
}
