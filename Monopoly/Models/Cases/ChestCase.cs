using Monopoly.Models.Cases.Categories;

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
