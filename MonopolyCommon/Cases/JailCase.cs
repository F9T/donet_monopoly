using System;
using MonopolyCommon.Cases.Categories;
using MonopolyCommon.Players;

namespace MonopolyCommon.Cases
{
    [Serializable]
    public class JailCase : TextImageCase
    {
        public JailCase()
        {
            //Default values
            Text = "GO TO JAIL";
            ImagePath = "";
            Type = "Jail";
            IsEditable = false;
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
