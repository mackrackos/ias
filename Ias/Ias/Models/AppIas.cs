using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Ias.Models
{
    public class AppIas
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Url { get; set; }

        public List<AppIas> GetApps()
        {
            var conn =
                new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConn"].ConnectionString);

            var command =
                new MySqlCommand("SELECT id_app, nombre, descripcion, fecha_creacion, url  FROM ias.apps", conn);

            var da = new MySqlDataAdapter(command);
            var ds = new DataSet();
            da.Fill(ds);

            var apps = new List<AppIas>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                var app = new AppIas();
                app.Id = Convert.ToInt32(dr["id_app"]);
                app.Nombre = dr["nombre"].ToString();
                app.Descripcion = dr["descripcion"].ToString();
                app.FechaCreacion = Convert.ToDateTime(dr["fecha_creacion"]);
                app.Url = dr["url"].ToString();

                apps.Add(app);
            }

            return apps;
        }

        public AppIas GetApps(int idApp)
        {
            var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConn"].ConnectionString);

            var command = new MySqlCommand( "SELECT id_app, nombre, descripcion, fecha_creacion, url  FROM 'ias'.'apps'" +
                                           $" WHERE id_app = {idApp};", conn);
            
            var da = new MySqlDataAdapter(command);
            var ds = new DataSet();
            da.Fill(ds);

            var appIas = new AppIas();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                appIas.Id = Convert.ToInt32(dr["id_app"]);
                appIas.Nombre = dr["nombre"].ToString();
                appIas.Descripcion = dr["descripcion"].ToString();
                appIas.FechaCreacion = Convert.ToDateTime(dr["fecha_creacion"]);
                appIas.Url = dr["url"].ToString();
            }


            return appIas;
        }

        public int InsertApps(AppIas appIas)
        {
            var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConn"].ConnectionString);

            var command = 
                new MySqlCommand("INSERT INTO `ias`.`apps` (`id_app`, `nombre`, `descripcion`, `fecha_creacion`, `url`) " +
                                 $"VALUES ((select MAX (id_app) + 1 from `ias`.`apps`), '{appIas.Nombre}', '{appIas.Descripcion}', now(),'{appIas.Url}');", conn);
            
            var filasAfectadas = command.ExecuteNonQuery();
            return filasAfectadas;
            return 1;
        }

        public int UpdateApps(AppIas appIas)
        {
            var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConn"].ConnectionString);

            var command = 
                new MySqlCommand($"UPDATE `ias`.`apps` SET `nombre` = '{appIas.Nombre}',`descripcion1` = '{appIas.Descripcion}', " +
                                 $" `fecha_creacion` = now(), `url` = '{appIas.Url}' WHERE `id_app = {appIas.Id};", conn);

            var filaAfectadas = command.ExecuteNonQuery();

            return filaAfectadas;
        }

        public int DeleteApps(int idApp)
        {
            var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConn"].ConnectionString);
            var command = 
                new MySqlCommand($"DELETE `ias`.`apps`  WHERE `id_app = {idApp};", conn);

            var filasAfectadas = command.ExecuteNonQuery();
            return filasAfectadas;
        }
    }
}