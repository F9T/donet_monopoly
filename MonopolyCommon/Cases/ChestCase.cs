using MonopolyCommon.Cases.Categories;

namespace MonopolyCommon.Cases
{
    public class ChestCase : TextImageCase
    {
        public ChestCase()
        {
            //Default values
            Text = "COMMUNITY CHEST";
            ImagePath = "";
            Type = "Chest";
        }

        public override void RandomFill()
        {

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
