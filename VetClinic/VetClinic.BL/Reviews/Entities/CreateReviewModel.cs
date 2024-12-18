using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.BL.Reviews.Entities
{
    public class CreateReviewModel
    {
        public int ClientID { get; set; }
        public int AdminID { get; set; }
        public string Description { get; set; }
        public DateTime DateWriting { get; set; }
    }
}
