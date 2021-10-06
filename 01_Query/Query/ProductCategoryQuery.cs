using _01_Farmework.Application;
using _01_Query.Contract.Product;
using _01_Query.Contract.ProductCategory;
using DiscountManagement.Infrastructure;
using Infrastructure;
using InventoryManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Query.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductCategoryQuery(ShopContext shopContext
            ,InventoryContext inventoryContext
            ,DiscountContext discountContext
            )
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public List<ProductCategoryViewModel> GetCategoryProductWhitProducts()
        {
            var inventory = _inventoryContext.inventory.Select(x => new {x.ProductId, x.UnitPrice }).ToList();
            var discount = _discountContext.customerDiscounts.Where(x=>x.StartDate<DateTime.Now && x.EndDate>DateTime.Now).Select(x => new { x.ProductId, x.DiscountRate }).ToList();
            var categories = _shopContext.ProductCategories.Include(x => x.products).ThenInclude(x => x.productCategory).Select(x => new ProductCategoryViewModel
            {
                id = x.id,
                Name = x.Name,
                products = MapProducts(x.products)


            }).ToList();
        
            foreach (var category in categories)
            {
                foreach (var product in category.products)
                {
                    var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                    if (productInventory != null)
                    {
                        var price = productInventory.UnitPrice;
                        product.Price = price.ToMoney();
                        var discountt = discount.FirstOrDefault(x => x.ProductId == product.Id);
                        if (discountt != null)
                        {
                            int discountRate = discountt.DiscountRate;
                            product.DiscountRate = discountRate;
                            product.HasDiscount = discountRate > 0;
                            var discountAmount = Math.Round((price * discountRate) / 100);
                            product.PriceWhitDiscount= (price - discountAmount).ToMoney();
                        }
                    }



                }
            }
            return categories;
        }

        public  List<ProductCategoryViewModel> GetList()
        {
          

            return _shopContext.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Picture=x.Picture,
                Slug=x.Slug,
                Name=x.Name,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                id=x.id

            }).ToList();
        }

        public static List<ProductViewModel> MapProducts(List<Product> products)
        {
      
            return products.Select(x => new ProductViewModel
            {
                Id=x.id,
                Name=x.Name,
                Slug=x.Slug,
                Picture=x.Picture,
                PictureTitle=x.PictureTitle,
                PictureAlt=x.PictureAlt,
                Category=x.productCategory.Name

            }).OrderByDescending(x=>x.Id).ToList();
        }

        public ProductCategoryViewModel GetCategoryProductWhitProducts(string slug)
        {
            var inventory = _inventoryContext.inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discount = _discountContext.customerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.ProductId, x.DiscountRate,x.EndDate }).ToList();
            var category = _shopContext.ProductCategories.Include(x => x.products).ThenInclude(x => x.productCategory).Select(x => new ProductCategoryViewModel
            {
                id = x.id,
                Name = x.Name,
                KeyWords=x.KeyWords,
                MetaDescription=x.MetaDescription,
                products = MapProducts(x.products),
                Slug=x.Slug
             
            }).FirstOrDefault(x=>x.Slug==slug);

            foreach(var product in category.products)
            {
                var inventories = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if(inventories != null)
                {
                    var price = inventories.UnitPrice;
                    product.Price = price.ToMoney();
                    var discountRate = discount.FirstOrDefault(x => x.ProductId == product.Id);
                    if(discountRate != null)
                    {
                        var  DiscountRate = discountRate.DiscountRate;
                        product.DiscountRate = DiscountRate;
                        product.DiscountExpireDate = discount.FirstOrDefault(x => x.ProductId == product.Id).EndDate.ToString();
                        product.HasDiscount = DiscountRate > 0;

                        var discountAmount = Math.Round((price * DiscountRate) / 100);
                        product.PriceWhitDiscount = (price - discountAmount).ToMoney();

                    }
                  
                }
            }

            return category;
        }
    }
}
