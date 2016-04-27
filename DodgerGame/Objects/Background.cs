using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgerGame.Objects
{
    public class Background : VisualObject
    {
        public Background(string imageFilename) : base(imageFilename)
        { }

        public override Point GetPosition()
        {
            return new Point(0, 0);
        }
    }
}
