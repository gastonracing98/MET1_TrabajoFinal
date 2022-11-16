using System;
using System.Collections.Generic;
using System.Collections;

namespace MET1_CLASS1_INTERFACES
{
    class Program
    {
        static void Mainl(string[] args)
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
            //Llenar(pila,);
            cambiarEstrategia((Iterable)pila,e);
            informar(pila,1);
            cambiarEstrategia((Iterable)pila,e1);
            informar(pila,1);
            cambiarEstrategia((Iterable)pila,e2);
            informar(pila,1);
            cambiarEstrategia((Iterable)pila,e3);
            informar(pila,1);
        }
        // 5)
        //CLASE 3 EJERCICIO 6
        public static void Llenar(IColeccionable C, int opcion){
            for (int i = 0;i<20; i++){
                C.agregar(FabricaDeComparables.crearComparable(opcion));
            }
           // return C;
        }

        // 6//CLASE 3 EJERCICIO 6
        public static void informar(IColeccionable c, int opcion)
        {
            Console.WriteLine(c.cuantos().ToString());
            Console.WriteLine(c.minimo().ToString());
            Console.WriteLine(c.maximo().ToString());
            Console.WriteLine();

            IComparable a = FabricaDeComparables.crearComparable(opcion);
            if (c.contiene(a)){
                Console.WriteLine("!El elemento esta en la coleccion!");
            }
            else
            {
                Console.WriteLine("El elemento leido no esta en la coleccion ");
            }
        }
        // 7
        static void Main2(string[] args){
            //7
            IColeccionable cola = new Cola();
            IColeccionable pila = new Pila();
            //9{
            //ColeccionMultiple multiple = new ColeccionMultiple((Pila)pila, (Cola)cola);
            //}
            //Llenar(pila);
            //Llenar(cola);
            //informar(pila);
            //informar(cola);
            //informar(multiple);
            ///
            //llenarPersonas(pila);
            //llenarPersonas(cola);
            //llenarAlumnos(pila);
            //llenarAlumnos(cola);
            //Llenar(cola, 4);
            //Console.WriteLine("Que desea comparar: \n");
            //Console.WriteLine("Ingrese: ");
            //Console.WriteLine("'2' PARA COMPARAR ALUMNOS.");
            //Console.WriteLine("'3' PARA COMPARAR PERSONAS.");
            //Console.WriteLine("'1' PARA COMPARAR NUMEROS.");
            //Console.WriteLine("'4' PARA COMPARAR VENDEDORES.");
               
            //int opcion = int.Parse(Console.ReadLine());
            //informar(cola,opcion);
            //CLASE 3 EJERCICIO 14

            Gerente gerente = new Gerente();
            Iterable coleccion = new Cola();
            Llenar((IColeccionable)coleccion, 4);
            Iterador i = coleccion.getIterador();
            while (!i.fin()){
                iterado c = i.actual();
                ((IObservado)c).agregarObservador(gerente);
                i.siguiente();
            }
            jornadaDeVentas(coleccion);
            gerente.cerrar();
           

            

            //
            
        }   

        // 12
        //public static void llenarPersonas(IColeccionable c){
        //    string[] lista = new string[32] { "Cecilia Giner Ballesteros", "Chucho Serrano Puyol", "Cruz Catalán Rosselló", "Fidel del Solana", "Bruno Giménez Borja", "Estefanía Bermudez Quiroga", "Dora Redondo Vives", "Lilia Tudela Leiva", "Adelardo Marino Manjón", "Pedro", "Maura Amaya Piquer", " Manuel", "Abraham Elpidio Cáceres, Asensio", "Valeria Alcolea Esteban", "Amancio Iniesta-Linares", "Amaro Balaguer Flores", "Plácido Hoyos-Cordero", "Graciana Morante Crespi", "Ciríaco Torrens Cornejo", "Dorotea Vidal", "Trinidad de Badía", "Timoteo de Isern", "Óscar de Parejo", "Maximino Montaña Blanch", "Teodosio del Bernal", "María Del Carmen Aguilar", "Lupe Guillén Barreda", "Rómulo de Arribas", "Josep Espiridión Delgado Aguilera", "Américo Emigdio Muro Sanmiguel", "María Macías", "Alexandra Cánovas Bru" };
        //    Random random = new Random();
        //    for (int i = 0; i<20; i++){
        //        c.agregar(new Persona(lista[random.Next(0, 32)], random.Next(11111111, 99999999)));
        //    }

