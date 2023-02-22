using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Response
{
    public class FeedbackResponseModel
    {
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public string Description { get; set; }
        public string ABBR { get; set; }
    }
}
