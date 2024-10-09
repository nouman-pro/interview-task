using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SYS_Logins
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LoginId { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public int? Pin { get; set; }



        public virtual SYS_Users? Users { get; set; }
    }
}
