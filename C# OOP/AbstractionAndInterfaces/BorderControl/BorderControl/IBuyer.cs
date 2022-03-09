using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IBuyer
    {
        public int Food { get; set; }
        public string Name { get; set; }
        public void BuyFood();
    }
}
