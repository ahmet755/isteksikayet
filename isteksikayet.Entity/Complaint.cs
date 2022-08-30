using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isteksikayet.Entity
{
    public class Complaint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileUrl { get; set; }
        public bool Approval { get; set; }
        public int  DepartmentId { get; set; }
        public Department Department { get; set; }
        public ComplaintReply ComplaintReply { get; set; }
    }
}
