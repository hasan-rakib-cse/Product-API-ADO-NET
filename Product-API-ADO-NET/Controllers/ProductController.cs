using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_API_ADO_NET.Model;
using System.Data;
using System.Data.SqlClient;

namespace Product_API_ADO_NET.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                SqlCommand cmd = new SqlCommand("Insert into Products values ('" + obj.ProductName + "','" + obj.ShortDescription + "','" + obj.LongDescription + "','" + obj.ProductCode + "','" + obj.SalePrice + "','" + obj.Weight + "','" + obj.Unit + "','" + obj.Brand + "','" + obj.ProductWarranty + "','" + obj.VAT + "',getdate())", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("ReadProduct")]
        [HttpGet]
        public async Task<IActionResult> ReadProduct()
        {
            List<Product> products = new List<Product>();

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("SELECT * FROM Products", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            for(int i = 0; i<dt.Rows.Count; i++)
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                product.ProductName = dt.Rows[i]["ProductName"].ToString();
                product.ShortDescription = dt.Rows[i]["ShortDescription"].ToString();
                product.LongDescription = dt.Rows[i]["LongDescription"].ToString();
                product.ProductCode = dt.Rows[i]["ProductCode"].ToString();
                product.SalePrice = Convert.ToDecimal(dt.Rows[i]["SalePrice"]);
                product.Weight = Convert.ToDecimal(dt.Rows[i]["Weight"]);
                product.Unit = dt.Rows[i]["Unit"].ToString();
                product.Brand = dt.Rows[i]["Brand"].ToString();
                product.ProductWarranty = Convert.ToInt32(dt.Rows[i]["ProductWarranty"]);
                product.VAT = Convert.ToDecimal(dt.Rows[i]["VAT"]);
                product.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CreatedDate"]);
                products.Add(product);
            }
            return Ok(products);
        }

        [Route("UpdateProduct")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                SqlCommand cmd = new SqlCommand("Update Products set ProductName='" + obj.ProductName + "',ShortDescription='" + obj.ShortDescription + "',LongDescription='" + obj.LongDescription + "',ProductCode='" + obj.ProductCode + "',SalePrice='" + obj.SalePrice + "',Weight='" + obj.Weight + "',Unit='" + obj.Unit + "',Brand='" + obj.Brand + "',ProductWarranty='" + obj.ProductWarranty + "',VAT='" + obj.VAT + "' where id='" + obj.Id + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return Ok(obj);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Route("DeleteProduct")]
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Product obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                SqlCommand cmd = new SqlCommand("delete from Products where id='" + obj.Id + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
