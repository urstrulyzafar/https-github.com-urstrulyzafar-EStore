using OnlineShoppingStore.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace OnlineShoppingStore.DAL
{
    public class ProductServices
    {   
        
        //connection

        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);

        //Get Data
        public List<ProductModel> GetData()
        {
            List<ProductModel> productlist = new List<ProductModel>();
            SqlCommand cmd = new SqlCommand("SP_GetAllProduct", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adp.Fill(dt);


            foreach(DataRow dr in dt.Rows)
            {
                productlist.Add(new ProductModel
                {
                   Id=Convert.ToInt32(dr[0]),
                   ProductName=Convert.ToString(dr[1]),
                   ProductDiscription=Convert.ToString(dr[2]),
                   ProductRating=Convert.ToString(dr[3]),
                   ProductImage=Convert.ToString(dr[4]),
                   ProductType=Convert.ToString(dr[5]),
                   Price=Convert.ToDecimal(dr[6])
                });
            }
            return productlist;
        }





        //Add 
        public bool Add(ProductModel obj)
        {
            SqlCommand cmd = new SqlCommand("SP_CreateNewProduct",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", obj.ProductName);
            cmd.Parameters.AddWithValue("@ProductDiscription", obj.ProductDiscription);
            cmd.Parameters.AddWithValue("@ProductRating", obj.ProductRating);
            cmd.Parameters.AddWithValue("@ProductImage", obj.ProductImage);
            cmd.Parameters.AddWithValue("@ProductType", obj.ProductType);
            cmd.Parameters.AddWithValue("@Price", obj.Price);

            if (con.State == ConnectionState.Closed)
                con.Open();

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Update
        public bool Update(ProductModel obj)
        {
            SqlCommand cmd = new SqlCommand("SP_UpdateProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductName", obj.ProductName);
            cmd.Parameters.AddWithValue("@ProductDiscription", obj.ProductDiscription);
            cmd.Parameters.AddWithValue("@ProductRating", obj.ProductRating);
            cmd.Parameters.AddWithValue("@ProductImage", obj.ProductImage);
            cmd.Parameters.AddWithValue("@ProductType", obj.ProductType);
            cmd.Parameters.AddWithValue("@Price", obj.Price);

            if (con.State == ConnectionState.Closed)
                con.Open();

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool Del(ProductModel obj)
        {
            SqlCommand cmd = new SqlCommand("SP_DeleteProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", obj.Id);
            

            if (con.State == ConnectionState.Closed)
                con.Open();

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}