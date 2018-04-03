using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    public class ChestCase : TextImageCase
    {
        public ChestCase()
        {
            //Default values
            Text = "COMMUNITY CHEST";
            ImagePath = "../Images/chest.png";
        }

        public override void Action()
        {
            
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
