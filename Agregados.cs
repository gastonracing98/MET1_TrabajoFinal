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