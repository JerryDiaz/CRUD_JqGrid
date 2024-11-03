using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Dapper;
using WebApplication3.Models;

namespace WebApplication3
{
    public class ConnectionDB : IDisposable
    {
        private static string cnDB = "Data Source=localhost;User ID=julio.barquero;Password=Force2024*;Initial Catalog=CF_COMMERCE; Persist Security Info=True;Pooling=true;Min Pool Size=30;Max Pool Size=150; Connection Timeout=60;Connection Lifetime=30; Application name = store-api;";

        public void Dispose()
        {

        }

        public List<Producto> Productos(Producto pr)
        {
            try
            {
                using (var _db = new SqlConnection(cnDB))
                {
                    return _db.Query<Producto>(ObjsDB.SP_PRODUCT_LIST, new
                    {
                        //pr.User
                    }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Producto ProductoCrear(Producto pr)
        {
            try
            {
                using (var _db = new SqlConnection(cnDB))
                {
                    return _db.Query<Producto>(ObjsDB.SP_PRODUCT_ADD, new
                    {
                        pr.User,
                        pr.Description,
                        pr.CategoryCode
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Producto ProductoUpdate(Producto pr)
        {
            try
            {
                using (var _db = new SqlConnection(cnDB))
                {
                    return _db.Query<Producto>(ObjsDB.SP_PRODUCT_EDIT, new
                    {
                        pr.Id,
                        pr.User,
                        pr.Description,
                        pr.CategoryCode
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Producto ProductoDeactivate(Producto pr)
        {
            try
            {
                using (var _db = new SqlConnection(cnDB))
                {
                    return _db.Query<Producto>(ObjsDB.SP_PRODUCT_DEACTIVATE, new
                    {
                        pr.Id,
                        pr.User
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}