
using _01_Farmework.Application;
using DiscountManagement.DM_Application.Contracts.CustomerDiscount;
using DiscountManagment.Domain.CustomerDiscountAgg;
using System.Collections.Generic;

namespace DiscountManagement.DM_Application.CustomerDiscount
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;
        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }
        public OperationResult Defaine(DefaineCustomerDiscount command)
        {
            var operations = new OperationResult();
            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operations.Faild(ApplicationMessage.RecordNotFound);
            var startdate = command.StartDate.ToGeorgianDateTime();
            var EndDate = command.EndDate.ToGeorgianDateTime();
            var discount = new DiscountManagment.Domain.CustomerDiscountAgg.CustomerDiscount(command.ProductId,command.DiscountRate, startdate, EndDate, command.Reason);
            _customerDiscountRepository.Create(discount);
            _customerDiscountRepository.Save();
            return operations.Succedded();
            
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var operations = new OperationResult();
            var discount = _customerDiscountRepository.Get(command.id);
            if (discount == null)
                return operations.Faild(ApplicationMessage.RecordNotFound);
            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.id != command.id))
                return operations.Faild(ApplicationMessage.RecordNotFound);
            var startdate = command.StartDate.ToGeorgianDateTime();
            var enddate = command.EndDate.ToGeorgianDateTime();
            discount.Edit(command.ProductId, command.DiscountRate, startdate, enddate, command.Reason);
            _customerDiscountRepository.Save();
            return operations.Succedded();


        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _customerDiscountRepository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel SearchModel)
        {
            return _customerDiscountRepository.Search(SearchModel);
        }
    }
}
