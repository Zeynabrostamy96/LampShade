using _01_Farmework.Domain;
using ShopManagement.Application.Contracts.Slide;
using System.Collections.Generic;

namespace ShopManagement.Domain.SlideAgg
{
    public  interface ISliderRepository: IRepository<long, Slide>
    {
        List<SlideViewModel> GetList();
        EditSlide GetDetails(long id);

    }
}
