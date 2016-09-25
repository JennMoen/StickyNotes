using StickyNotes.Data;
using StickyNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickyNotes.Infrastrucutre
{
    public class UserRepository
    {

        private ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;


        }


        public IQueryable<ApplicationUser> GetUser(string id)
        {

            return from u in _db.Users
                   where u.UserName == id
                   select u;

        }
    }
}
