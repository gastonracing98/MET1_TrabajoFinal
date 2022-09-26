using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
/// <summary>
/// CLASE 2
/// </summary>
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
    //PASO 2 CREAR LOS ITERADORES

    public class IteradorDePila : Iterador
    {

        private List<iterado> elementos;
        private int indice;
        public IteradorDePila(List<IComparable> l)
        {
            elementos = l.ConvertAll(x => (iterado)x);

            //elementos = l;
            indice = elementos.Count;
        }
        public void primero()
        {
            indice = elementos.Count;
        }
        public void siguiente()
        {
            indice--;
        }
        public bool fin()
        {
            return indice ==0;
        }
        public iterado actual()
        {
            return elementos[indice-1];
        }

    }
    public class IteradorDeColaYConjunto : Iterador
    {
        private List<iterado> elementos;
        private int indice;
        public IteradorDeColaYConjunto(List<IComparable> l)
        {
            elementos = l.ConvertAll(x => (iterado)x);
           //elementos = l;
            indice = 0;
        }
        public void primero()
        {
            indice = 0;
        }
        public void siguiente()
        {
            indice++;
        }
        public bool fin()
        {
            return indice == elementos.Count;
        }
        public iterado actual()
        {
            return elementos[indice];
        }

    }
    public class IteradorDeCola : Iterador
    {
        private List<iterado> elementos;
        private int indice;
        public IteradorDeCola(List<IComparable> l)
        {
            elementos = l.ConvertAll(x => (iterado)x);
            //elementos = l;
            indice = 0;
        }
        public void primero()
        {
            indice = 0;
        }
        public void siguiente()
        {
            indice++;
        }
        public bool fin()
        {
            return indice == elementos.Count;
        }
        public iterado actual()
        {
            return elementos[indice];
        }

    }


    //2.1
    interface EstrategiaDeComparacion
    {   //como tengo que comparar en 'sosIgual' los legajos, los dni, los promedios y tengo que agregar el if dependiendo de lo que compare,
        //para ahorrarme los if's tengo que crear una estrategia para solucionar estre problema
        /// 1° hago esto, creo esta interfaz en el cual tengo el confilcto.

        bool sosIgual(IComparable c1, IComparable c2);
        bool sosMayor(IComparable c1, IComparable c2);
        bool sosMenor(IComparable c1, IComparable c2);

    }

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
    //2.3
    //Implementar la clase conjunto... 
    public class Conjunto : IColeccionable
    {
        //si se intenta almacenar un elemento que ya está en el conjunto, éste
        //elemento no se almacena ya que sino estaría repetido.
        List<IComparable> elementos = new List<IComparable>();
        public Conjunto()
        {
            elementos = new List<IComparable>();
        }
        public int cuantos()
        {
            return elementos.Count;
        } //cuantos comparables hay
        public IComparable minimo()
        {
            IComparable minimo = elementos[0];
            for (int i = 0; i < elementos.Count - 1; i++)
            {
                if (elementos[i].sosMenor(minimo))
                    minimo = elementos[i];
            }
            return minimo;
        }
        public IComparable maximo()
        {
            IComparable maximo = elementos[0];
            for (int i = 0; i < elementos.Count - 1; i++)
                if (elementos[i].sosMayor(maximo))
                    maximo = elementos[i];

            return maximo;
        }
        public void agregar(IComparable c)
        {
            if (!contiene(c))
                elementos.Add(c);
        }
        public bool contiene(IComparable c)
        {
            for (int i = 0; i < elementos.Count; i++)
                if (elementos[i].sosIgual(c))
                    return true;
            return false;
        }
        //metodo eliminar
    }
    //2.4 
    //creamos clave auxiliar para este problema
    public class ClaveValor : IComparable
    {
        private IComparable valor; //alumno
        private IComparable clave; //contrasena
        public ClaveValor(IComparable v, IComparable c)
        {
            valor = v;
            clave = c;
        }
        public IComparable getValor
        {
            get { return valor; }

        }
        public IComparable getClave
        {
            get { return clave; }
        }
        public bool sosIgual(IComparable c)
        {
            return this.valor==((ClaveValor)c).getValor;
        }
        public bool sosMenor(IComparable c)
        {
            return this.valor.sosMenor(c); 
        }
        public bool sosMayor(IComparable c)
        {
            return this.valor.sosMayor(c);
        }


        public class Diccionario : IColeccionable , Iterable
        {
            //si se intenta almacenar un elemento que ya está en el conjunto, éste
            //elemento no se almacena ya que sino estaría repetido.
            List<IComparable> elementos = new List<IComparable>();
            public Diccionario()
            {
                elementos = new List<IComparable>();
            }
            public int cuantos()
            {
                return elementos.Count;
            } //cuantos comparables hay
            public IComparable minimo()
            {
                IComparable minValor = elementos[0];
                
                for (int i = 0; i < elementos.Count - 1; i++)
                {
                    if (elementos[i].sosMenor(minValor))
                        minValor = elementos[i];
                }
                
                return minValor;
            }
            public IComparable maximo()
            {
                IComparable maximo = elementos[0];
                for (int i = 0; i < elementos.Count - 1; i++)
                    if (elementos[i].sosMayor(maximo))
                        maximo = elementos[i];

                return maximo;
            }
            public void agregar(IComparable c)
            {
                    elementos.Add(c);

            }
            public bool contiene(IComparable c)
            {
                for (int i = 0; i < elementos.Count; i++)
                    if (elementos[i].sosIgual(c))
                        return true;
                return false;
            }
            public IComparable valorDe(IComparable clave)
            {
                IComparable valor = null;
                for (int i = 0; i < elementos.Count; i++)
                    if (elementos[i].sosIgual(clave))
                        valor = elementos[i];
                return valor;

            }
            public void agregar(IComparable c, IComparable v )
            {
                bool encontro = false;
                IComparable CV = new ClaveValor(v, c);

                for (int i = 0; elementos.Count>i; i++)
                {
                    if (elementos[i].sosIgual(c))
                    {
                        agregar(CV);
                        encontro = true;
                    }
                }
                if(encontro = false)
                {
                    agregar(CV);// seguir
                }
            }
            //IMPLEMENTAR EL ITERABLE
            public Iterador getIterador()
            {
                return new IteradorDeColaYConjunto(elementos);
            }
        }
    }
}