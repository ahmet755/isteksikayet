using isteksikayet.Business.Abstract;
using isteksikayet.Data.Abstract;
using isteksikayet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isteksikayet.Business.Concrete
{
    public class ComplaintReplyManager:IComplaintReplyService
    {
        private IComplaintReplyRepository _ComplaintReply;
        public ComplaintReplyManager(IComplaintReplyRepository ComplaintReply)
        {
            _ComplaintReply = ComplaintReply;
        }
        public void Create(ComplaintReply t)
        {
            _ComplaintReply.Create(t);
        }

        public void Delete(ComplaintReply t)
        {
            _ComplaintReply.Delete(t);
        }

        public List<ComplaintReply> GetAll()
        {
            return _ComplaintReply.GetAll();
        }

        public ComplaintReply GetById(int Id)
        {
            return _ComplaintReply.GetById(Id);
        }

        public void Update(ComplaintReply t)
        {
            _ComplaintReply.Update(t);
        }
    }
}
