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
    class PropertyModelVozila: PropertyInterface
    {
        #region Atributi
        [DisplayName("Model ID")]
        [SqlName("ModelID")]
        [LookupKey]
        [PrimaryKey]
        public int ModelID { get; set; }
        [DisplayName("Naziv")]
        [SqlName("Naziv")]
        [LookupValue]
        public string Naziv { get; set; }
        [DisplayName("Proizvodjac ID")]
        [SqlName("ProizvodjacID")]
        [ForeignKey("Proizvodjac", "ProizvodjacID", "RentACarOskar.PropertyClass.PropertyProizvodjac")]
        [LookupValue]
        public int ProizvodjacID { get; set; }
        #endregion

        #region Parameters
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@Naziv", System.Data.SqlDbType.NVarChar);
                parameter.Value = Naziv;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@ProizvodjacID", System.Data.SqlDbType.Int);
                parameter.Value = ProizvodjacID;
                lista.Add(parameter);
            }
            return lista;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ModelID", System.Data.SqlDbType.Int);
                parameter.Value = ModelID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Naziv", System.Data.SqlDbType.NVarChar);
                parameter.Value = Naziv;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@ProizvodjacID", System.Data.SqlDbType.Int);
                parameter.Value = ProizvodjacID;
                lista.Add(parameter);
            }
            return lista;
        }

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ModelID", System.Data.SqlDbType.Int);
                parameter.Value = ModelID;
                lista.Add(parameter);
            }
            return lista;
        }
        #endregion

        #region Queries
        public string GetSelectQuery()
        {
            return @"SELECT[ModelID], [Naziv], [ProizvodjacID] FROM[dbo].[ModelVozila]";
        }

        public string GetSelectQueryZaModelVozila()
        {
            return @"SELECT [Naziv] FROM[dbo].[ModelVozila]";
        }

        public string GetInsertQuery()
        {
            return @"INSERT INTO[dbo].[ModelVozila]
                  ([Naziv],[ProizvodjacID])
                     VALUES (@Naziv, @ProizvodjacID)";
        }

        public string GetUpdateQuery()
        {
           return @"UPDATE[dbo].[ModelVozila] SET[Naziv] = @Naziv, [ProizvodjacID] = @ProizvodjacID
                    WHERE[ModelID] = @ModelID";
        }

        public string GetDeleteQuery()
        {
            return @" DELETE FROM[dbo].[ModelVozila]
                    WHERE[ModelID] = @ModelID";
        }

        public string GetLookupQuery(string ID)
        {
            return @"SELECT
                        [Naziv],
                        [ProizvodjacID]
                        FROM [dbo].[ModelVozila]
                    WHERE [ModelID] = " + ID;
        }

        public string GetSelectQueryZaJedanItem(string broj)
        {
            return $@"SELECT [ModelID], 
                             [Naziv], 
                             [ProizvodjacID]
                             FROM [dbo].[ModelVozila]
                             WHERE [ModelID] = {broj}";
        }

        public string GetSelectLookUp()
        {
            return @"SELECT 
	                mv.ModelID,
	                mv.Naziv AS Model,
	                p.Naziv AS Proizvodjac
                    FROM dbo.ModelVozila mv
	                    JOIN dbo.Proizvodjac p ON p.ProizvodjacID = mv.ProizvodjacID";
        }
        #endregion
    }
}
