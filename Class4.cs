using System;
using System.Collections.Generic;
using System.Text;

namespace MET1_CLASS1_INTERFACES
{
    //Practica 4, EJERCICIO 3
    public class AlumnoAdapter : Student, IAlumno
    {
        Alumno alu;
        public AlumnoAdapter(Alumno a)
        {
            this.alu = a;
        }
        public string getName()
        {
            return alu.getNombre;
        }
        public int GetDni
        {
            get { return alu.getDni; }
        }
        public int GetLegajo
        {
            get { return alu.getLegajo; }
        }
        public double GetPromedio
        {
            get { return alu.getPromedio; }
        }
        public Alumno GetAlumno
        {
            get { return alu; }
        }
        public int yourAnswerIs(int question)
        {
            return alu.responderPregunta(question);
        }
        public string showResult()
        {
            return alu.mostrarCalificacion();
        }
        public bool equals(Student c)
        {
            Alumno alum = ((AlumnoAdapter)c).GetAlumno;
            //AlumnoAdapter A = ((AlumnoAdapter)c);
            //Alumno b = new Alumno(A.getName(),A.GetDni,A.GetLegajo,A.GetPromedio);
            ////Alumno a = ((Alumno)c).GetAlumno();
            return alu.sosIgual(alum);//cambie el a por el b
        }
        public bool lessThan(Student c)
        {
            Alumno alum = ((AlumnoAdapter)c).GetAlumno;
            //Alumno a = ((Alumno)c).GetAlumno();
            return alu.sosMenor(alum);
        }
        public bool greaterThan(Student c)
        {
            Alumno alum = ((AlumnoAdapter)c).GetAlumno;

            //AlumnoAdapter A = ((AlumnoAdapter)c);
            //Alumno b = new Alumno(A.getName(), A.GetDni, A.GetLegajo, A.GetPromedio);
            //Alumno a = ((Alumno)c).GetAlumno();
            return alu.sosMayor(alum);
        }
        public void setScore(int score)
        {
            alu.GetSetCalificacion = score;
        }
        public string Calificacion()
        {
            return showResult();
        }
        public int getCalificacion()
        {
            return alu.getCalificacion();
        }

    }
    //Practica 4, EJERCICIO 6
    //Componente
    public interface IAlumno
    {
        string Calificacion();
        int getCalificacion();

    }
    //alumno es la clase Componente Concreto
    
    //DECORADOR (SUPERCLASE)
    public abstract class DecoradorAlumno : IAlumno
    {
        IAlumno alu;

        public DecoradorAlumno(IAlumno alumno) 
        {
            alu = alumno;
        }
        virtual public string Calificacion()
        {
            return alu.Calificacion();
        }
        public int getCalificacion()
        {
           return alu.getCalificacion();
        }

    }
    //DECORADORES CONCRETOS
    public class CalificacionAlumnoConLegajo : DecoradorAlumno
    {
        private string legajo;
        
        public CalificacionAlumnoConLegajo(IAlumno alumno, int legajo) : base(alumno)
        {
            
            this.legajo = legajo.ToString();
        }
        public override string Calificacion()
        { 
            return base.Calificacion() + " legajo: " + legajo;
        }
    }
    public class CalificacionAlumnoConLetras : DecoradorAlumno
    {
        private int calificacion;
        private string calificacionConLetras;
        public CalificacionAlumnoConLetras(IAlumno alumno, int calificacion) : base(alumno) 
        {
            this.calificacion = calificacion;
        }
        public override string Calificacion()
        {
            switch (calificacion)
            {
                case 0: calificacionConLetras = "cero"; break;
                case 1: { calificacionConLetras = "uno"; break; }
                case 2: calificacionConLetras = "dos";break;
                case 3: calificacionConLetras = "tres"; break;
                case 4: calificacionConLetras = "cuatro"; break;
                case 5: calificacionConLetras = "cinco"; break;
                case 6: calificacionConLetras = "seis"; break;
                case 7: calificacionConLetras = "siete"; break;
                case 8: calificacionConLetras = "ocho"; break;
                case 9: calificacionConLetras = "nueve"; break;
                case 10: calificacionConLetras = "diez"; break;
                
            }
            return base.Calificacion() + " (" + calificacionConLetras+")";
            
        }
       

    }
    public class CalificacionAlumnoConPromocion : DecoradorAlumno
    {
        
        public CalificacionAlumnoConPromocion(IAlumno alumno) : base(alumno)
        {
            
        }
        public override string Calificacion()
        {

            string nota = "";
            if(base.getCalificacion()>=7) 
            {
                nota = "PROMOCION";
            }
            else if (base.getCalificacion()<7 & base.getCalificacion()>=4)
            {
                nota = "APROBADO";
            }
            else
            {
                nota = "DESAPROBADO";
            }
            return base.Calificacion() + nota;
        }
    }
    public class CalificacionAlumnoConAsteriscos : DecoradorAlumno
    {
        
        public CalificacionAlumnoConAsteriscos(IAlumno alumno) : base(alumno)
        {
           
        }
        public override string Calificacion()
        {
            for(int i = 0; i < 100; i++)
            {
                Console.Write("*");
                if (i == 50)
                {
                    Console.WriteLine();
                    
                    Console.Write("*");
                    Console.Write("        ");
                    Console.Write(base.Calificacion());
                    Console.Write("        *");
                    Console.WriteLine();
                }
            }
            Console.WriteLine(" ");
            return "";
        }
    }
    //clase 4 ejercicio 7
    //public class StudentFactory : FabricaDeAlumnos
    //{
        
    //    private IComparable crearAleatorio()
    //    {
    //        return base.crearAleatorio();
    //    }
        
    //    public AlumnoAdapter fabricarAleatorio()
    //    {
    //        return new AlumnoAdapter(((Alumno)crearAleatorio()));
    //    }
    //    public IAlumno FabricarAleatorio()
    //    {
    //        return base.crearAleatorio();
    //    }
    //    public CalificacionAlumnoConPromocion Fabricar()
    //    {

    //    }
        
    //}
}

