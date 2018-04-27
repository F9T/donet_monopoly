using System;
using MonopolyCommon.Players;

namespace MonopolyCommon.Cases
{
    [Serializable]
    public class EmptyCase : AbstractCase
    {
        public EmptyCase()
        {
            Type = "Empty";
        }

        public override void RandomFill()
        {
            return;
        }

        public override void Action(Player _player, Platter _platter)
        {
            return;
        }

        public override bool IsLegal()
        {
            return false;
        }
    }
}
