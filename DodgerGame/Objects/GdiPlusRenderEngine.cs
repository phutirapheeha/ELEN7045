using DodgerGame.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgerGame.Objects
{
    public class GdiPlusRenderEngine : IRenderEngine
    {
        private readonly Graphics _bufferSurface;

        public GdiPlusRenderEngine(Image buffer)
        {
            _bufferSurface = Graphics.FromImage(buffer);
        }
        public void Render(Point position, string imageFilename)
        {
            var image = new Bitmap(imageFilename);
            _bufferSurface.DrawImage(image, position);
        }

        
    }
}
