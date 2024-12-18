using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DataAccess.Entities;

namespace VetClinic.BL.Reviews.Entities
{
    public class ReviewModel
    {
        public Guid Id { get; set; }
        public int ClientID { get; set; }
        public int AdminID { get; set; }
        public string Description { get; set; }
        public DateTime DateWriting { get; set; }
    }
}
