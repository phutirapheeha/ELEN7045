using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgerGame.Interface
{
    public interface IRenderEngine
    {
        void Render(System.Drawing.Point position, string imageFilename);
    }
}
