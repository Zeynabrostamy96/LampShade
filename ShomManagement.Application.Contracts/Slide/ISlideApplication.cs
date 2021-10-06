using _01_Farmework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slide
{
    public interface ISlideApplication
    {
        OperationResult Create( CreateSlide command);
        OperationResult Edit(EditSlide command);
        EditSlide GetDetails(long id);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        List<SlideViewModel> GetList();
    }
}
