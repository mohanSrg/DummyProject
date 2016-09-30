using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;

public class DatabaseManager : MonoBehaviour
{

    private string connectionString;

    public Dictionary<string, List<string>> brandList;
    // Use this for initialization
    void Awake()
    {
        brandList = new Dictionary<string, List<string>>();
        
        brandList.Add("--Select Brand--", new List<string>() { "Select Variant"});
        connectionString = "URI=file:" + Application.dataPath + "/branddb.sqlite";
        GetBrands();
    }

    public void GetBrands()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM brands";

                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string brandName = reader.GetString(0);
                        if (!brandList.ContainsKey(brandName))
                        {
                            List<string> varients = GetVarients(brandName, dbConnection);
                            brandList.Add(brandName, varients);
                        }
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        Debug.Log(brandList);
    }
    private List<string> GetVarients(string brandName, IDbConnection dbConnection)
    {
        List<string> varients = new List<string>();
        using (IDbCommand dbCmd = dbConnection.CreateCommand())
        {
            string varientsQuery = "SELECT * FROM brands WHERE brand=\"" + brandName + "\"";
            dbCmd.CommandText = varientsQuery;
            using (IDataReader reader = dbCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    varients.Add(reader.GetString(1));
                }
            }
        }
        return varients;
    }
}