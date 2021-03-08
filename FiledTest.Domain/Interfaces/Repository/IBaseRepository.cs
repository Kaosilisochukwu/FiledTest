using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiledTest.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T>
    {
        Task<int> SaveData(T t);
        Task<T> GetData(int id);
        Task<int> UpdateData(T t);
    }
}
