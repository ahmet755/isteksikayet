using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isteksikayet.Data.Abstract
{
    public interface IGenericRepository<T>
    {
        void Create(T t);
        void Update(T t);
        List<T> GetAll();
        T GetById(int Id);
        void Delete(T t);
    }
}
