using P2FixAnAppDotNetCode.Models.Repositories;
using P2FixAnAppDotNetCode.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        private List<CartLine> _cartLines = new List<CartLine>();// add _cartLines variable to persists changes
        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
           return _cartLines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // TODO implement the method "DONE"
            CartLine existingLine = _cartLines.FirstOrDefault(cl => cl.Product.Id == product.Id);

            if (existingLine != null)
            {
                if (product.Stock >= existingLine.Quantity + quantity)//stock can't be negative or null
                {
                    // if product exists increment quantity
                    existingLine.Quantity += quantity;
                }
                
            }
            else
            {
                // If product dont'exists add to cart
                if (product.Stock >= quantity)//stock can't be negative or null
                {
                    _cartLines.Add(new CartLine { Product = product, Quantity = quantity });
                }
            }

        }



        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method "DONE" 
            return _cartLines.Sum(l =>  l.Product.Price * l.Quantity);             
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method  "DONE"
            if (_cartLines.Count > 0)// to be sure to not divide by zero
             return _cartLines.Average(l => l.Quantity); 
            else
            {
                return 0.0;
            }
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method "DONE"

            CartLine wantedLine = _cartLines.Find(l => l.Product.Id == productId);
            Product product = wantedLine?.Product;
            return product;
        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
