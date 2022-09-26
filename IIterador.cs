using System;
using System.Collections.Generic;
using System.Text;

namespace MET1_CLASS1_INTERFACES
{
    //PASO1 CREACION DE INTERFACES.
    public interface Iterador //ES UN OBJETO QUE SABE RECORRER UN AGREGADO.
    {
        void primero();
        bool fin();
        void siguiente();
        iterado actual();
    }
    public interface Iterable
    {
        //para cambiar la forma de iterar... 
        Iterador getIterador();
    }
    public interface iterado
    {

    }
}
