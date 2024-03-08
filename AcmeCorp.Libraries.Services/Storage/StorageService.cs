using System.Net.Http.Json;
using AcmeCorp.Libraries.Models;
using AcmeCorp.Libraries.Services.Storage;

namespace AcmeCorp.Libraries.Services.Storage
{

    /// <summary>
    /// Stores the data used for the application.
    /// </summary>
    public class StorageService : IStorageService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Stores a list of products.
        /// </summary>
        public IList<Product> Products { get; private set; }

        /// <summary>
        ///  Constructs a storage service.
        /// </summary>
        public StorageService()
        {
            //_httpClient = httpClient; //virker måske ikke
            Products = new List<Product>();
        }

        public async Task initialize(HttpClient httpClient)
        {
            Products = await httpClient.GetFromJsonAsync<List<Product>>(@"https://localhost:7163/api/v3/Board/GetBoard");
            //split into get async, and later readfromjson
            //check for response codes
        }


        public IList<Product> GetAll()
        {
            return Products.ToList();
        }

        /// <summary>
        /// Adds a product to the storage.
        /// </summary>
        /// <param name="product">The <see cref="product"/> type to be added.</param>
        private void AddProduct(Product productModel)
        {
            if (!Products.Any(p => p.Id == productModel.Id))
            {
                Products.Add(productModel);
            }
        }
    }
}