        //}
        //16
        //public static void llenarAlumnos(IColeccionable c)
        //{
        //    string[] lista = new string[32] { "Cecilia Giner Ballesteros", "Chucho Serrano Puyol", "Cruz Catalán Rosselló", "Fidel del Solana", "Bruno Giménez Borja", "Estefanía Bermudez Quiroga", "Dora Redondo Vives", "Lilia Tudela Leiva", "Adelardo Marino Manjón", "Pedro", "Maura Amaya Piquer", " Manuel", "Abraham Elpidio Cáceres, Asensio", "Valeria Alcolea Esteban", "Amancio Iniesta-Linares", "Amaro Balaguer Flores", "Plácido Hoyos-Cordero", "Graciana Morante Crespi", "Ciríaco Torrens Cornejo", "Dorotea Vidal", "Trinidad de Badía", "Timoteo de Isern", "Óscar de Parejo", "Maximino Montaña Blanch", "Teodosio del Bernal", "María Del Carmen Aguilar", "Lupe Guillén Barreda", "Rómulo de Arribas", "Josep Espiridión Delgado Aguilera", "Américo Emigdio Muro Sanmiguel", "María Macías", "Alexandra Cánovas Bru" };
        //    int opcion = 1;
        //    Random random = new Random();
        //    for (int i = 0; i < 20; i++){
        //        c.agregar(FabricaDeComparables.crearComparable(opcion)) ;
        //    }
        //}
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
        //CLASE 3 EJERCICIO 13
        public static void jornadaDeVentas(Iterable coleccion_vendedores)//vendedores
        {
            Vendedor a;
            Iterador ite = coleccion_vendedores.getIterador();//creo el iterador del coleccionable 
            for (int i = 0; i < 20; i++)
            {
                Random r = new Random();
                double monto = (double) r.Next(5000,7000);
                a = (Vendedor)ite.actual();
                a.venta(monto);
                ite.siguiente();

            }
        }
        static void Main(string[] args)
        {
            Random r = new Random();
            string[] lista = new string[32] { "Cecilia Giner Ballesteros", "Chucho Serrano Puyol", "Cruz Catalán Rosselló", "Fidel del Solana", "Bruno Giménez Borja", "Estefanía Bermudez Quiroga", "Dora Redondo Vives", "Lilia Tudela Leiva", "Adelardo Marino Manjón", "Pedro", "Maura Amaya Piquer", " Manuel", "Abraham Elpidio Cáceres, Asensio", "Valeria Alcolea Esteban", "Amancio Iniesta-Linares", "Amaro Balaguer Flores", "Plácido Hoyos-Cordero", "Graciana Morante Crespi", "Ciríaco Torrens Cornejo", "Dorotea Vidal", "Trinidad de Badía", "Timoteo de Isern", "Óscar de Parejo", "Maximino Montaña Blanch", "Teodosio del Bernal", "María Del Carmen Aguilar", "Lupe Guillén Barreda", "Rómulo de Arribas", "Josep Espiridión Delgado Aguilera", "Américo Emigdio Muro Sanmiguel", "María Macías", "Alexandra Cánovas Bru" };
           // Teacher teacher = new Teacher();
            ListOfStudent.Teacher teacher = new ListOfStudent.Teacher();
            
            List<IAlumno> LISTA = new List<IAlumno>(); //hago esta lista aux para poder recorrer los decorados de la lista e imprimir cada decorado
            
            for (int i = 0; i < 10; i++) {
               Alumno a = new Alumno(lista[r.Next(0,31)],r.Next(11111111,99999999),r.Next(111,9999999),r.Next(0,10));
                Student ALU = new AlumnoAdapter(a);
                IAlumno alu = new CalificacionAlumnoConAsteriscos(a);
                AlumnoMuyEstudioso a2 = new AlumnoMuyEstudioso(lista[r.Next(0, 31)], r.Next(11111111, 99999999), r.Next(111, 9999999), r.Next(0, 10));
                Student ALU2 = new AlumnoAdapter(a2);
                IAlumno alu2 = new CalificacionAlumnoConAsteriscos(a2);
                LISTA.Add(alu);
                LISTA.Add(alu2);
                //Student student = new AlumnoAdapter(a);//DecoradorAlumno 
                //Student student1 = new AlumnoAdapter(a2);
                //Student student = alu;
                //Student student1 = alu2;


                teacher.goToClass(ALU); //
                teacher.goToClass(ALU2);
                
                //Console.WriteLine(alu.Calificacion());
            }
            teacher.teachingAClass();

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(LISTA[i].Calificacion());
            }
            //Alumno ALUMNO = CrearDecoradorConLetraYPromocion(a);
            //Console.WriteLine(ALUMNO.Calificacion());
            //



        }
        //public static IAlumno crearStudent()
        //{//creo un comparable y lo convierto en un adpter, le paso como parametro un 'Alumno'
        //    IAlumno IA = ((IAlumno)FabricaDeComparables.crearComparable(2));
        //    return new AlumnoAdapter((Alumno)IA);
            
        //}
        //public static IAlumno crearDecoradorConLetra()
        //{
        //    IAlumno IA = crearStudent();
        //    return new CalificacionAlumnoConLetras(IA);//le tengo que pasar la calificación al decorador
        //}
        //public static IAlumno CrearDecoradorConLetraYPromocion() 
        //{
        //    IAlumno IA = crearDecoradorConLetra();
        //    return new CalificacionAlumnoConPromocion(IA);
        //}
        //crear funcion con asteriscos
    }
}

