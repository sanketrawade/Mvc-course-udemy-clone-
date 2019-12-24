using System;

namespace MyShop.Core.Model
{
    public abstract class BaseEntity
    {
        public string ID { get; set; }

        public BaseEntity()
        {
            ID = Guid.NewGuid().ToString();
        }
    }
}