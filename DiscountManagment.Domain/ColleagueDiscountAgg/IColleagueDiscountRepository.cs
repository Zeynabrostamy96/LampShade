

using _01_Farmework.Domain;
using DiscountManagement.Application.Contracts.Colleague;
using System.Collections.Generic;

namespace DiscountManagment.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository: IRepository<long, ColleagueDiscount>
    {
        EditColleagueDiscount GetDetails(long id);
        List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel searchModel);
    }
}
