using System;
using System.Collections.Generic;
using System.Text;

namespace MET1_CLASS1_INTERFACES
{
    //CLASE 3 EJERCICIO 2
    public class GeneradorDeDatosAleatorios
    {
        public int numeroAleaotorio(int max)
        {
            Random random = new Random();
            return random.Next(0, max);
        }
        public string stringAleatorio(int cant)
        {
            string[] letras = new string[26] {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","X","y","z"};
            Random random = new Random();
            string palabra = "";
            for (int i = 0; i<cant; i++)
            {
                palabra += letras[2];
            }
            return palabra;
        }
    }
    ////CLASE 3 EJERCICIO 3
    public class LectorDeDatos
    {
        public int numeroPorTeclado(){
            Console.WriteLine("ingrese numero: ");
            int num =int.Parse(Console.ReadLine());
            return num;
        }
        public string stringPorTeclado(){
            Console.WriteLine("ingrese palabra: ");
            string str = Console.ReadLine();
            return str;
        }
    }
    //CLASE 3 EJERCICIO 4
    //1°factory method
    public interface IFabricaDeComparables
    {
        IComparable crearAleatorio();
        IComparable crearPorTeclado();
    }
    //CLASE 3 EJERCICIO 5
    public abstract class FabricaDeComparables : IFabricaDeComparables
    {
        static public IComparable crearComparable(int opcion)
        {
            FabricaDeComparables fabrica = null;
            switch (opcion)
            {
                case 1: fabrica = new FabricaDeNumeros();break;
                case 2: fabrica = new FabricaDeAlumnos();break;
                case 3: fabrica = new FabricaDePersonas();break;
                case 4: fabrica = new FabricaDeVendedores();break;
                //case 5: fabrica = new StudentFactory();break;
                   
            }
            return fabrica.crearPorTeclado();
        }
        abstract public IComparable crearAleatorio();
        abstract public IComparable crearPorTeclado();
    }
    //PASO 2 CREAR LAS FABRICAS CONCRETAS.
    public class FabricaDeNumeros : FabricaDeComparables
    {
        override public IComparable crearAleatorio(){
            Random random = new Random();
            return new Numero(random.Next(0,9999)); ;
        }
        public override IComparable crearPorTeclado(){
            LectorDeDatos num = new LectorDeDatos();
            return new Numero(num.numeroPorTeclado());
        }
    }
    public class FabricaDeAlumnos : FabricaDeComparables
    {
        override public IComparable crearAleatorio(){
            Random random = new Random();
            return new Alumno("nombre al azar", random.Next(12312311,99999999), random.Next(111, 99999), 1.1); ;
        }
        override public IComparable crearPorTeclado(){
            Console.WriteLine("Ingresar nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingresar legajo: ");
            int leg = int.Parse(Console.ReadLine());
            Console.WriteLine("Igresar DNI: ");
            int dni = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar promedio: ");
            double prom = double.Parse(Console.ReadLine());
            return new Alumno(nombre,dni,leg,prom);
        }
    }
    public class FabricaDePersonas : FabricaDeComparables
    {
        override public IComparable crearAleatorio(){
            return new Persona("persona",1);
        }
        override public IComparable crearPorTeclado(){
            Console.WriteLine("Ingresar nombre: ");
            string nom = Console.ReadLine();
            Console.WriteLine("Ingrese dni: ");
            int dni = int.Parse(Console.ReadLine());
            return new Persona(nom,dni);
        }
    }
    //CLASE 3 EJERCICIO 9
    public class FabricaDeVendedores : FabricaDeComparables
    {
        override public IComparable crearAleatorio() {

            return new Vendedor("nombre", 111, 0);
        }
        public override IComparable crearPorTeclado()
        {
            Console.WriteLine("Ingresar nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingresar sueldo: ");
           double sueldo = int.Parse(Console.ReadLine());
            Console.WriteLine("Igresar DNI: ");
            int dni = int.Parse(Console.ReadLine());

           return new Vendedor(nombre,dni,sueldo);
        }
    }
    //CLASE 3 EJERCICIO 8
    public class Vendedor : Persona{
        private double sueldoBasico, bonus,monto;
        public Vendedor(string nombre,int dni,double sueldo):base(nombre,dni){
            sueldoBasico = sueldo;
            bonus = 1;
        }
        public double getMonto
        {
            get { return monto; }
        }
        private double setMonto
        {
            set { monto = value; }
        }
        public double GetSetSueldoBasico
        {
            get
            {
                return this.sueldoBasico;
            }
            set { sueldoBasico = value; }
        }
        public double Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }
        //metodos
        public void venta(double monto){
            Console.WriteLine(monto);
            setMonto = monto;
            notificar(this);
        }

        public void aumentaBonus(){
            bonus += 0.1;
        }
        public bool sosIgual(IComparable c)
        {//comaramos dni
            return this.getDni == ((Vendedor)c).getDni;
        }
        public bool sosMayor(IComparable c)
        {
            return this.getDni > ((Vendedor)c).getDni;
        }
        public bool sosMenor(IComparable c)
        {
            return this.getDni < ((Vendedor)c).getDni;
        }
        
    }
    //CLASE 3 EJERCICIO 11
    //GERENTE ES UN COLECCIONABLE Y VENDEDOR ES COMPARABLE
    public class Gerente : IObservador{
        private Conjunto mejores = new Conjunto();
        Iterador ite;
        
        public void cerrar()
        {
            ite=mejores.getIterador();
            while (!ite.fin())
            {
                ite.actual().ToString();// implementar toString del vendedor
                ite.siguiente();
            }

            //foreach (var i in mejores)
            //{
            //    Console.WriteLine(((Vendedor)i).getNombre);
            //    Console.WriteLine(((Vendedor)i).getDni);
            //    Console.WriteLine(((Vendedor)i).Bonus);
            //}
        }
        public void venta(double monto, IComparable vendedor)
        {
            if (monto>5000)
            {
                //a
                mejores.agregar(vendedor);
                ((Vendedor)vendedor).aumentaBonus();
                //if (!mejores.Contains(vendedor))
                //    mejores.Add(vendedor);
            }    
        }
        public void actualizar(IObservado observado)
        {
            Vendedor v = (Vendedor)observado;
            this.venta(v.getMonto,v);
        }
    }

    public interface IObservador
    {
        void actualizar(IObservado observado);
    } 
    public interface IObservado
    {
        void notificar(IObservado observado);
        void agregarObservador(IObservador observador);
       void quitarObservador(IObservador observador);
    }
    public abstract class ObservadoAbstacto : IObservado
    {
        List<IObservador> observadors = new List<IObservador>(); //el vendedor almacenera los gerentes o los observadores
        public void notificar(IObservado observado) 
        {
            foreach (IObservador obs in observadors)
            {
                obs.actualizar(this);
            }
        }
        public void agregarObservador(IObservador observador)
        {
            observadors.Add(observador);
        }
        public void quitarObservador(IObservador observador)
        {
            observadors.Remove(observador);
        }
    }
}