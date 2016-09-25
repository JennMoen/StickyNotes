using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickyNotes.Services.Models
{
    public class StickyDTO
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Text { get; set; }

        public string User { get; set; }
    }
}
