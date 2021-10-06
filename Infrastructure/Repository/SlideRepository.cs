using _01_Farmework.Application;
using _01_Farmework.Infrastructure;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public  class SlideRepository: RepositoryBase<long,Slide>,ISliderRepository
    {
        private readonly ShopContext _shopContext;
        public SlideRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditSlide GetDetails(long id)
        {
            return _shopContext.slides.Select(x => new EditSlide
            {
                id=x.id,
                PictureAlt=x.PictureAlt,
                Heading=x.Heading,
                Title=x.Title,
                PictureTitle=x.PictureTitle,
                Text=x.Text,
                BtnText=x.BtnText,
                Link=x.Link


            }
          ).FirstOrDefault(x => x.id == id);
        }

        public List<SlideViewModel> GetList()
        {
            return _shopContext.slides.Select(x => new SlideViewModel
            {
                id = x.id,
                Title =x.Title,
                Heading=x.Heading,
                Picture=x.Picture,
                CreationDate=x.Crationdate.ToFarsi(),
                IsRemove=x.IsRemove
            }).ToList();
        }
    }
}
