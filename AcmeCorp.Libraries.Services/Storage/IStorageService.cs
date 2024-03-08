using AcmeCorp.Libraries.Models;

namespace AcmeCorp.Libraries.Services.Storage
{
    /// <summary>
    /// Stores the data used for the application.
    /// </summary>
    public interface IStorageService
    {
        /// <summary>
        /// Stores a list of products.
        /// </summary>
        IList<Product> Products { get; }

        /// <summary>
        /// Initialize the storage
        /// </summary>
        Task initialize(HttpClient client);
    }
}
