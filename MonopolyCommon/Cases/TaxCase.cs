using System;
using MonopolyCommon.Cases.Categories;

namespace MonopolyCommon.Cases
{
    [Serializable]
    public class TaxCase : PriceTextImageCase
    {
        public TaxCase()
        {
            Type = "Tax";
        }
        public override void Action()
        {
            throw new NotImplementedException();
        }

        public override bool IsLegal()
        {
            throw new NotImplementedException();
        }
    }
}
