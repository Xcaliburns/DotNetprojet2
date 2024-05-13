namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProductRepository
    {
        Product[] GetAllProducts();
        Product GetProductById(int id);// ajout pour la methode

        void UpdateProductStocks(int productId, int quantityToRemove);
    }
}
