using isteksikayet.Data.Abstract;
using isteksikayet.Data.Context;
using isteksikayet.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isteksikayet.Data.Concrete
{
    public class EfComplaintepository : EfGenericRepository<Complaint, DataContext>, IComplaintRepository
    {
        public Complaint GetComlaintDepartById(int id)
        {
            using (var db = new DataContext())
            {
                return db.Complaints.Where(i=>i.Id == id).Include(i => i.Department).Include(i=>i.ComplaintReply).FirstOrDefault();
            }
        }

        public List<Complaint> GetComplaintDepartment()
        {
            using (var db = new DataContext())
            {
                return db.Complaints.Include(i => i.Department).ToList();
            }
        }
    }
}
