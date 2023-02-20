using DotStarkProjectBLL.Interface;
using DotStarkProjectBLL.SPWorks;
using DotStarkProjectData.Context;
using DotStarkProjectData.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Text.Json.Serialization;
using static DotStarkProjectData.Model.CommonModel;

namespace DotStarkProjectBLL.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ISPWorks _iSPWorks;
        public ProductRepository(ApplicationDbContext context, IConfiguration configuration, ISPWorks iSPWorks)
        {
            _context = context;
            _configuration = configuration;
            _iSPWorks = iSPWorks;
        }

        public string GetTime()
        {
            string? ServerDBTime = string.Empty;
            try
            {
                var res = _iSPWorks.SP_GetTime();
                ServerDBTime = Convert.ToDateTime(res).ToString("yyyy-MM-dd HH:mm:ss:m");

            }
            catch (Exception)
            {

            }
            return ServerDBTime;
        }

        public CommonModel.ApplicationTransaction SaveProduct(Products model)
        {
            ApplicationTransaction transaction = new ApplicationTransaction();
            transaction.IsSuccess = false;
            try
            {
                _context.Add(model);
                if (_context.SaveChanges() > 0)
                {
                    transaction.IsSuccess = true;
                    transaction.StatusCode = 200;
                }
            }
            catch (Exception ex)
            {
                transaction.IsSuccess = false;
                transaction.Message = ex.Message;
                transaction.StatusCode = 400;
            }
            return transaction;
        }

        public (List<ProductModel>, ApplicationTransaction) GetProductList()
        {
            List<ProductModel> products = new List<ProductModel>();
            ApplicationTransaction transaction = new ApplicationTransaction();
            transaction.IsSuccess = false;
            try
            {
                products = _context.Products.Select(x => new ProductModel
                {
                    id = x.id,
                    ProductId = x.ProductId,
                    ProductName = x.ProductName
                }).ToList();
                transaction.IsSuccess = true;
            }
            catch (Exception ex)
            {
                transaction.IsSuccess = false;
                transaction.Message = ex.Message;
                transaction.StatusCode = 400;
            }
            return (products, transaction);
        }

        public (List<JsonHolderPostsModel>, ApplicationTransaction) GetPostsList()
        {
            List<JsonHolderPostsModel> posts = new List<JsonHolderPostsModel>();
            ApplicationTransaction transaction = new ApplicationTransaction();
            transaction.IsSuccess = false;
            try
            {
                var client = new RestClient("https://jsonplaceholder.typicode.com/posts");
                var request = new RestRequest(Method.GET);
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "application/json");
                IRestResponse response = client.Execute(request);
                var decRes = JsonConvert.DeserializeObject<List<JsonHolderPostsModel>>(response.Content);
                if (decRes != null)
                {
                    posts = decRes.Where(x => x.Body.Contains("minima")).OrderBy(x => x.id).ToList();
                }
                transaction.IsSuccess = true;
            }
            catch (Exception ex)
            {
                transaction.IsSuccess = false;
                transaction.Message = ex.Message;
                transaction.StatusCode = 400;
            }
            return (posts, transaction);
        }
    }
}
