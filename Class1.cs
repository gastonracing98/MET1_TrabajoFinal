using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MET1_CLASS1_INTERFACES
{
  
    // 2)
    public class Numero : IComparable
    {
        private int valor;

        public Numero(int v)
        {
            valor = v;
        }
        public int getValor()
        {
            return valor;
        }
        //tengo que castear
        public bool sosIgual(IComparable c)
        {
            return this.valor == ((Numero)c).getValor(); //casteo de tipo valor IComparable a tipo 'Numero'... 
        }
        public bool sosMenor(IComparable c)
        {
            return this.valor < ((Numero)c).getValor();
        }
        public bool sosMayor(IComparable c)
        {
            return this.valor > ((Numero)c).getValor();
        }
    }
 

    //4
    public class Cola : IColeccionable, Iterable
    {
        private List<IComparable> elementos;
        public Cola()
        {
            elementos = new List<IComparable>();
        }
        public void push(IComparable c)
        {
            elementos.Add(c);
        }
        public IComparable pop()
        {
            IComparable retorno = elementos[0];
            elementos.RemoveAt(0);
            return retorno;
        }
        public int cuantos()
        {
            return this.elementos.Count;
        }
        public IComparable minimo()
        {
            IComparable minimo = elementos[0];
            for (int i = 0; i < elementos.Count; i++)
            {
                if (elementos[i].sosMenor(minimo))
                {
                    minimo = elementos[i];
                }
            }
            return minimo;
        }
        public IComparable maximo()
        {
            IComparable maximo = elementos[0];
            for (int i = 0; i < elementos.Count; i++)
            {
                if (elementos[i].sosMayor(maximo))
                {
                    maximo = elementos[i];
                }
            }
            return maximo;
        }
        public void agregar(IComparable c)
        {
            this.push(c);
        }
        public bool contiene(IComparable c)
        {
            for (int i = 0; i < elementos.Count; i++)
            {
                if (elementos[i].sosIgual(c))
                {
                    return true;
                }
            }
            return false;
        }
        public Iterador getIterador()
        {
            return new IteradorDeColaYConjunto(elementos);
        }
        
    }
    public class Pila : IColeccionable, Iterable //vemos como se soluciona esto... creo que en la clase 3
    {
        //clase2 ==> crear el iterador
        private List<IComparable> elementos;
        public Pila()
        {
            elementos = new List<IComparable>();
        }
        public void push(IComparable c)
        {
            elementos.Add(c);
        }
        public IComparable pop()
        {
            IComparable retorno = elementos[elementos.Count - 1];
            elementos.RemoveAt(elementos.Count - 1);
            return retorno;
        }

        public int cuantos()
        {
            return elementos.Count;
        }
        public IComparable minimo()
        {
            IComparable menor = elementos[0];
            for (int i = 0; i < elementos.Count; i++)
            {
                if (elementos[i].sosMenor(elementos[i]))
                {
                    menor = elementos[i];
                }
            }
            return menor;
        }
        public IComparable maximo()
        {
            IComparable mayor = elementos[0];
            for (int i = 0; i < elementos.Count; i++)
            {
                if (elementos[i].sosMayor(elementos[i]))
                {
                    mayor = elementos[i];
                }
            }
            return mayor;
        }
        public void agregar(IComparable c)
        {
            this.push(c);
        }
        public bool contiene (IComparable c)
        {
            for (int i = 0; i < elementos.Count; i++)
            {
                if (elementos[i].sosIgual(c))
                {
                    return true;
                }
            }
            return false;
        }
        public Iterador getIterador()
        {
            return new IteradorDePila(elementos);
        }   
    }//8
    class ColeccionMultiple : IColeccionable
    {
        private IColeccionable pila;
        private IColeccionable cola;
        public ColeccionMultiple(Pila pila, Cola cola)
        {
            this.pila = pila;
            this.cola = cola;
        }
        public int cuantos()
        {
            return pila.cuantos() & cola.cuantos();
        }
        public IComparable minimo()
        {
            if (pila.minimo().sosMenor(cola.minimo()))
            {
                return pila.minimo();
            }
            else
            {
                return cola.minimo();
            }

        }
        public IComparable maximo()
        {
            if (pila.maximo().sosMayor(cola.maximo()))
            {
                return pila.maximo();
            }
            else
            {
                return cola.maximo();
            }
        }
        public void agregar(IComparable c)
        {

        }
        public bool contiene(IComparable c)
        {
            if (pila.contiene(c) && cola.contiene(c))
            {
                return true;
            }
            else if (pila.contiene(c))
            {
                return true;
            }
            else if (cola.contiene(c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    // 11
    public class Persona : IComparable,iterado
    {
        private string nombre;
        private int dni;

        public Persona(string n, int d)
        {
            nombre = n;
            dni = d;
        }

        public string getNombre {
            get { return nombre; }
        }
        public int getDni
        {
            get { return dni; }
        }

        public bool sosIgual(IComparable c)
        {//comaramos dni
            return this.dni == ((Persona)c).getDni;
        }
        public bool sosMayor(IComparable c)
        {
            return this.dni > ((Persona)c).getDni;
        }
        public bool sosMenor(IComparable c)
        {
            return this.dni < ((Persona)c).getDni;
        }

    }
    //15
    class Alumno : Persona
    {
        //3°creo la composición
        private EstrategiaDeComparacion estrategia = null;
        private int legajo;
        double promedio;
       
        public Alumno(string n, int d, int l, double p) : base(n, d)
        {
            //4° Crear una estrategia por defecto
            this.legajo = l;
            this.promedio = p;
            setEstrategia(new EstrategiaPorDni());// == estrategia = new EstrategiaPorDni();
            //1setEstrategia(new EstrategiaPorLegajo());
            //estrategia = new EstrategiaPorLegajo();
            //estrategia = new EstrategiaPorDni();
            //estrategia = new EstrategiaPorNombre();
            //estrategia = new EstrategiaPorPromedio();
        }
        public int getLegajo
        {
            get { return legajo; }
        }
        public double getPromedio
        {
            get
            {
                return promedio;
            }
        }
        //18
        public bool sosIgual(IComparable c)
        {   //5° delegar 
            return estrategia.sosIgual(this,c);
        }
        public bool sosMenor(IComparable c)
        {
            return estrategia.sosMenor(this,c);
        }
        public bool sosMayor(IComparable c)
        {
            return estrategia.sosMayor(this,c);
        }
        public void setEstrategia(EstrategiaDeComparacion e) //????
        {
            estrategia = e;
        }
    }
}