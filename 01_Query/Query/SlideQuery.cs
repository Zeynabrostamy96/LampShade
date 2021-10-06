using _01_Query.Contract.Slide;
using Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace _01_Query.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _shopContext;
        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public List<SlideQueryModel> GetSlides()
        {
            return _shopContext.slides.Where(x=>x.IsRemove==false).Select(x => new SlideQueryModel
            {
                BtnText=x.BtnText,
                Heading=x.Heading,
                Link=x.Link,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                Text=x.Text,
                Title=x.Title

            }).ToList();
        }
    }
}
