using System;
using Monopoly.Models.Cases.Categories;

namespace Monopoly.Models.Cases
{
    [Serializable]
    public class StationCase : PriceTextImageCase
    {
        public override void Action()
        {
            throw new NotImplementedException();
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
