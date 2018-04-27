using MonopolyCommon.Cases.Categories;
using MonopolyCommon.Players;

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

        public override void Action(Player _player, Platter _platter)
        {
            
        }

        public override bool IsLegal()
        {
            return true;
        }
    }
}
