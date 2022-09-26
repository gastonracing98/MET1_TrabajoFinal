using System;
using System.Collections.Generic;
using System.Text;

namespace MET1_CLASS1_INTERFACES
{
    //CREAR INTERFACE
    //1)
    public interface IComparable
    {
        //declaro los metodos
        bool sosIgual(IComparable c);
        bool sosMenor(IComparable c);
        bool sosMayor(IComparable c);
    }
}
