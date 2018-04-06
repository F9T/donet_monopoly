using System;
using MonopolyCommon.Cases.Categories;

namespace MonopolyCommon.Cases
{
    [Serializable]
    public class StationCase : PriceTextImageCase
    {
        public StationCase()
        {
            Type = "Station";
        }

        public override void RandomFill()
        {

        }

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
