using System;
using System.Collections.Generic;
using System.Text;

namespace MET1_CLASS1_INTERFACES
{
    //2.1
    interface EstrategiaDeComparacion
    {   //como tengo que comparar en 'sosIgual' los legajos, los dni, los promedios y tengo que agregar el if dependiendo de lo que compare,
        //para ahorrarme los if's tengo que crear una estrategia para solucionar estre problema
        /// 1° hago esto, creo esta interfaz en el cual tengo el confilcto.

        bool sosIgual(IComparable c1, IComparable c2);
        bool sosMayor(IComparable c1, IComparable c2);
        bool sosMenor(IComparable c1, IComparable c2);

    }

}
