using CustomWebApi.Tool;
using System;
using PetaPoco;
using PetaPoco.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomWebApi.Repository
{
    //数据库交互
    public class CustomRepository : ICustomRepository
    {
        private static string connectionString = "Server=127.0.0.1;Database=UserManege;Uid=sa;Pwd=123456";
        IDatabase db = DatabaseConfiguration.Build()
            .UsingCommandTimeout(60)
            .WithAutoSelect()
            .WithNamedParams()
            .UsingConnectionString(connectionString)
            .UsingProvider<SqlServerDatabaseProvider>().Create();
        public Object AddData<T>(T t)
        {
          var result =  db.Insert(t);
            return result;
        }

        public int DeleteById<T>(int id)
        {
          int result =  db.Delete<T>(id);
            return result;
        }

        public List<T> SelectAllData<T>()
        {
           List<T> tList = db.Fetch<T>();
           return tList;
        }


        public T SelectById<T>(int id)
        {
            T t = db.SingleOrDefault<T>(id);
            return t;
        }

        public List<T> SelectByQueryClass<T>(long page, long itemsPerPage, Sql sql)
        {

            List<T> list =  db.Fetch<T>(page,itemsPerPage, sql);
            return list;
        }

        public int UpdateData<T>(T t, int id)
        {
           int result = db.Update(t,id);
            return result;
        }
    }
}
