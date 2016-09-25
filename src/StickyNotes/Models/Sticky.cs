using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StickyNotes.Models
{
    public class Sticky

    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Text { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

    }
}
