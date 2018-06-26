using ITWhiz.ScaleSoft.Common.Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbTransaction _Transaction;

        public UnitOfWork(IDbConnection connection)
        {
            Connection = connection;
        }

        public IDbConnection Connection{ get;set;}

        public IDbTransaction Transaction
        {
            get
            {
                return _Transaction;
            }

            set
            {
                _Transaction = value;
            }
        }

        public void Begin()
        {
           _Transaction = Connection.BeginTransaction();
        }

        public void Close()
        {
            Connection.Close();
        }

        public void Commit()
        {
            _Transaction.Commit();
        }

        public void Open()
        {
            Connection.Open();
        }

        public void Rollback()
        {
            _Transaction.Rollback();
        }
    }
}
