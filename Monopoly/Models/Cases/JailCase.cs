using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    [Serializable]
    public class JailCase : TextImageCase
    {
        public JailCase()
        {
            //Default values
            Text = "GO TO JAIL";
            ImagePath = "../Images/handcuffs.png";
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
