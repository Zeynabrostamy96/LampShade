using _01_Farmework;
using BlogManagment.Domain.ArticleCategoryAgg;
using System;

namespace BlogManagment.Domain.ArticleAgg
{
   public   class Article: EntityBase
   {
        public string  Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureAlt { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddres { get; private set; }
        public DateTime PublishDate { get; private set; }
        public long  AricleCategoryId { get; private set; }
        public ArticleCategory  articleCategory{ get; private set; }

        public Article()
        {

        }
        public Article(string title,string shortdescription,string description
            ,string picture,string picturetitle,string picturealt,string slug
            ,string keywords,string metadescription,string canonicaladdress,long articlecategoryid,DateTime publishdate)
        {

            Title = title;
            ShortDescription = shortdescription;
            Description = description;
            Picture = picture;
            PictureTitle = picturetitle;
            PictureAlt = picturealt;
            Slug = slug;
            KeyWords = keywords;
            MetaDescription = metadescription;
            CanonicalAddres = canonicaladdress;
            AricleCategoryId = articlecategoryid;
            PublishDate = publishdate;

        }
        public void Edit(string title, string shortdescription, string description
            , string picture, string picturetitle, string picturealt, string slug
            , string keywords, string metadescription, string canonicaladdress, long articlecategoryid, DateTime publishdate)
        {
            Title = title;
            ShortDescription = shortdescription;
            Description = description;
            if(!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureTitle = picturetitle;
            PictureAlt = picturealt;
            Slug = slug;
            KeyWords = keywords;
            MetaDescription = metadescription;
            CanonicalAddres = canonicaladdress;
            AricleCategoryId = articlecategoryid;
            PublishDate = publishdate;
        }

    }

}
