using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Entity
{
    public class Feedback
    {
        public int Id { get; set; }
        public int InterviewId { get; set; }

        [Column(TypeName = "varchar(400)")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(400)")]
        public string ABBR { get; set; }

        // navigational properties
        public Interview Interview { get; set; }
    }
}
