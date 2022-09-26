using System;
using System.Collections.Generic;
using System.Text;

namespace MET1_CLASS1_INTERFACES
{
    /// 2° como voy a comparar con varios atributos propios de la clase de alumno tengo que crear una clase por cada atributo que voy a comparar.
    class EstrategiaPorLegajo : EstrategiaDeComparacion
    {
        public bool sosIgual(IComparable c1, IComparable c2)
        {
            return ((Alumno)c1).getLegajo == ((Alumno)c2).getLegajo;
        }
        public bool sosMayor(IComparable c1, IComparable c2)
        {
            return ((Alumno)c1).getLegajo > ((Alumno)c2).getLegajo;
        }
        public bool sosMenor(IComparable c1, IComparable c2)
        {
            return ((Alumno)c1).getLegajo < ((Alumno)c2).getLegajo;
        }
    }
    class EstrategiaPorDni : EstrategiaDeComparacion
    {
        public bool sosIgual(IComparable c1, IComparable c2)
        {
            return ((Alumno)c1).getDni < ((Alumno)c2).getDni;
        }
        public bool sosMayor(IComparable c1, IComparable c2)
        {
            return ((Alumno)c1).getDni > ((Alumno)c2).getDni;
        }
        public bool sosMenor(IComparable c1, IComparable c2)
        {
            return ((Alumno)c1).getDni < ((Alumno)c2).getDni;
        }
    }
    class EstrategiaPorNombre : EstrategiaDeComparacion
    {
        public bool sosIgual(IComparable c1, IComparable c2)
        {
            return ((Alumno)c1).getNombre.Equals(((Alumno)c2).getNombre);
            //return alumno.getNombre == ((Alumno)c).getNombre;
        }
        public bool sosMayor(IComparable c1, IComparable c2)
        {
            return ((Alumno)c1).getNombre.Length > ((Alumno)c2).getNombre.Length;
        }
        public bool sosMenor(IComparable c1, IComparable c2)
        {
            return ((Alumno)c1).getNombre.Length < ((Alumno)c2).getNombre.Length;
        }
    }
    class EstrategiaPorPromedio : EstrategiaDeComparacion
    {
        public bool sosIgual(IComparable c1, IComparable c2)
        {
            return ((Alumno)c1).getPromedio == ((Alumno)c2).getPromedio;
        }
        public bool sosMayor(IComparable c1, IComparable c2)
        {
            return ((Alumno)c1).getPromedio > ((Alumno)c2).getPromedio;
        }
        public bool sosMenor(IComparable c1, IComparable c2)
        {
            return ((Alumno)c1).getPromedio < ((Alumno)c2).getPromedio;
        }
    }
}
