using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Modelo de clases usadas en la aplicacion de Cinemix
/// </summary>
/// 
namespace BaseDatosCinemix
{
    //Clase para manejar informacion especifica de la BD en forma de objeto
    //para las peliculas que pertenecena un cine
    public class InfoCinePelicula
    {
        public int IdCinePelicula { get; set; }
        public int IdCine { get; set; }
        public string Titulo { get; set; }
        public string Clasificacion { get; set; }
        public int Duracion { get; set; }
        public string Sinopsis { get; set; }
        public string ArchivoImg { get; set; }
    }


    //Clase de soporte para el manejo de la Base de Datos de Cinemx a
    //través de las entidades creadas por EntityFramework.
    //Se realizan distintos tipos de consutas con LINQ.
    //
    //Todos los métodos son estáticos, es decir no se quiere de la
    //creación de un objeto o instancia de la clase para invocar a los métodos
    public class DataManager
    {
        /// <summary>
        /// Regresa una lista de todas las ciudades de la BD
        /// </summary>
        /// <returns></returns>
        public static List<Ciudad> GetCiudades()
        {
            using (CinemixEntities bd = new CinemixEntities())
            {
                var ciudades = from c in bd.Ciudad
                               select c;
                return ciudades.ToList();
            }
        }

        /// <summary>
        /// Regresa una lista de todos los cines de una ciudad
        /// </summary>
        /// <param name="ciudad"></param>
        /// <returns></returns>
        public static List<Cine> GetCines(int ciudad)
        {

            /* Usa LINQ para hacer una consulta que permita obtener
             * todos los registros de la tabla Cine donde el id de la ciudad 
             * sea igual con el parametro que esta recibiendo este método
             * 
             * Regresa los resultados de la consulta convertidos en lista
             */
        }

        /// <summary>
        /// Regresa una lista de todas las peliculas que se proyectan en un cine específico
        /// </summary>
        /// <param name="cine"></param>
        /// <returns></returns>
        public static List<InfoCinePelicula> GetPeliculasDelCine(int cine)
        {
            using (CinemixEntities bd = new CinemixEntities())
            {
                var cinePeliculas = from cp in bd.CinePelicula
                                    join peli in bd.Pelicula on cp.idPelicula equals peli.IdPelicula
                                    where cp.idCine == cine
                                    select new InfoCinePelicula
                                    {
                                        IdCinePelicula = cp.IdCinePelicula,
                                        IdCine = cp.idCine,
                                        Titulo = peli.titulo,
                                        Clasificacion = peli.clasificacion,
                                        Duracion = peli.duracion,
                                        ArchivoImg = peli.archivoImg,
                                        Sinopsis = peli.sinposis
                                    };

                return cinePeliculas.ToList();
            }
        }

        /// <summary>
        /// Regresa el nombre de un Cine a través de su id
        /// </summary>
        /// <param name="cine"></param>
        /// <returns></returns>
        public static String GetNomCine(int idCine)
        {
            using (CinemixEntities bd = new CinemixEntities())
            {
                var nombre = from c in bd.Cine
                             where c.IdCine == idCine
                             select c.nombre;

                return nombre.ToList().First();
            }
        }

        /// <summary>
        /// Regresa una lista de todos los horarios de una pelicula de un cine específico
        /// </summary>
        /// <param name="pelicula"></param>
        /// <returns></returns>
        public static List<string> GetHorarios(int idPelicula)
        {
            /* Usa LINQ para hacer una consulta que permita obtener
             * todos los registros de la tabla Horario donde el idCinePelicula 
             * sea igual con el parametro que esta recibiendo este método
             * 
             * Regresa los resultados de la consulta convertidos en lista
             */

        }

        /// <summary>
        /// Regresa informacion general de una pelicula que se proyecta en un Cine especifico
        /// </summary>
        /// <param name="idCinePel"></param>
        /// <returns></returns>
        public static InfoCinePelicula GetPelicula(int idCinePel)
        {
            using (CinemixEntities bd = new CinemixEntities())
            {
                var cinePeliculas = from cp in bd.CinePelicula
                                    join peli in bd.Pelicula on cp.idPelicula equals peli.IdPelicula
                                    where cp.IdCinePelicula == idCinePel
                                    select new InfoCinePelicula
                                    {
                                        IdCinePelicula = cp.IdCinePelicula,
                                        IdCine = cp.idCine,
                                        Titulo = peli.titulo,
                                        Clasificacion = peli.clasificacion,
                                        Duracion = peli.duracion,
                                        ArchivoImg = peli.archivoImg,
                                        Sinopsis = peli.sinposis
                                    };
                return cinePeliculas.FirstOrDefault();
            }
        }

    }
}
