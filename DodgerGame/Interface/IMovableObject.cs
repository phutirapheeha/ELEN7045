using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodgerGame.Interface
{
    interface IMovableObject
    {
        Guid ID {get;}
        IPosition GetCurrentPosition();
        void Move(IPosition newPosition);
    }
}
