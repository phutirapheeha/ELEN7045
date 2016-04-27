using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgerGame.Objects
{
    public static class Extensions
    {
        public static int GetRightEndPosition(this MovableObject movableObject, int width)
        {
            return movableObject.GetPosition().X + width;
        }

        public static int GetBottomEndPosition(this MovableObject movableObject, int height)
        {
            return movableObject.GetPosition().Y + height;
        }

    }
}
