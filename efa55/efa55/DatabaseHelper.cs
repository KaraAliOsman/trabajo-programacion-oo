using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.IO;
namespace efa55
{
    public class DatabaseHelper
    {
        private static string dbFileName = "mi_base_de_datos_efa55.db";
        private static string dbPath = Path.Combine(AppContext.BaseDirectory, dbFileName);
        private static string stringConexion = $"Data Source={dbPath}";

        public static void InitializeDatabase()
        {
            SQLitePCL.Batteries_V2.Init();

            using (var conexion = new SqliteConnection(stringConexion))
            {
                conexion.Open();
                var comandoCrearTabla = conexion.CreateCommand();
                comandoCrearTabla.CommandText = @"
                    CREATE TABLE IF NOT EXISTS personas (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        nombre TEXT,
                        apellido TEXT,
                        celular TEXT
                    );";
                comandoCrearTabla.ExecuteNonQuery();
            }
        }

        public static DataTable CargarPersonas()
        {
            DataTable dt = new DataTable();
            using (var conexion = new SqliteConnection(stringConexion))
            {
                conexion.Open();
                string sql = "SELECT id, nombre, apellido, celular FROM personas";
                using (var comando = new SqliteCommand(sql, conexion))
                {
                    using (var reader = comando.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        public static void CrearPersona(string nombre)
        {
            using (var conexion = new SqliteConnection(stringConexion))
            {
                conexion.Open();
                var comando = conexion.CreateCommand();
                comando.CommandText = "INSERT INTO personas (nombre) VALUES (@nombre)";
                comando.Parameters.AddWithValue("@nombre", nombre ?? (object)DBNull.Value);
                comando.ExecuteNonQuery();
            }
        }

        public static bool EliminarPersonaPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return false;

            using (var conexion = new SqliteConnection(stringConexion))
            {
                conexion.Open();
                var comando = conexion.CreateCommand();
                comando.CommandText = "DELETE FROM personas WHERE LOWER(nombre) = LOWER(@nombre)";
                comando.Parameters.AddWithValue("@nombre", nombre);
                int rowsAffected = comando.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public static void ActualizarPersona(int id, string nombre, string apellido, string celular)
        {
            using (var conexion = new SqliteConnection(stringConexion))
            {
                conexion.Open();
                var comando = conexion.CreateCommand();
                comando.CommandText = @"
                    UPDATE personas
                    SET nombre = @nombre,
                        apellido = @apellido,
                        celular = @celular
                    WHERE id = @id";
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nombre", nombre ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@apellido", apellido ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@celular", celular ?? (object)DBNull.Value);
                comando.ExecuteNonQuery();
            }
        }
    }
}