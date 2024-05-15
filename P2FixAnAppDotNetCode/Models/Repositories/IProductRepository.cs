using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// modified array to list
        /// </summary>
        /// <returns></returns>
       List<Product> GetAllProducts();
        Product GetProductById(int id);// ajout pour la methode

        void UpdateProductStocks(int productId, int quantityToRemove);
    }
}
