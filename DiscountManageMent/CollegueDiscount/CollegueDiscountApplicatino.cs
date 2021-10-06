
using _01_Farmework.Application;
using DiscountManagement.Application.Contracts.Colleague;
using DiscountManagment.Domain.ColleagueDiscountAgg;
using System.Collections.Generic;

namespace DiscountManagement.DM_Application.CollegueDiscount
{
    public class CollegueDiscountApplicatino : ICollegueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;
        public CollegueDiscountApplicatino(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }
        public OperationResult Define(DefineColleagueDiscount command)
        {
            var operation = new OperationResult();
            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);
            var discount = new ColleagueDiscount(command.ProductId,command.DiscountRate);
            _colleagueDiscountRepository.Create(discount);
            _colleagueDiscountRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var operation = new OperationResult();
            var discount = _colleagueDiscountRepository.Get(command.id);
            if (discount == null)
                return operation.Faild(ApplicationMessage.RecordNotFound);
            if (_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate&& x.id!=command.id))
                return operation.Faild(ApplicationMessage.DuplicatedRecord);
            discount.Edit(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.Save();
            return operation.Succedded();
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _colleagueDiscountRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var Operation = new OperationResult();
            var discount = _colleagueDiscountRepository.Get(id);
            if (discount == null)
                return Operation.Faild(ApplicationMessage.RecordNotFound);
            discount.Remove();
            _colleagueDiscountRepository.Save();
            return Operation.Succedded();
          
        }

        public OperationResult Restore(long id)
        {
            var Operation = new OperationResult();
            var discount = _colleagueDiscountRepository.Get(id);
            if (discount != null)
                return Operation.Faild(ApplicationMessage.RecordNotFound);
            discount.Restore();
            _colleagueDiscountRepository.Save();
            return Operation.Succedded();
        }

        public List<CollegueDiscountViewModel> Search(CollegueDiscountSearchModel searchModel)
        {
            return _colleagueDiscountRepository.Search(searchModel);
        }
    }
}
