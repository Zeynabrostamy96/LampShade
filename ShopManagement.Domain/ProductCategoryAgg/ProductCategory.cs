﻿using _01_Farmework;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory: EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureTitle { get; private set; }
        public string  PictureAlt { get; private set; }
        public string  KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public List<Product> products { get; private set; }
        public ProductCategory()
        {
            products = new List<Product>();
        }
        public ProductCategory(string name,string description,string picture,string picturetitle,string picturealt,string keyWords,string metaDescription,string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureTitle = picturetitle;
            PictureAlt = picturealt;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;

 
        }
        public void Edit(string name, string description, string picture, string picturetitle, string picturealt, string keyWords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
         
            PictureTitle = picturetitle;
            PictureAlt = picturealt;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            Slug = slug;

        }
    }
}
