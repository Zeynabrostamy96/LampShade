

using _01_Farmework.Application;
using System.Collections.Generic;

namespace DiscountManagement.Application.Contracts.Colleague
{
    public interface ICollegueDiscountApplication
    {
        OperationResult Define(DefineColleagueDiscount command);
        OperationResult Edit(EditColleagueDiscount command);
        EditColleagueDiscount GetDetails(long id);
        List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel searchModel);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
    }
}
