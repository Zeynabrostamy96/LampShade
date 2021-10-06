using _01_Farmework.Application;
using _01_Query.Contract.Comment;
using _01_Query.Contract.Product;
using CommentManagment.Application.Contracts.Comment;
using CommentManagment.Infrastructure;
using DiscountManagement.Infrastructure;
using Infrastructure;
using InventoryManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Query.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;
        private readonly CommentContext _commentContext;
        public ProductQuery(ShopContext shopContext,InventoryContext inventoryContext,DiscountContext discountContext,CommentContext commentContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
            _commentContext = commentContext;
        }
        public ProductViewModel GetDetailsby(string slug)
        {
            var inventory = _inventoryContext.inventory.Select(x => new { x.ProductId, x.UnitPrice,x.InStock }).ToList();
            var discount = _discountContext.customerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.ProductId, x.DiscountRate,x.EndDate }).ToList();

            var product = _shopContext.products.Include(x => x.productCategory).Include(x => x.pictures).Select(x => new ProductViewModel
            {
                Id = x.id,
                Slug = x.Slug,
                Picture = x.Picture,
                Name = x.Name,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                Category = x.productCategory.Slug,
                ShortDescription = x.ShortDescription,
                Code = x.Code,
                Keywords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Description = x.Description,
                CategorySlug = x.productCategory.Slug,
                ProductPictures = MapProductPictures(x.pictures),


            }).FirstOrDefault(x => x.Slug == slug);
     
            if (product == null)
                return new ProductViewModel();

            var inventores = inventory.FirstOrDefault(x => x.ProductId == product.Id);

            if (inventores != null)
            {
                product.IsInStock = inventores.InStock;
                var price = inventores.UnitPrice;
                product.Price = inventores.UnitPrice.ToMoney();

                var discountRate = discount.FirstOrDefault(x => x.ProductId == product.Id);
                if (discountRate != null)
                {
                   var discounts = discountRate.DiscountRate;
                    product.DiscountRate = discounts;
                    product.HasDiscount = discounts > 0;
                    var discountamount = Math.Round((price * discounts) / 100);
                    product.PriceWhitDiscount = (price - discountamount).ToMoney();
                    product.DiscountExpireDate = discount.FirstOrDefault(x => x.ProductId == product.Id).EndDate.ToString();
                }
            }
             product.comments = _commentContext.comments.Where(x => x.Type == CommentType.Product)
                .Where(x=>x.OwnerRecordId==product.Id)
                .Where(x => x.ISConfiremed).Where(x => !x.ISConceled)
                .Select(x =>new CommentQueryViewModel 
                {
                    id=x.id,
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message

                }).OrderByDescending(x=>x.id).ToList();
            return  product;
        }

        public static List<ProductPictureQueryModel> MapProductPictures(List<ProductPicture> pictures)
        {
            return pictures.Select(x => new ProductPictureQueryModel
            {
                Picture=x.Picture,
                IsRemove=x.IsRemove,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                ProductId=x.ProductId

            }).Where(x => !x.IsRemove).ToList();
        }

        public List<ProductViewModel> GetLastArrivals()
        {
            var inventory = _inventoryContext.inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discount = _discountContext.customerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.ProductId, x.DiscountRate }).ToList();
            var producs= _shopContext.products.Include(x=>x.productCategory).Select(x => new ProductViewModel
            {
                Id=x.id,
                Slug=x.Slug,
                Picture=x.Picture,
                Name=x.Name,
                PictureTitle=x.PictureTitle,
                PictureAlt=x.PictureAlt,
                Category=x.productCategory.Name,

            }).OrderByDescending(x=>x.Id).Take(6).ToList();
            foreach(var item in producs)
            {
                var inventores = inventory.FirstOrDefault(x => x.ProductId == item.Id);
           
                if(inventores != null)
                {
                    var price = inventores.UnitPrice;
                    item.Price = inventores.UnitPrice.ToMoney();
            
                    var discountRate = discount.FirstOrDefault(x => x.ProductId == item.Id).DiscountRate;
                    if(discountRate != 0)
                    {

                        item.DiscountRate = discountRate;
                        item.HasDiscount = discountRate > 0;
                        var discountamount = Math.Round((price* discountRate) / 100);
                        item.PriceWhitDiscount = (price - discountamount).ToMoney();

                    }
                }
            }
            return producs;
        }

        public List<ProductViewModel> Search(string Value)
        {
            var inventory = _inventoryContext.inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discount = _discountContext.customerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.ProductId, x.EndDate, x.DiscountRate }).ToList();
            var query = _shopContext.products.Include(x => x.productCategory).Select(x => new ProductViewModel
            {
                Id = x.id,
                Name = x.Name,
                Slug = x.Slug,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                ShortDescription = x.ShortDescription,
                CategorySlug=x.productCategory.Slug,
                Category = x.productCategory.Name,

            }).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(Value))
            {
                query = query.Where(x => x.Name.Contains(Value) || x.ShortDescription.Contains(Value));
            }
            var products = query.OrderByDescending(x => x.Id).ToList();
            foreach(var item in products)
            {
                var inventories = inventory.FirstOrDefault(x => x.ProductId == item.Id);
                if(inventories != null)
                {
                    var price = inventories.UnitPrice;
                    item.Price = inventories.UnitPrice.ToMoney();
                    var discountrate = discount.FirstOrDefault(x => x.ProductId == item.Id).DiscountRate;
                    if(discountrate != 0)
                    {
                        item.DiscountRate = discountrate;
                        item.HasDiscount = discountrate > 0;
                        item.DiscountExpireDate = discount.FirstOrDefault(x => x.ProductId == item.Id).EndDate.ToString();
                        var discountamount = Math.Round((price * discountrate) / 100);
                        item.PriceWhitDiscount = (price - discountrate).ToMoney();
                    }
                }
            }
            return products;
        }
    }
}
