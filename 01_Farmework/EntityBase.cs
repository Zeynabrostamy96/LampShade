using System;

namespace _01_Farmework
{
    public class EntityBase
    {
        public long id { get; private set; }
        public DateTime  Crationdate { get; private set; }
        public EntityBase()
        {
            Crationdate = DateTime.Now;
        }

    }
}
