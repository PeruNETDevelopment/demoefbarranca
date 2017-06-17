using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace PruebaConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Inicio de la Aplicacion");
                var contexto = new BdSanPedro();
                var alumno1 = new Alumno
                {
                    Nombres = "Erick",
                    Apellidos = "Orlando",
                    Correo = "juaxxxxxnm@gmail.com",
                    Edad = 32,
                    FechaNacimiento = Convert.ToDateTime("01/01/2001")
                };

                contexto.Alumnos.Add(alumno1);

                contexto.SaveChanges();

                Console.WriteLine("Se insertó el registro");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.InnerException?.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
