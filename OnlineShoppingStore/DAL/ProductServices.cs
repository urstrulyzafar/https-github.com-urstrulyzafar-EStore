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
        public string connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;


        public IList<ProductModel> GetProductList()
        {
            IList<ProductModel> getList = new List<ProductModel>();
            _ds = new DataSet();

            using(SqlConnection conn=new SqlConnection("connect"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("ProductViewOrinsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetProductList");

                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);

                if (_ds.Tables.Count > 0)
                {
                    for(int i=0;i<_ds.Tables[0].Rows.Count;i++)
                    {
                        ProductModel obj = new ProductModel();
                        obj.Id = Convert.ToInt32(_ds.Tables[0].Rows[i]["Id"]);
                        obj.ProductName = Convert.ToString(_ds.Tables[0].Rows[i]["ProductName"]);
                        obj.ProductDiscription= Convert.ToString(_ds.Tables[0].Rows[i]["ProductDiscription"]);
                        obj.ProductRating= Convert.ToString(_ds.Tables[0].Rows[i]["ProductRating"]);
                        obj.ProductImage= Convert.ToString(_ds.Tables[0].Rows[i]["ProductImage"]);
                        obj.ProductType= Convert.ToString(_ds.Tables[0].Rows[i]["ProductType"]);
                        obj.Price = Convert.ToDecimal(_ds.Tables[0].Rows[i]["Price"]);


                        getList.Add(obj);
                    }

                }



            }

            return getList;
        }

        public void InsertProduct(ProductModel model)
        {
            using(SqlConnection conn=new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand("ProductViewOrinsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddProduct");
                cmd.Parameters.AddWithValue("@ProductName", model.ProductName);
                cmd.Parameters.AddWithValue("@ProductDiscription", model.ProductDiscription);
                cmd.Parameters.AddWithValue("@ProductRating", model.ProductRating);
                cmd.Parameters.AddWithValue("@ProductImage", model.ProductImage);
                cmd.Parameters.AddWithValue("@ProductType", model.ProductType);
                cmd.Parameters.AddWithValue("@Price", model.Price);
                cmd.ExecuteNonQuery();

            }
        }


        public ProductModel GetEditById(int Id)
        {
            var model = new ProductModel();

            using(SqlConnection conn=new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("ProductViewOrinsert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetProductById");
                cmd.Parameters.AddWithValue("@ProdId", Id);
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);

                if(_ds.Tables.Count>0 && _ds.Tables[0].Rows.Count>0)
                {
                    model.Id = Convert.ToInt32(_ds.Tables[0].Rows[0]["Id"]);
                    model.ProductName = Convert.ToString(_ds.Tables[0].Rows[0]["ProductName"]);
                    model.ProductDiscription= Convert.ToString(_ds.Tables[0].Rows[0]["ProductDiscription"]);
                    model.ProductRating= Convert.ToString(_ds.Tables[0].Rows[0]["ProductRating"]);
                    model.ProductImage= Convert.ToString(_ds.Tables[0].Rows[0]["ProductImage"]);
                    model.ProductType= Convert.ToString(_ds.Tables[0].Rows[0]["ProductType"]);
                    model.Price= Convert.ToDecimal(_ds.Tables[0].Rows[0]["Price"]);
                }
            }






            return model;
        }
    }
}