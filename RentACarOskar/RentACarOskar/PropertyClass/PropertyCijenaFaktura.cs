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
    public class PropertyCijenaFaktura : PropertyInterface
    {
        #region Attributes

        [DisplayName("Cijena faktura ID")]
        [SqlName("CijenaFakturaID")]
        [PrimaryKey]
        public int CijenaFakturaID { get; set; }

        [DisplayName("Cijena ID ")]
        [SqlName("CijenaID")]
        [ForeignKey("Cijena", "CijenaID", "RentACarOskar.PropertyClass.PropertyCijena")]
        public int CijenaID { get; set; }

        [DisplayName("Faktura ID")]
        [SqlName("FakturaID")]
        [ForeignKey("Faktura", "FakturaID", "RentACarOskar.PropertyClass.PropertyFaktura")]
        public int FakturaID { get; set; }

        [DisplayName("Broj dana")]
        [SqlName("BrojDana")]
        public int BrojDana { get; set; }
        

        #endregion

        #region Parameters
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> parametri = new List<SqlParameter>();
            {
                SqlParameter novi = new SqlParameter("@CijenaFakturaID", System.Data.SqlDbType.Int);
                novi.Value = CijenaFakturaID;
                parametri.Add(novi);

            }
            return parametri;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> parametri = new List<SqlParameter>();
            {
                SqlParameter novi = new SqlParameter("@CijenaFakturaID", System.Data.SqlDbType.Int);
                novi.Value = CijenaFakturaID;
                parametri.Add(novi);

            }
            {
                SqlParameter novi = new SqlParameter("@CijenaID", System.Data.SqlDbType.Int);
                novi.Value = CijenaID;
                parametri.Add(novi);

            }
            {
                SqlParameter novi = new SqlParameter("@FakturaID", System.Data.SqlDbType.Int);
                novi.Value = FakturaID;
                parametri.Add(novi);

            }
            {
                SqlParameter novi = new SqlParameter("@BrojDana", System.Data.SqlDbType.Int);
                novi.Value = BrojDana;
                parametri.Add(novi);

            }
            return parametri;
        }

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> parametri = new List<SqlParameter>();
           
            {
                SqlParameter novi = new SqlParameter("@CijenaID", System.Data.SqlDbType.Int);
                novi.Value = CijenaID;
                parametri.Add(novi);

            }
            {
                SqlParameter novi = new SqlParameter("@FakturaID", System.Data.SqlDbType.Int);
                novi.Value = FakturaID;
                parametri.Add(novi);

            }
            {
                SqlParameter novi = new SqlParameter("@BrojDana", System.Data.SqlDbType.Int);
                novi.Value = BrojDana;
                parametri.Add(novi);

            }
            return parametri;
        }
        #endregion

        #region Queries
        public string GetDeleteQuery()
        {
            return @"DELETE FROM [dbo].[CijenaFaktura]
                     WHERE [CijenaFakturaID] = @CijenaFakturaID";
        }
        
        public string GetInsertQuery()
        {
            return @"INSERT INTO [dbo].[CijenaFaktura]
                    ([CijenaID]
                    ,[FakturaID]
                    ,[BrojDana])
                     VALUES
                         (@CijenaID
                         ,@FakturaID
                        ,@BrojDana)";
        }

        public string GetSelectQuery()
        {
            return @"SELECT [CijenaFakturaID]
                        ,[CijenaID]
                        ,[FakturaID]
                        ,[BrojDana]
                        FROM [dbo].[CijenaFaktura]";
        }
        
        public string GetUpdateQuery()
        {
            return @"UPDATE [dbo].[CijenaFaktura]
                 SET [CijenaID] = @CijenaID
                    ,[FakturaID] = @FakturaID
                    ,[BrojDana] = @BrojDana
                WHERE [CijenaFakturaID] = @CijenaFakturaID";
        }
        #endregion
    }
}
