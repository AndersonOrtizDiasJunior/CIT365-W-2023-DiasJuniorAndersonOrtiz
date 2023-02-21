using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MyScriptureJournal.Models
{
        public class Entry
        {
            public int Id { get; set; }

            [StringLength(60, MinimumLength = 2)]
            [Required]
            public string Book { get; set; } = string.Empty;


        public int Chapter { get; set; }

            public string Verses { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;

        [StringLength(500, MinimumLength = 2)]
            [Required]
            public string Annotation { get; set; } = string.Empty;
        }
}

