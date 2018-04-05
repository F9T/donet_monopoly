using System;
using MonopolyCommon.Cases.Categories;

namespace MonopolyCommon.Cases
{
    [Serializable]
    public class ChanceCase : TextImageCase
    {
        public ChanceCase()
        {
            //Default values
            Text = "CHANCE";
            ImagePath = "../Images/clover.png";
            Type = "Chance";
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
