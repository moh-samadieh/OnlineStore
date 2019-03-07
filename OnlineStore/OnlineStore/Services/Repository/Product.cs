using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Data.Entities;

namespace OnlineStore.Services
{
    public partial class Repository
    {
        public Product GetProduct(int ID)
        {
            return this._myContext.Products
                .Include(x => x.ProductImages)
                .Include(x => x.Brand)
                .FirstOrDefault(x => x.ID == ID);
        }

        public IQueryable<Product> GetProducts()
        {
            return this._myContext.Products
                .Include(x => x.Brand);
        }

        public IQueryable<Category> GetProductCategories(int ProductID)
        {
            return this._myContext.CategoryProducts
                .Where(x => x.ProductID == ProductID)
                .Select(x => x.Category);
        }

        public IQueryable<ProductImage> GetProductImages(int ProductID)
        {
            return this._myContext.ProductImages
                .Where(x => x.ProductID == ProductID);
        }


        public void EditProduct(Product p)
        {
            this._myContext.Entry(p).State = EntityState.Modified;

            this._myContext.SaveChanges();
        }

        public Product CreateProduct()
        {
            return new Product();
        }

        public void AddProduct(Product p)
        {
            this._myContext.Entry(p).State = EntityState.Added;
            this._myContext.SaveChanges();
        }

        public void DeleteProduct(int ID)
        {
            var employee = new Product() { ID = ID };
            this._myContext.Products.Remove(employee);
            _myContext.SaveChanges();
        }
    }
}
