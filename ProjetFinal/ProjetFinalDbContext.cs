using Microsoft.Data.SqlClient;
using ProjetFinal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.Diagnostics;

public class ProjetFinalDbContext 
{
    private string _connectionString;

    public string ConnectionString
    {
        get { return _connectionString; }
        set { _connectionString = value; }
    }

    public ProjetFinalDbContext(string connectionStringName)
    {
        ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
    }

    public List<Employes> GetAllEmployes()
    {
        List<Employes> employes = new List<Employes>();

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "SELECT * FROM Employes";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employes employe = new Employes();

                        employe.NumEmp = (int)reader["numemp"];
                        employe.Nom = (string)reader["nom"];
                        employe.Prenom = (string)reader["prenom"];
                        employe.Adresse = (string)reader["adresse"];
                        employe.Courriel = (string)reader["courriel"];
                        employe.Telephone = (string)reader["telephone"];

                        employes.Add(employe);
                    }
                }
            }
        }

        return employes;
    }

    public void AddEmploye(Employes employe)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "INSERT INTO Employes (nom, prenom, adresse, courriel, telephone) " +
                "VALUES (@nom, @prenom, @adresse, @courriel, @telephone)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nom", employe.Nom);
                command.Parameters.AddWithValue("@prenom", employe.Prenom);
                command.Parameters.AddWithValue("@adresse", employe.Adresse);
                command.Parameters.AddWithValue("@courriel", employe.Courriel);
                command.Parameters.AddWithValue("@telephone", employe.Telephone);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteEmploye(int numEmploye)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "DELETE FROM Employes WHERE numemp=@numemp";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@numemp", numEmploye);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public void UpdateEmploye(Employes employe)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "UPDATE Employes SET nom=@nom, prenom=@prenom, adresse=@adresse, " +
                "courriel=@courriel, telephone=@telephone WHERE numemp=@numemp";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nom", employe.Nom);
                command.Parameters.AddWithValue("@prenom", employe.Prenom);
                command.Parameters.AddWithValue("@adresse", employe.Adresse);
                command.Parameters.AddWithValue("@courriel", employe.Courriel);
                command.Parameters.AddWithValue("@telephone", employe.Telephone);
                command.Parameters.AddWithValue("@numemp", employe.NumEmp);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }



    public List<Projets> GetAllProjets()
    {
        List<Projets> projets = new List<Projets>();

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "SELECT * FROM Projets";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Projets projet = new Projets();

                        projet.NumProjet = (int)reader["numprojet"];
                        projet.Titre = (string)reader["titre"];
                        projet.NbHeuresPrevues = (int)reader["nbheureprevues"];

                        projets.Add(projet);
                    }
                }
            }
        }

        return projets;
    }

    public void AddProjet(Projets projet)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "INSERT INTO Projets (titre, nbheureprevues) " +
                "VALUES (@titre, @nbheureprevues)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@titre", projet.Titre);
                command.Parameters.AddWithValue("@nbheureprevues", projet.NbHeuresPrevues);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteProjet(int numProjet)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "DELETE FROM Projets WHERE numprojet=@numprojet";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@numprojet", numProjet);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public void UpdateProjet(Projets projet)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "UPDATE Projets SET titre=@titre, nbheureprevues=@nbheureprevues " +
                "WHERE numprojet=@numprojet";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@titre", projet.Titre);
                command.Parameters.AddWithValue("@nbheureprevues", projet.NbHeuresPrevues);
                command.Parameters.AddWithValue("@numprojet", projet.NumProjet);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public void AddTache(Taches tache)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "INSERT INTO Taches (numprojet, numemp, semaine, nbheures) " +
                "VALUES (@numprojet, @numemp, @semaine, @nbheures)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@numprojet", tache.NumProjet);
                command.Parameters.AddWithValue("@numemp", tache.NumEmp);
                command.Parameters.AddWithValue("@semaine", tache.Semaine);
                command.Parameters.AddWithValue("@nbheures", tache.NbHeures);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteTache(int idTache)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "DELETE FROM Taches WHERE id=@id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", idTache);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    
    public List<Taches> GetTachesParProjet(int numProjet)
    {
        List<Taches> taches = new List<Taches>();
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "SELECT * FROM Taches WHERE numprojet=@numprojet";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@numprojet", numProjet);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Taches tache = new Taches();
                        tache.Id = (int)reader["id"];
                        tache.NumProjet = (int)reader["numprojet"];
                        tache.NumEmp = (int)reader["numemp"];
                        tache.Semaine = (int)reader["semaine"];
                        tache.NbHeures = (int)reader["nbheures"];
                        taches.Add(tache);
                    }
                }
            }
        }
        return taches;
    }

}





