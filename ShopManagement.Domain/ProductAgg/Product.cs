using _01_Farmework;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductAgg
{
    public   class Product: EntityBase
    {
        public string Name { get;private set; }
        public string Description { get;private set; }
        public string ShortDescription { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Picture { get; private set; }
        public string  PictureTitle { get; private set; }
        public string  PictureAlt { get; private set; }
        public string Code { get; private set; }
        public  long  ProductegoryId { get; private set; }
        public   ProductCategory productCategory { get; private set; }
        public List<ProductPicture> pictures { get; set; }

        public Product()
        {

        }
        public Product(string name, string description, string shortDescription, string slug, string keyWords, string metaDescription,
          string picture, string pictureTitle, string pictureAlt, string code, long productegoryId)
        {
            Name = name;
            Description = description;
            ShortDescription = shortDescription;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Code = code;
            ProductegoryId = productegoryId;


        }
        public  void Edit(string name, string description, string shortDescription, string slug, string keyWords, string metaDescription,
          string picture, string pictureTitle, string pictureAlt, string code, long productegoryId)
        {
            Name = name;
            Description = description;
            ShortDescription = shortDescription;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            
            Code = code;
            ProductegoryId = productegoryId;
        }

    }

}
