using System;

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

        public override void Action()
        {
            return;
        }

        public override bool IsLegal()
        {
            return false;
        }
    }
}
