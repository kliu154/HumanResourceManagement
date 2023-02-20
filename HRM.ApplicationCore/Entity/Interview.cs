using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Entity
{
    public class Interview
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public DateTime InterviewDate { get; set; }

        [Column(TypeName = "varchar")]
        public string InterviewRound { get; set; }
        public int InterviewTypeId { get; set; }
        public int InterviewStatusId { get; set; }
        public int InterviewerId { get; set; }

        // navigational properties
        public Employee Employee { get; set; }
    }
}
