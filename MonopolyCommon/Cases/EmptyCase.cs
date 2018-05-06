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

        public override string Action(Player _player, Platter _platter)
        {
            return "Il ne se passe rien.";
        }

        public override bool IsLegal()
        {
            return false;
        }
    }
}
