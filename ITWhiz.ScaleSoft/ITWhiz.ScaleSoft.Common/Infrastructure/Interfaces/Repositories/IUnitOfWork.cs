using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.Common.Infrastructure.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IDbConnection Connection { get; set; }
        IDbTransaction Transaction { get; set; }

        void Open();
        void Close();
        void Begin();
        void Commit();
        void Rollback();
    }
}
