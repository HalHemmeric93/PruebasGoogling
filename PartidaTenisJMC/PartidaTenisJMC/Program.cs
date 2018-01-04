using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using PartidaTenisJMC_Services.Control;
using System.Threading;
namespace PartidaTenisJMC
{
    class Program
    {
        static readonly Container container;
        static Program()
        {
            container = new Container();
            container.Register<IPartidaTenisJMCControl, PartidaTenisJMCControl>();
            container.Verify();
        }
        static void Main(string[] args)
        {
            var control = container.GetInstance<IPartidaTenisJMCControl>();
            Console.Write("Nombre jugador 1: ");
            control.crearUsuario1(Console.ReadLine());
            Console.Write("Nombre jugador 2: ");
            control.crearUsuario2(Console.ReadLine());
            Console.WriteLine("el partido será a 3 ó 5 sets?");
            control.crearPartida(int.Parse(Console.ReadLine()));
            
            control.seleccionarJugadorPrincipal();
            Console.WriteLine("{0} iniciará el partido sacando", control.nombreJugadorPrincipal());
            
            foreach (var st in control.getSets())
            {
                while (true)
                {
                control.addJugada(st.numSet);
                Console.WriteLine("** Juego {0} - Set {1}", control.totalJugadasSet(st.numSet), st.numSet);
                while (true)
                {
                    Console.WriteLine("Punto de {0} {1} {2}", control.lanzamiento(), control.OrdenarPuntos(), control.PintarJuegos());
                    if (control.FinJugada())
                    {
                        Console.WriteLine("{0} gana el juego{1}", control.AddPuntosJugador(st.numSet), control.PintarJuegos());
                        control.reiniciarMarcador();
                        break;
                    }
                    Thread.Sleep(300); 
                }
                if (!control.EndSet(st.numSet))
                {
                    control.SetJugadorPrincipal();
                }
                else
                {
                    break;
                }
               
                }   
            }
            Console.WriteLine("!!{0} GANA EL PARTIDO¡¡{1}", control.getGanador(), control.PintarJuegos());
            Console.ReadLine();
        }
    }
}
