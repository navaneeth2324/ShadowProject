using CustomerAppDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerAppDAL
{
    public class CustomerAppDALayer
    {
        SqlConnection conObj;
        string conStr = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString;
        public CustomerAppDALayer()
        {
            conObj = new SqlConnection(conStr);
        }
        public List<ProductDTO> ViewProducts()
        {

            List<ProductDTO> lstProducts = new List<ProductDTO>();


            SqlConnection conObj = new SqlConnection();
            conObj.ConnectionString = conStr;

            SqlCommand queryObj = new SqlCommand();
            queryObj.CommandText = @"SELECT TOP (1000) [Sl],[ProductName],[ProductPrice] FROM [CustomerApp].[dbo].[Product]";
            queryObj.CommandType = System.Data.CommandType.Text;
            queryObj.Connection = conObj;

            try
            {
                conObj.Open();
                SqlDataReader prod = queryObj.ExecuteReader();
                while (prod.Read())
                {
                    lstProducts.Add(new ProductDTO()
                    {
                        Sl=prod["Sl"].ToString(),
                         ProductName=prod["ProductName"].ToString(),
                         ProductPrice= (int)prod["ProductPrice"],
                    }
                    );
                }
                return lstProducts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AddProduct(ProductDTO p)
        {
            SqlConnection conObj = new SqlConnection();
            conObj.ConnectionString = conStr;
            try
            {

                SqlCommand queryobj = new SqlCommand();
                queryobj.CommandText = @"usp_AddProduct";
                queryobj.CommandType = System.Data.CommandType.StoredProcedure;
                queryobj.Connection = conObj;
                queryobj.Parameters.AddWithValue("@Sl",p.Sl);
                queryobj.Parameters.AddWithValue("@name", p.ProductName);
                queryobj.Parameters.AddWithValue("@price",p.ProductPrice);
                SqlParameter preturn = new SqlParameter();
                preturn.Direction = System.Data.ParameterDirection.ReturnValue;
                preturn.SqlDbType = SqlDbType.Int;
                queryobj.Parameters.Add(preturn);

                conObj.Open();
                queryobj.ExecuteNonQuery();

                return Convert.ToInt32(preturn.Value);
            }

            catch (Exception e) { throw e; }
            finally { conObj.Close(); }
        }
        public int EditProduct(ProductDTO p)
        {
            SqlConnection conObj = new SqlConnection();
            conObj.ConnectionString = conStr;
            try
            {
                SqlCommand queryobj = new SqlCommand();
                queryobj.CommandText = @"usp_UpdateProduct";
                queryobj.CommandType = System.Data.CommandType.StoredProcedure;
                queryobj.Connection = conObj;
                queryobj.Parameters.AddWithValue("@Sl", p.Sl);
                queryobj.Parameters.AddWithValue("@name", p.ProductName);
                queryobj.Parameters.AddWithValue("@price", p.ProductPrice);
                SqlParameter preturn = new SqlParameter();
                preturn.Direction = System.Data.ParameterDirection.ReturnValue;
                preturn.SqlDbType = SqlDbType.Int;
                queryobj.Parameters.Add(preturn);

                conObj.Open();
                queryobj.ExecuteNonQuery();

                return Convert.ToInt32(preturn.Value);
            }


            catch (Exception e) { throw e; }
            finally { conObj.Close(); }
        }

        public int DeleteProduct(int sl)
        {
            SqlConnection conObj = new SqlConnection();
            conObj.ConnectionString = conStr;
            try
            {
                SqlCommand queryobj = new SqlCommand();
                queryobj.CommandText = @"usp_DeleteProduct";
                queryobj.CommandType = System.Data.CommandType.StoredProcedure;
                queryobj.Connection = conObj;
                SqlParameter preturn = new SqlParameter();
                preturn.ParameterName = "@sl";
                preturn.Value = sl;
                preturn.Direction = System.Data.ParameterDirection.ReturnValue;
                preturn.SqlDbType = SqlDbType.Int;
                queryobj.Parameters.Add(preturn);

                conObj.Open();
                queryobj.ExecuteNonQuery();

                return Convert.ToInt32(preturn.Value);
            }


            catch (Exception e) { throw e; }
            finally { conObj.Close(); }
        }
    }
}
