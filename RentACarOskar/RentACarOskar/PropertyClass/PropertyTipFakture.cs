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
    class PropertyTipFakture : PropertyInterface
    {
        #region Attributes
        [DisplayName("Tip fakture ID")]
        [SqlName("TipFaktureID")]
        [LookupKey]
        [PrimaryKey]
        public int TipFaktureID { get; set; }

        [DisplayName("Naziv tipa")]
        [SqlName("NazivTipa")]
        [LookupValue]
        public string NazivTipa { get; set; }
        #endregion

        #region Parameters
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@NazivTipa", System.Data.SqlDbType.VarChar);
                parameter.Value = NazivTipa;
                lista.Add(parameter);
            }
            return lista;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@TipFaktureID", System.Data.SqlDbType.Int);
                parameter.Value = TipFaktureID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@NazivTipa", System.Data.SqlDbType.VarChar);
                parameter.Value = NazivTipa;
                lista.Add(parameter);
            }
            return lista;
        }

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@TipFaktureID", System.Data.SqlDbType.Int);
                parameter.Value = TipFaktureID;
                lista.Add(parameter);
            }
            return lista;
        }
        #endregion

        #region Queries
        public string GetSelectQuery()
        {
            return @"SELECT TipFaktureID,
                            NazivTipa
                    FROM dbo.TipFakture";
        }

        public string GetInsertQuery()
        {
            return @"INSERT INTO dbo.TipFakture
                  (NazivTipa)
                     VALUES (@NazivTipa)";
        }

        public string GetUpdateQuery()
        {
            return @"UPDATE dbo.TipFakture
                    SET NazivTipa = @NazivTipa
                    WHERE TipFaktureID = @TipFaktureID";
        }

        public string GetDeleteQuery()
        {
            return @" DELETE FROM dbo.TipFakture
                    WHERE TipFaktureID = @TipFaktureID";
        }

        public string GetLookupQuery()
        {
            throw new NotImplementedException();
        }

        public string GetLookupQuery(string ID)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
