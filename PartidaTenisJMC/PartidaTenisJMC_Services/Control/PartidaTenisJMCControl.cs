using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartidaTenisJMC_Services.Clases;
namespace PartidaTenisJMC_Services.Control
{
    public interface IPartidaTenisJMCControl
    {
         void crearUsuario1(string nombreJugador);
         void crearUsuario2(string nombreJugador);
         void crearPartida(int numSets);
         void seleccionarJugadorPrincipal();
         string nombreJugadorPrincipal();
         List<Set> getSets();
         void addJugada(int numSet);
         int totalJugadasSet(int numSet);
         string lanzamiento();
         void reiniciarMarcador();
         string PintarPuntuacion(int puntuacion);
         string OrdenarPuntos();
         string PintarJuegos();
         bool FinJugada();
         string AddPuntosJugador(int set);
         bool EndSet(int set);
         void SetJugadorPrincipal();
         string getGanador();
    }
    public class PartidaTenisJMCControl : IPartidaTenisJMCControl
    {
        public Jugador jugador1 { get; set; }
        public Jugador jugador2 { get; set; }
        public Partida partida { get; set; }
        
        public int puntosJugador1 = 0;
        public int puntosJugador2 = 0;

        public void crearUsuario1(string nombreJugador)
        {
           jugador1 = new Jugador(nombreJugador);
        }
        public void crearUsuario2(string nombreJugador)
        {
           jugador2 = new Jugador(nombreJugador);
        }
        public void crearPartida(int numSets)
        {
           partida = new Partida(jugador1, jugador2, numSets);
        }
        public void seleccionarJugadorPrincipal()
        {
            if (new Random().Next(0, 2) == 1)
            {
                partida.jugadorPrincipal1 = false;
            }
        }
        public string nombreJugadorPrincipal()
        {
            if (partida.jugadorPrincipal1 == true)
            {
                return partida.jugador1.name;
            }
            else
            {
                return partida.jugador2.name;
            }
        }
        public List<Set> getSets()
        {
            return partida.sets;
        }
        public void addJugada(int numSet)
        {
            partida.sets.Find(x => x.numSet.Equals(numSet)).jugadas.Add(
                new Jugada(partida.sets.Find(x => x.numSet.Equals(numSet)).jugadas.Count+1));
        }
        public int totalJugadasSet(int numSet)
        {
            return partida.sets.Find(x => x.numSet.Equals(numSet)).jugadas.Count();
        }
        public string lanzamiento()
        {
           int jugador = new Random().Next(0, 2);
           if (jugador==0) {
               
                   puntosJugador1++;
                   return partida.jugador1.name;
           }
           else
           {
                   puntosJugador2++;
                   return partida.jugador2.name;
           }
        }
        public string OrdenarPuntos()
        {
            string resp = "";
            if (partida.jugadorPrincipal1==true)
            {
                resp = resp + PintarPuntuacion(puntosJugador1) + "-" + PintarPuntuacion(puntosJugador2);
            }
            else
            {
                resp = resp + PintarPuntuacion(puntosJugador2) + "-" + PintarPuntuacion(puntosJugador1);
            }
            return resp;
        }

        public void reiniciarMarcador()
        {
            puntosJugador1 = 0;
            puntosJugador2 = 0;
        }

        public string PintarPuntuacion(int puntuacion)
        {
            string resultado = "";
            switch (puntuacion)
            {
                case 0:
                    resultado = "0";
                    break;
                case 1:
                    resultado = "15";
                    break;
                case 2:
                    resultado = "30";
                    break;
                case 3:
                    resultado = "40";
                    break;
                default:
                    resultado = "Ad";
                    break;
            }
            return resultado;
        }
        public string PintarJuegos()
        {

            string respuesta = "\t\t (";
            int a = 0;
            foreach (int i in partida.puntosSets)
            {

                if ((a % 2) == 0)
                {
                    respuesta = respuesta + i + "-";
                }
                else
                {
                    respuesta = respuesta + i;

                    if (a + 1 != partida.puntosSets.Length)
                    {
                        respuesta = respuesta + ", ";
                    }
                }
                a++;
            }
            respuesta = respuesta + ")";
            return respuesta;
        }

        public bool FinJugada()
        {
            bool resp = false;
            if ((puntosJugador1 > 3 && puntosJugador1 - puntosJugador2 >= 2) ||
                (puntosJugador2 > 3 && puntosJugador2 - puntosJugador1 >= 2))
            {
                resp = true;
            }
            return resp;
        }

        public string AddPuntosJugador(int set)
        {
            if(puntosJugador1>puntosJugador2&&partida.jugadorPrincipal1){
                partida.puntosSets[set - 1, 0] = partida.puntosSets[set - 1, 0] + 1;
                return partida.jugador1.name;
            }
            else
            {
                partida.puntosSets[set - 1, 1] = partida.puntosSets[set - 1, 1] + 1;
                return partida.jugador2.name;
            }
        }

        public bool EndSet(int set)
        {
            bool salida = false;

            if ((partida.puntosSets[set - 1, 0] >= 6 && partida.puntosSets[set - 1, 0] - partida.puntosSets[set - 1, 1] >= 2)
                || (partida.puntosSets[set - 1, 1] >= 6 && partida.puntosSets[set - 1, 1] - partida.puntosSets[set - 1, 0] >= 2))
            {
                salida = true;
            }
            return salida;
        }
        public void SetJugadorPrincipal()
        {
            if(partida.jugadorPrincipal1){
                partida.jugadorPrincipal1= false;
            }else{
                partida.jugadorPrincipal1= true;
            }
        }
        public string getGanador()
        {
            int ganadoJugador1 = 0;
            int ganadoJugador2 = 0;

            for (int i = 0; i < partida.numSets; i++)
            {
                if (partida.puntosSets[i, 0] > partida.puntosSets[i, 1])
                {
                    ganadoJugador1++;
                }
                else
                {
                    ganadoJugador2++;
                }
            }
            if (ganadoJugador1 > ganadoJugador2)
            {
                return partida.jugador1.name;
            }
            else
            {
                return partida.jugador2.name;
            }
        }
    }
}
