using StickyNotes.Data;
using StickyNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickyNotes.Infrastrucutre
{
    public class StickyRepository
    {
        public ApplicationDbContext _db;

        public StickyRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Sticky> GetStickiesForUser(string user)
        {

            return from s in _db.Stickes
                   where s.User.UserName == user
                   select s;


        }

        public IQueryable<Sticky> GetStickyById(int id, string user)
        {

            return from s in _db.Stickes 
                   where s.Id == id && s.User.UserName == user
                   select s;

        }

        public void Add(Sticky sticky)
        {
            sticky.DateCreated = DateTime.Now;

            _db.Stickes.Add(sticky);
            _db.SaveChanges();

        }

        public void Delete(Sticky sticky, string user)
        {
           

            _db.Stickes.Remove(sticky);
            _db.SaveChanges();
        }

    }
}
