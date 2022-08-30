using isteksikayet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isteksikayet.Business.Abstract
{
    public interface IComplaintReplyService
    {
        void Create(ComplaintReply t);
        void Update(ComplaintReply t);
        List<ComplaintReply> GetAll();
        ComplaintReply GetById(int Id);
        void Delete(ComplaintReply t);
    }
}
