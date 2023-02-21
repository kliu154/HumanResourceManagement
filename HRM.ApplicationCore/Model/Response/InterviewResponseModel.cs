using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Response
{
    public class InterviewResponseModel
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public string InterviewRound { get; set; }
        public int InterviewTypeId { get; set; }
        public int InterviewStatusId { get; set; }
        public int InterviewerId { get; set; }
    }
}
