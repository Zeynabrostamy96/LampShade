

namespace DiscountManagement.Application.Contracts.Colleague
{
    public  class CollegueDiscountViewModel
    {
        public long id { get; set; }
        public long ProductId { get; set; }
        public string product { get; set; }
        public int DiscountRate { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }

    }
}
