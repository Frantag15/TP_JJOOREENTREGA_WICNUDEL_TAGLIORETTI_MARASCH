using System.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;

namespace TP_JJOOREENTREGA_WICNUDEL_TAGLIORETTI_MARASCH.Models;


public class BD{
  private static string _connectionstring = @"Server = localhost; DataBase = JJOO(BD); Trusted_Connection = True;";

    public static void AgregarDeportista(Deportistas dep)
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string sql = "INSERT INTO Deportistas (Apellido, Nombre, FechaNacimiento, Foto, IdPais, IdDeporte) VALUES (@Apellido, @Nombre, @FechaNacimiento, @Foto, @IdPais, @IdDeporte)";
            db.Execute(sql, dep);
        }
    }

    public static void EliminarDeportista(int idDeportista)
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string sql = "DELETE FROM Deportistas WHERE IdDeportista = @IdDeportista";
            db.Execute(sql, new { IdDeportista = idDeportista });
        }
    }

    public static Deporte VerInfoDeporte(int idDeporte)
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string sql = "SELECT * FROM Deportes WHERE IdDeporte = @IdDeporte";
            return db.QueryFirstOrDefault<Deporte>(sql, new { IdDeporte = idDeporte });
        }
    }

    public static Pais VerInfoPais(int idPais)
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string sql = "SELECT * FROM Paises WHERE IdPais = @IdPais";
            return db.QueryFirstOrDefault<Pais>(sql, new { IdPais = idPais });
        }
    }

    public static Deportistas VerInfoDeportista(int idDeportista)
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string sql = "SELECT * FROM Deportistas WHERE IdDeportista = @IdDeportista";
            return db.QueryFirstOrDefault<Deportistas>(sql, new { IdDeportista = idDeportista });
        }
    }

    public static List<Pais> ListarPaises()
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string sql = "SELECT * FROM Paises";
            return db.Query<Pais>(sql).ToList();
        }
    }

    public static List<Deporte> ListarDeportes()
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string sql = "SELECT * FROM Deportes";
            return db.Query<Deporte>(sql).ToList();
        }
    }

    public static List<Deportistas> ListarDeportistasPorDeporte(int idDeporte)
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string sql = "SELECT * FROM Deportistas WHERE IdDeporte = @IdDeporte";
            return db.Query<Deportistas>(sql, new { IdDeporte = idDeporte }).ToList();
        }
    }

    public static List<Deportistas> ListarDeportistasPorPais(int idPais)
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string sql = "SELECT * FROM Deportistas WHERE IdPais = @IdPais";
            return db.Query<Deportistas>(sql, new { IdPais = idPais }).ToList();
        }
    }
}
