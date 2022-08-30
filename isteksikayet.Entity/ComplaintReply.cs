using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isteksikayet.Entity
{
    public class ComplaintReply
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ComplaintId { get; set; }
        public Complaint Complaint { get; set; }
    }
}
