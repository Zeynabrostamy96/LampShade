using _01_Farmework;

namespace DiscountManagment.Domain.ColleagueDiscountAgg
{
    public class ColleagueDiscount: EntityBase
    {
        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }
        public bool IsRemove { get; private set; }
        public ColleagueDiscount()
        {

        }
        public ColleagueDiscount(long productid,int discountrate)
        {
            ProductId = productid;
            DiscountRate = discountrate;
            IsRemove = false;

        }
        public void Edit(long productid, int discountrate)
        {

            ProductId = productid;
            DiscountRate = discountrate;

        }
        public void Remove()
        {
            IsRemove = true;
        }
        public void Restore()
        {
            IsRemove = false;
        }
    }
}
