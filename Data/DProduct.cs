using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class DProduct
    {
        public List<Product> listProductsActivate()
        {
            string comandText = string.Empty;
            List<Product> products = null;
            try
            {
                comandText = "USP_ListProduct";
                products = new List<Product>();
                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, comandText,
                    CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductID = reader["productID"] == null ? 0 : Convert.ToInt32(reader["productID"]),
                            ProductName = reader["productName"] == null ? string.Empty : Convert.ToString(reader["productName"]),
                            ProductInventory = reader["productInventory"] == null ? 0 : Convert.ToInt32(reader["productInventory"]),
                            ProductExpiration = reader["productExpiration"] == null ? DateTime.MinValue : Convert.ToDateTime(reader["productExpiration"]),
                            ProductRegistered = reader["productRegistered"] == null ? DateTime.MinValue : Convert.ToDateTime(reader["productRegistered"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("listProducts exeption: " + ex);
                throw ex;
            }
            return products;
        }

        public List<Product> listProductsDesactivate()
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<Product> products = null;
            try
            {
                comandText = "USP_ListProductDesactivate";
                products = new List<Product>();
                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, comandText,
                    CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductID = reader["productID"] == null ? 0 : Convert.ToInt32(reader["productID"]),
                            ProductName = reader["productName"] == null ? string.Empty : Convert.ToString(reader["productName"]),
                            ProductInventory = reader["productInventory"] == null ? 0 : Convert.ToInt32(reader["productInventory"]),
                            ProductExpiration = reader["productExpiration"] == null ? DateTime.MinValue : Convert.ToDateTime(reader["productExpiration"]),
                            ProductRegistered = reader["productRegistered"] == null ? DateTime.MinValue : Convert.ToDateTime(reader["productRegistered"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("listProducts exeption: " + ex);
                throw ex;
            }
            return products;
        }

        public void insertProduct(Product product)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_InsertProduct";
                parameters = new SqlParameter[4];
                parameters[0] = new SqlParameter("@productName", SqlDbType.VarChar);
                parameters[0].Value = product.ProductName;
                parameters[1] = new SqlParameter("@productInventory", SqlDbType.Int);
                parameters[1].Value = product.ProductInventory;
                parameters[2] = new SqlParameter("@productExpiration", SqlDbType.Date);
                parameters[2].Value = product.ProductExpiration;
                parameters[3] = new SqlParameter("@productRegistered", SqlDbType.DateTime);
                parameters[3].Value = product.ProductRegistered;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("insertProduct exeption: " + ex);
                throw ex;
            }
        }

        public void desactivateProduct(Product product)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_DesactiveProduct";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@productID", SqlDbType.Int);
                parameters[0].Value = product.ProductID;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("desactivateProduct exeption: " + ex);
                throw ex;
            }
        }

        public void activateProduct(Product product)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_ActiveProduct";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@productID", SqlDbType.Int);
                parameters[0].Value = product.ProductID;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("activateProduct exeption: " + ex);
                throw ex;
            }
        }

        public void updateProduct(Product product)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_UpdateProduct";
                parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@productID", SqlDbType.Int);
                parameters[0].Value = product.ProductID;
                parameters[1] = new SqlParameter("@productName", SqlDbType.VarChar);
                parameters[1].Value = product.ProductName;
                parameters[2] = new SqlParameter("@productInventory", SqlDbType.Int);
                parameters[2].Value = product.ProductInventory;
                parameters[3] = new SqlParameter("@productExpiration", SqlDbType.Date);
                parameters[3].Value = product.ProductExpiration;
                parameters[4] = new SqlParameter("@productRegistered", SqlDbType.DateTime);
                parameters[4].Value = product.ProductRegistered;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("updateProduct exeption: " + ex);
                throw ex;
            }
        }

        public void deleteProduct(Product product)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_DeleteProduct";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@productID", SqlDbType.Int);
                parameters[0].Value = product.ProductID;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("deleteProduct exeption: " + ex);
                throw ex;
            }
        }


    }
}
