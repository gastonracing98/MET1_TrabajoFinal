using System;
using System.Collections.Generic;
using System.Collections;

namespace MET1_CLASS1_INTERFACES
{
    class Program
    {
        static void Main(string[] args)
        {

           // Numero A = new Numero(2);
            //Numero B = new Numero(3);
            //Console.WriteLine(A.sosMenor(B));
            Alumno a = new Alumno("gaston",9,1,7.4);
            Alumno b = new Alumno("ulises",1,2,10.0);
            //Console.WriteLine(a.sosIgual(b));
            //a.setEstrategia(new EstrategiaPorLegajo()); //cambio la estrategia
            //Console.WriteLine(a.sosIgual(b));

            //cola.agregar(a);
            //cola.agregar(b);
            //imprimirElementos((Iterable)cola);
            //2.8
            //IColeccionable pila = new Pila();
            //IColeccionable cola = new Cola();
            //IColeccionable conjunto = new Conjunto();
            //IColeccionable diccionario = new ClaveValor.Diccionario();
            //llenarAlumnos(pila);
            //llenarAlumnos(cola);
            //llenarAlumnos(conjunto);
            //llenarAlumnos(diccionario);
            //imprimirElementos((Iterable)pila);
            //imprimirElementos((Iterable)cola);
            ////imprimirElementos((Iterable)conjunto);
            //imprimirElementos((Iterable)diccionario);

            //2.10
            EstrategiaPorNombre e = new EstrategiaPorNombre();
            EstrategiaPorPromedio e1= new EstrategiaPorPromedio();
            EstrategiaPorLegajo e2 = new EstrategiaPorLegajo();
            EstrategiaPorDni e3 = new EstrategiaPorDni();

            IColeccionable pila = new Pila();
            llenarAlumnos(pila);
            cambiarEstrategia((Iterable)pila,e);
            informar(pila);
            cambiarEstrategia((Iterable)pila,e1);
            informar(pila);
            cambiarEstrategia((Iterable)pila,e2);
            informar(pila);
            cambiarEstrategia((Iterable)pila,e3);
            informar(pila);
        }
        // 5)
        public static void Llenar(IColeccionable C)
        {
            Random randomUnicoDeInstancia = new Random();
            for (int i = 0;i<20; i++)
            {
               
                C.agregar(new Numero(randomUnicoDeInstancia.Next(100)));

            }
           // return C;

        }
        
        // 6
        public static void informar(IColeccionable c)
        {
            Console.WriteLine(c.cuantos().ToString());
            Console.WriteLine(c.minimo());
            Console.WriteLine(c.maximo());
            Console.WriteLine();
            Console.WriteLine("Ingrese valor: ");
            int var = int.Parse(Console.ReadLine());
            IComparable a = new Numero(var);
            if (c.contiene(a))
            {
                Console.WriteLine("!El elemento esta ene la coleccion!");
            }
            else
            {
                Console.WriteLine("El elemento leido no esta en la coleccion ");
            }
        }
        // 7
        static void Mainw(string[] args) 
        {
            //7
            
            IColeccionable cola = new Cola();
            IColeccionable pila = new Pila();
            //9{
            ColeccionMultiple multiple = new ColeccionMultiple((Pila)pila, (Cola)cola);
            //}
            //Llenar(pila);
            //Llenar(cola);
            //informar(pila);
            //informar(cola);
            //informar(multiple);
            ///
            //llenarPersonas(pila);
            //llenarPersonas(cola);
            llenarAlumnos(pila);
            llenarAlumnos(cola);
            informar(cola);
            
        }
        // 12
        public static void llenarPersonas(IColeccionable c)
        {
            string[] lista = new string[32] { "Cecilia Giner Ballesteros", "Chucho Serrano Puyol", "Cruz Catalán Rosselló", "Fidel del Solana", "Bruno Giménez Borja", "Estefanía Bermudez Quiroga", "Dora Redondo Vives", "Lilia Tudela Leiva", "Adelardo Marino Manjón", "Pedro", "Maura Amaya Piquer", " Manuel", "Abraham Elpidio Cáceres, Asensio", "Valeria Alcolea Esteban", "Amancio Iniesta-Linares", "Amaro Balaguer Flores", "Plácido Hoyos-Cordero", "Graciana Morante Crespi", "Ciríaco Torrens Cornejo", "Dorotea Vidal", "Trinidad de Badía", "Timoteo de Isern", "Óscar de Parejo", "Maximino Montaña Blanch", "Teodosio del Bernal", "María Del Carmen Aguilar", "Lupe Guillén Barreda", "Rómulo de Arribas", "Josep Espiridión Delgado Aguilera", "Américo Emigdio Muro Sanmiguel", "María Macías", "Alexandra Cánovas Bru" };
           
            Random random = new Random();
            for (int i = 0; i<20; i++)
            {
                c.agregar(new Persona(lista[random.Next(0, 32)], random.Next(11111111, 99999999)));

            }

        }
        //16
        public static void llenarAlumnos(IColeccionable c)
        {
            string[] lista = new string[32] { "Cecilia Giner Ballesteros", "Chucho Serrano Puyol", "Cruz Catalán Rosselló", "Fidel del Solana", "Bruno Giménez Borja", "Estefanía Bermudez Quiroga", "Dora Redondo Vives", "Lilia Tudela Leiva", "Adelardo Marino Manjón", "Pedro", "Maura Amaya Piquer", " Manuel", "Abraham Elpidio Cáceres, Asensio", "Valeria Alcolea Esteban", "Amancio Iniesta-Linares", "Amaro Balaguer Flores", "Plácido Hoyos-Cordero", "Graciana Morante Crespi", "Ciríaco Torrens Cornejo", "Dorotea Vidal", "Trinidad de Badía", "Timoteo de Isern", "Óscar de Parejo", "Maximino Montaña Blanch", "Teodosio del Bernal", "María Del Carmen Aguilar", "Lupe Guillén Barreda", "Rómulo de Arribas", "Josep Espiridión Delgado Aguilera", "Américo Emigdio Muro Sanmiguel", "María Macías", "Alexandra Cánovas Bru" };

            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                c.agregar(new Alumno(lista[random.Next(0, 32)], random.Next(11111111, 99999999),random.Next(1111111,9999999),random.NextDouble()));
                

            }
        }
        //2.7 
        public static void imprimirElementos(Iterable col)
        {
            Alumno a;
            Iterador ite = col.getIterador();
            while (!ite.fin()){
                a =(Alumno) ite.actual();
                Console.WriteLine(a.getNombre);

                //Console.WriteLine((Alumno)ite.actual());
                ite.siguiente();
            }
        }
        //2.9
        public static void cambiarEstrategia(Iterable col, EstrategiaDeComparacion e) {
            Alumno a;
            Iterador ite = col.getIterador();
            while (!ite.fin())
            {
                a =(Alumno) ite.actual();
                a.setEstrategia(e);
                
                //((Alumno)col).setEstrategia(e);
                ite.siguiente();
            }

        }



    }
}

