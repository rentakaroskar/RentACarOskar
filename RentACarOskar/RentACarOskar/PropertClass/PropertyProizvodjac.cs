using RentACarOskar.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarOskar.PropertClass
{
    class PropertyProizvodjac : PropertInterface
    {
        #region Atributi
        [DisplayName("ProizvodjacID")]
        [SqlName("ProizvodjacID")]
        [PrimaryKey]
        public int ProizvodjacID { get; set; }

        [DisplayName("Naziv")]
        [SqlName("Naziv")]
        public string Naziv { get; set; }

        #endregion
        #region Parameters
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ProizvodjacID", System.Data.SqlDbType.Int);
                parameter.Value = ProizvodjacID;
                lista.Add(parameter);
            }

            return lista;
        }
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@Naziv", System.Data.SqlDbType.NVarChar);
                parameter.Value = Naziv;
                lista.Add(parameter);
            }

            return lista;
        }
        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ProizvodjacID", System.Data.SqlDbType.Int);
                parameter.Value = ProizvodjacID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Naziv", System.Data.SqlDbType.NVarChar);
                parameter.Value = Naziv;
                lista.Add(parameter);
            }

            return lista;
        }
        #endregion
        #region Queries
        public string GetDeleteQuery()
        {
            return @"DELETE FROM [dbo].[Proizvodjac]
                     WHERE [ProizvodjacID] = @ProizvodjacID";
        }
        public string GetInsertQuery()
        {
            return @"INSERT INTO[dbo].[Proizvodjac]
                    ([Naziv])
                     VALUES(@Naziv)";
        }
    public string GetSelectQuery()
        {
            return @"SELECT [ProizvodjacID], [Naziv]
                     FROM [dbo].[Proizvodjac]";
        }
        public string GetUpdateQuery()
        {
            return @"UPDATE[dbo].[Proizvodjac]
                     SET[ProizvodjacID] = @ProizvodjacID, [Naziv] = @Naziv
                     WHERE[Proizvodjac] = @Proizvodjac";
        }
        #endregion
    }
}
