

using _01_Farmework.Application;
using System.Collections.Generic;

namespace DiscountManagement.DM_Application.Contracts.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Defaine(DefaineCustomerDiscount command);
        OperationResult Edit(EditCustomerDiscount command);
       EditCustomerDiscount GetDetails(long id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchmodel);
    }
}
