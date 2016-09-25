using StickyNotes.Infrastrucutre;
using StickyNotes.Models;
using StickyNotes.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickyNotes.Services
{
    public class StickyService
    {

        private StickyRepository _sRepo;
        private UserRepository _uRepo;

        public StickyService(StickyRepository sr, UserRepository ur)
        {

            _sRepo = sr;
            _uRepo = ur;
        }


        public IList<StickyDTO> GetStickies(string user)
        {

            return (from s in _sRepo.GetStickiesForUser(user)
                    select new StickyDTO()
                    {   Id=s.Id,
                        DateCreated = s.DateCreated,
                        Text = s.Text

                    }).ToList();

        }

        public void AddSticky(StickyDTO sticky, string currentUser)
        {
            Sticky dbSticky = new Sticky()
            {
                Id = sticky.Id,
                DateCreated = sticky.DateCreated,
                Text = sticky.Text,
                UserId = _uRepo.GetUser(currentUser).First().Id


            };


            _sRepo.Add(dbSticky);

        }
         public void DeleteSticky(StickyDTO sticky, string currentUser)
        {
            _sRepo.Delete(_sRepo.GetStickyById(sticky.Id, currentUser).First(), currentUser);
        }
    }
}
