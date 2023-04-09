using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentations.Data;

namespace Presentations
{
    public class EntityFrameworkExample
    {
        public void SelectStatement()
        {
            using UserContext context = new UserContext();

            List<User> users = context.Users.ToList();
            foreach (User user in users)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }
        }

        public void UpdateStatement()
        {
            using UserContext context = new UserContext();

            context.Users.Add(new User { FirstName = "John", LastName = "Doe" });
            context.SaveChanges();
        }

        public void UpdateStatementWithTransaction()
        {
            using UserContext context = new UserContext();
            using DbContextTransaction transaction = context.Database.BeginTransaction();

            try
            {
                context.Users.Add(new User { FirstName = "John", LastName = "Doe" });
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public void DeleteStatement()
        {
            using UserContext context = new UserContext();

            User user = context.Users.FirstOrDefault(u => u.FirstName == "John");
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
    }
}
