using isteksikayet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isteksikayet.Data.Abstract
{
    public interface IComplaintRepository:IGenericRepository<Complaint>
    {
        List<Complaint> GetComplaintDepartment();
        Complaint GetComlaintDepartById(int id);
    }
}
