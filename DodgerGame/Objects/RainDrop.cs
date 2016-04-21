using DodgerGame.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgerGame.Objects
{
    public class RainDrop : MovableObject
    {
        public RainDrop(Point position, string imageFilename)
            : base(position, imageFilename)
        {  }
    }
}
