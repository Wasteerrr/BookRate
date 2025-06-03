using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{  
    [Table("Reads")]
    public class Read
    {
        public string AppUserId { get; set; }  
        public int BookId { get; set; }
        public AppUser AppUser { get; set; }   
        public Book Book { get; set; }
    }
}