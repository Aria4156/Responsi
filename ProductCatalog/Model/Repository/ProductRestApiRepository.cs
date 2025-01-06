using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCatalog.Model.Entity;
using RestSharp;

namespace ProductCatalog.Model.Repository
{
    public class ProductRestApiRepository
    {
        private const string BASE_URL = "http://responsi.coding4ever.net:5555/";

        public List<Product> ReadAll()
        {
            string resource = "api/product";
            RestClient restClient = new RestClient(BASE_URL);
            RestRequest request = new RestRequest(resource, Method.Get);
            RestResponse<List<Product>> restResponse = restClient.Execute<List<Product>>(request);
            return restResponse.Data;
        }

        public List<Product> ReadByProductName(string productName)
        {
            string resource = "api/product?product_name=" + productName;
            RestClient restClient = new RestClient("http://responsi.coding4ever.net:5555/");
            RestRequest request = new RestRequest(resource, Method.Get);
            RestResponse<List<Product>> restResponse = restClient.Execute<List<Product>>(request);
            return restResponse.Data;
        }

        public List<Product> ReadByCategory(string category)
        {
            string resource = "api/product?category=" + category;
            RestClient restClient = new RestClient("http://responsi.coding4ever.net:5555/");
            RestRequest request = new RestRequest(resource, Method.Get);
            RestResponse<List<Product>> restResponse = restClient.Execute<List<Product>>(request);
            return restResponse.Data;
        }

        public Product ReadByProductId(string productId)
        {
            string resource = "api/product/" + productId;
            RestClient restClient = new RestClient("http://responsi.coding4ever.net:5555/");
            RestRequest request = new RestRequest(resource, Method.Get);
            RestResponse<Product> restResponse = restClient.Execute<Product>(request);
            return restResponse.Data;
        }
    }
}
