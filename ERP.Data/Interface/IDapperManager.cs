using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Data.Interface
{
    public interface IDapperManage<TEntity> where TEntity : class
    {
        TEntity FindDataByID(int id, string spName, DynamicParameters queryParameters);

        IEnumerable<TEntity> FetchAll();

    }
}
