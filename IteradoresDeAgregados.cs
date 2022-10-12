using System;
using System.Collections.Generic;
using System.Text;

namespace MET1_CLASS1_INTERFACES
{
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
            return indice == 0;
        }
        public iterado actual()
        {
            return elementos[indice - 1];
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
    //3.11.1
    public class IteradorDeGerente : Iterador
    {
        private List<iterado> elementos;
        private int indice;
        public IteradorDeGerente(List<IComparable> l)
        {
            //utilizar iterado para los elementos de la lista
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
    public class IteradorDeConjunto : Iterador
    {
        private List<iterado> elementos;
        private int indice;
        public IteradorDeConjunto(List<IComparable> l)
        {
            //utilizar iterado para los elementos de la lista
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
}