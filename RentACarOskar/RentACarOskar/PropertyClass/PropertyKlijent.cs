using RentACarOskar.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarOskar.PropertyClass
{
    class PropertyKlijent : PropertyInterface
    {
        #region Attributes
        [SqlName("KlijentID")]
        [DisplayName("Klijent ID")]
        [PrimaryKey]
        [LookupKey]
        public int KlijentID { get; set; }

        [SqlName("OsobaID")]
        [DisplayName("Osoba ID")]
        [ForeignKey("Osoba", "OsobaID", "RentACarOskar.PropertyClass.PropertyOsoba")]
        [LookupValue]
        public int OsobaID { get; set; }

        [SqlName("BrojVozacke")]
        [DisplayName("Broj vozacke")]
        public string BrojVozacke { get; set; }
        #endregion

        #region Parameters
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@OsobaID", System.Data.SqlDbType.Int);
                parameter.Value = OsobaID;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@BrojVozacke", System.Data.SqlDbType.NVarChar);
                parameter.Value = BrojVozacke;
                parameters.Add(parameter);
            }
            return parameters;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@KlijentID", System.Data.SqlDbType.Int);
                parameter.Value = KlijentID;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@OsobaID", System.Data.SqlDbType.Int);
                parameter.Value = OsobaID;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@BrojVozacke", System.Data.SqlDbType.NVarChar);
                parameter.Value = BrojVozacke;
                parameters.Add(parameter);
            }
            return parameters;
        }

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@KlijentID", System.Data.SqlDbType.Int);
                parameter.Value = KlijentID;
                parameters.Add(parameter);
            }
            return parameters;
        }
        #endregion
        
        #region Queries
        public string GetSelectQuery()
        {
            return @"SELECT [KlijentID]
                            ,[OsobaID]
                            ,[BrojVozacke]
                    FROM [dbo].[Klijent]";
        }

        public string GetInsertQuery()
        {
            return @"INSERT INTO [dbo].[Klijent]
                            ([OsobaID]
                            ,[BrojVozacke])
                        VALUES
                            (@OsobaID,
                            @BrojVozacke)";
        }

        public string GetUpdateQuery()
        {
            return @"UPDATE [dbo].[Klijent]
                        SET [OsobaID] = @OsobaID
                           ,[BrojVozacke] = @BrojVozacke
                        WHERE [KlijentID] = @KlijentID";
        }

        public string GetDeleteQuery()
        {
            return @"DELETE FROM [dbo].[Klijent]
                    WHERE [KlijentID] = @KlijentID";
        }

        public string GetLookupQuery(string ID)
        {
            return @"SELECT [OsobaID],
                            [BrojVozacke]
                    FROM [dbo].[Klijent]
                    WHERE [KlijentID] = " + ID;
        }

        public string GetSelectQueryZaJedanItem(string broj)
        {
            return @"SELECT [KlijentID],
                            [OsobaID],
                            [BrojVozacke]
                    FROM [dbo].[Klijent]
                    WHERE [KlijentID] = " + broj;
        }

        public string GetSelectQueryZaFakturu()
        {
            return @"SELECT k.[KlijentID],
                            o.Ime,
                            o.Prezime,
                            k.[BrojVozacke]
                    FROM [dbo].[Klijent] AS k
	                    JOIN [dbo].Osoba AS o
	                    	ON k.OsobaID = o.OsobaID";
        }


        #endregion
    }
}
