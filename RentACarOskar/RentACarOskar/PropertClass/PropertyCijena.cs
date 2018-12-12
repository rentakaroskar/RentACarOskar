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
    public class PropertyCijena : PropertInterface
    {
                
        #region Attributes

        [DisplayName("Cijena ID")]
        [SqlName("CijenaID")]
        [PrimaryKey]
        public int CijenaID { get; set; }

        [DisplayName("Vozilo ID")]
        [SqlName("VoziloID")]
        public int VoziloID { get; set; }

        [DisplayName("Cijena po danu")]
        [SqlName("CijenaPoDanu")]
        public int CijenaPoDanu { get; set; }

        
        [DisplayName("Datum cijene")]
        [SqlName("DatumCijene")]
        public int DatumCijene { get; set; }


        #endregion


        #region Parameters
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> parametri = new List<SqlParameter>();
            {
                SqlParameter novi = new SqlParameter("@CijenaID", System.Data.SqlDbType.Int);
                novi.Value = CijenaID;
                parametri.Add(novi);

            }
            return parametri;
        }

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> parametri = new List<SqlParameter>();
            {
                SqlParameter novi = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                novi.Value = VoziloID;
                parametri.Add(novi);

            }
            {
                SqlParameter novi = new SqlParameter("@CijenaPoDanu", System.Data.SqlDbType.Decimal);
                novi.Value = CijenaPoDanu;
                parametri.Add(novi);
            }
            {
                SqlParameter novi = new SqlParameter("@DatumCijene", System.Data.SqlDbType.Int);
                novi.Value = DatumCijene;
                parametri.Add(novi);
            }
            return parametri;
        }


        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> parametri = new List<SqlParameter>();
            {
                SqlParameter novi = new SqlParameter("@CijenaID", System.Data.SqlDbType.Int);
                novi.Value = CijenaID;
                parametri.Add(novi);

            }
            {
                SqlParameter novi = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                novi.Value = VoziloID;
                parametri.Add(novi);

            }
            {
                SqlParameter novi = new SqlParameter("@CijenaPoDanu", System.Data.SqlDbType.Decimal);
                novi.Value = CijenaPoDanu;
                parametri.Add(novi);
            }
           
            {
                SqlParameter novi = new SqlParameter("@DatumCijene", System.Data.SqlDbType.Int);
                novi.Value = DatumCijene;
                parametri.Add(novi);
            }
            return parametri;
        }
        #endregion


        #region Queries
        public string GetDeleteQuery()
        {
            return @"DELETE FROM [dbo].[Cijena]
                    WHERE [CijenaID] = @CijenaID";
        }

        public string GetInsertQuery()
        {
            return @"
                    INSERT INTO [dbo].[Cijena]
                         ([VoziloID]
                         ,[CijenaPoDanu]
                        ,[DatumCijene])
                     VALUES
                     (@VoziloID
                     ,@CijenaPoDanu
                     ,@DatumCijene)";
        }

        public string GetSelectQuery()
        {
            return @"SELECT [CijenaID]
                    ,[VoziloID]
                    ,[CijenaPoDanu]
                    ,[DatumCijene]
                     FROM [dbo].[Cijena]";
        }

        

        public string GetUpdateQuery()
        {
            return @"UPDATE [dbo].[Cijena]
                     SET [VoziloID] = VoziloID
                     ,[CijenaPoDanu] = @CijenaPoDanu
                     ,[DatumCijene] = @DatumCijene
                     WHERE [CijenaID] = @CijenaID";
        }
        #endregion
    }
}
