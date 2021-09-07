using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Farmework.Application
{
    public  class OperationResult
    {
        public bool IsSuccess { get; set; }
        public string Massage { get; set; }
        public OperationResult()
        {
            IsSuccess = false;
        }
        public OperationResult Succedded(string message="عملیات با موفقیت انجام شد")
        {
            IsSuccess = true;
            Massage = message;
            return this;
        }
        public OperationResult Faild(string message)
        {
            IsSuccess = false;
            Massage = message;
            return this;

        }
    }
}
