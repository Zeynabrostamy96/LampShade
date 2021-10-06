using _01_Farmework;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public  class ProductPicture: EntityBase
    {
        public long ProductId { get; private set; }
        public string Picture { get; private set; }
        public string  PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public bool IsRemove { get; private set; }
        public Product product { get; set; }
     
        public ProductPicture()
        {

        }
        public ProductPicture(long productid,string picture,string picturAlt,string pictureTitle)
        {

            ProductId = productid;
            Picture = picture;
            PictureAlt = picturAlt;
            PictureTitle = pictureTitle;
            IsRemove = false;

        }
        public void Edit(long productid, string picture, string picturAlt, string pictureTitle)
        {
            ProductId = productid;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = picturAlt;
            PictureTitle = pictureTitle;
            IsRemove = false;

        }
        public void Remove()
        {
            IsRemove = true;
        }
        public void Restor()
        {
            IsRemove = false;
        }

    }
}
