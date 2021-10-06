

using _01_Farmework;
using BlogManagment.Domain.ArticleAgg;
using System.Collections.Generic;

namespace BlogManagment.Domain.ArticleCategoryAgg
{
   public  class ArticleCategory : EntityBase
    {
        public  string Name { get; private set; }
        public  string Picture { get; private set; }
        public string  PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Description { get; private set; }
        public string ShowOrder { get; private set; }
        public string Slug { get; private set; }
        public string   KeyWords { get; private set; }
        public string MetaDesCription { get; private set; }
        public string  CanonicalAddress { get; private set; }
        public List<Article> articles { get; private set; }
        public ArticleCategory()
        {

        }
        public ArticleCategory(string name,string picture,string picturealt,string picturetitle,string description
            ,string showorder,string slug,string keywords,string metadescription,string canonicationaddress)
        {
            Name = name;
            Picture = picture;
            PictureAlt = picturealt;
            PictureTitle = picturetitle;
            Description = description;
            ShowOrder = showorder;
            Slug = slug;
            KeyWords = keywords;
            MetaDesCription = metadescription;
            CanonicalAddress = canonicationaddress;
            articles = new List<Article>();

        }
        public void Edit(string name, string picture, string picturealt, string picturetitle, string description
            , string showorder, string slug, string keywords, string metadescription, string canonicationaddress)
        {
            Name = name;
            if(!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = picturealt;
            PictureTitle = picturetitle;
            Description = description;
            ShowOrder = showorder;
            Slug = slug;
            KeyWords = keywords;
            MetaDesCription = metadescription;
            CanonicalAddress = canonicationaddress;

        }
    }
}
