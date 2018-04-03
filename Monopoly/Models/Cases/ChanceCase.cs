using System;
using System.Xml.Serialization;

namespace Monopoly.Models.Cases
{
    [Serializable]
    public class ChanceCase : TextImageCase
    {
        public ChanceCase()
        {
            //Default values
            Text = "CHANCE";
            ImagePath = "../Images/clover.png";
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
