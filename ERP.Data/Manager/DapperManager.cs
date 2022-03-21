using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Configuration;
using ERP.Application.Interface;
using System.Reflection;
using ERP.Data.Interface;
using ERP.Core.Utilities;

namespace ERP.Application.Manager.DapperManager
{
    // public class DapperManager<T> : IDapperManage<T> where T : class //EntityBase, IAggregateRoot

    public interface IDapperService<TEntity> where TEntity : class
    {
        void UpdateSQL(TEntity entity);
    }

    public class DapperManager 
    {

        private string connectionString = "";

        public DapperManager(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public IDbConnection _Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

     
        #region Internal Operations

        public void InsertQuery(string spName, DynamicParameters queryParameters)
        {
            try
            {
                using (IDbConnection db = _Connection)
                {
                    db.Open();
                    db.Execute(spName, queryParameters, commandType: CommandType.StoredProcedure);

                }
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Error occured during InsertQuery method : {0}", ex.Message), ex);
            }
            
        }
        public int InsertQueryAndGetId(string spName, DynamicParameters queryParameters)
        {
            int Id = 0;
            try
            {
              
                using (IDbConnection db = _Connection)
                {
                    db.Open();
                    Id =  db.Execute(spName, queryParameters, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error occured during InsertQuery method : {0}", ex.Message), ex);
            }
            return Id;
        }

        public void DeleteRecord(string spName, DynamicParameters queryParameters)
        {
            try
            {
                using (IDbConnection db = _Connection)
                {
                    db.Open();
                    db.Execute(spName, queryParameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error occured during DeleteRecord method : {0}", ex.Message), ex);
            }
           
        }

        public void DeleteRecordByQuery(string tableName, string deleteId,int Id)
        {
            using (IDbConnection db = _Connection)
            {
                string deleteQuery = "DELETE FROM " + tableName + " WHERE " + deleteId + "=" + Id;
                db.Open();
                db.Execute(deleteQuery);
              
            }
        }

        public void UpdateRecord(string spName, DynamicParameters queryParameters)
        {
            try
            {
                using (IDbConnection db = _Connection)
                {
                    db.Open();
                    db.Execute(spName, queryParameters, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error occured during UpdateRecord method : {0}", ex.Message), ex);
            }
           
        }

        public async Task<T>  QueryFirstOrDefault<T>(T model, string spName, DynamicParameters queryParameters)
        {
            try
            {
                using (IDbConnection db = _Connection)
                {
                    db.Open();
                    return  db.Query<T>(spName, queryParameters, commandType: CommandType.StoredProcedure).FirstOrDefault(); ;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error occured during QueryFirstOrDefault method : {0}", ex.Message), ex);
            }

        }

        public async Task<IEnumerable<T>> QueryList<T>(T model, string spName, DynamicParameters queryParameters)
        {
            try
            {
                using (IDbConnection db = _Connection)
                {
                    db.Open();
                    return db.Query<T>(spName, queryParameters, commandType: CommandType.StoredProcedure).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error occured during QueryList method : {0}", ex.Message), ex);
            }

        }

        public  IEnumerable<T> QueryListWithoutTask<T>(T model, string spName, DynamicParameters queryParameters)
        {
            try
            {
                using (IDbConnection db = _Connection)
                {
                    db.Open();
                    return db.Query<T>(spName, queryParameters, commandType: CommandType.StoredProcedure).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error occured during QueryList method : {0}", ex.Message), ex);
            }

        }


        public virtual IEnumerable<T> FindDataByID<T>(int id, string tableName, DynamicParameters queryParameters) 
        {
            IEnumerable<T> items = null;
            using (IDbConnection cn = _Connection)
            {
                cn.Open();
                items = cn.Query  (tableName, queryParameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return items;
            }
         }


        public IEnumerable<T> FindByID<T>(string filter, object parameters, string tableName)
        {
            IEnumerable<T> result;
            try
            {
                using (IDbConnection cn = _Connection)
                {
                    result = cn.Query<T>("SELECT * FROM " + tableName + " WHERE " + filter, parameters);
                }
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
         }

        public virtual IEnumerable<T> FindAll_SQL<T>(string tableName)
        {
            IEnumerable<T> items = null;

            using (IDbConnection cn = _Connection)
            {
                cn.Open();
                items = cn.Query<T>("SELECT * FROM " + tableName);
            }

            return items;
        }

        #endregion



    }
}
