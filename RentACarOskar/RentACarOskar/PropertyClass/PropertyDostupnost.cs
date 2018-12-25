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
    class PropertyDostupnost : PropertyInterface
    {
        #region Attributes
        [DisplayName("Dostupnost ID")]
        [SqlName("DostupnostID")]
        [PrimaryKey]
        public int DostupnostID { get; set; }

        [DisplayName("Tip dostupnosti")]
        [SqlName("TipDostupnosti")]
        public string TipDostupnosti { get; set; }
        #endregion

        #region Parameters
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@DostupnostID", System.Data.SqlDbType.Int);
                parameter.Value = DostupnostID;
                parameters.Add(parameter);
            }
            return parameters;
        }
        
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@TipDostupnosti", System.Data.SqlDbType.NVarChar);
                parameter.Value = TipDostupnosti;
                parameters.Add(parameter);
            }
            return parameters;
        }
        
        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@DostupnostID", System.Data.SqlDbType.Int);
                parameter.Value = DostupnostID;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@TipDostupnosti", System.Data.SqlDbType.NVarChar);
                parameter.Value = TipDostupnosti;
                parameters.Add(parameter);
            }
            return parameters;
        }
        #endregion

        #region Queries
        public string GetSelectQuery()
        {
            return @"SELECT 
                        DostupnostID,
                        TipDostupnosti
                     FROM dbo.Dostupnost";
        }

        public string GetInsertQuery()
        {
            return @"INSERT INTO dbo.Dostupnost
                        (TipDostupnosti)
                    VALUES (@TipDostupnosti)";
        }

        public string GetUpdateQuery()
        {
            return @"UPDATE dbo.Dostupnost
                    SET TipDostupnosti = @TipDostupnosti
                    WHERE DostupnostID = @DostupnostID";
        }

        public string GetDeleteQuery()
        {
            return @"DELETE FROM dbo.Dostupnost
                    WHERE DostupnostID = @DostupnostID";
        }

        public string GetLookupQuery(string ID)
        {
            return @"SELECT
                        TipDostupnosti
                     FROM dbo.Dostupnost
                     WHERE DostupnostID = " + ID;
        }

        public string GetSelectQueryZaJedanItem(string broj)
        {
            return @"SELECT 
                        DostupnostID,
                        TipDostupnosti
                     FROM dbo.Dostupnost
                     WHERE DostupnostID = " + broj;
        }
        #endregion
    }
}
