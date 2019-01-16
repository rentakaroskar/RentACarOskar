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
    public class PropertyCijena : PropertyInterface
    {
        #region Attributes

        [DisplayName("Cijena ID")]
        [SqlName("CijenaID")]
        [PrimaryKey]
        [LookupKey]
        public int CijenaID { get; set; }

        [DisplayName("Vozilo ID")]
        [SqlName("VoziloID")]
        [ForeignKey("Vozilo", "VoziloID", "RentACarOskar.PropertyClass.PropertyVozilo")]
        [LookupValue]
        public int VoziloID { get; set; }

        [DisplayName("Cijena po danu")]
        [SqlName("CijenaPoDanu")]
        public decimal CijenaPoDanu { get; set; }

        [DisplayName("Datum cijene")]
        [SqlName("DatumCijene")]
        public DateTime DatumCijene { get; set; }


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
                SqlParameter novi = new SqlParameter("@DatumCijene", System.Data.SqlDbType.DateTime);
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
                SqlParameter novi = new SqlParameter("@DatumCijene", System.Data.SqlDbType.DateTime);
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
                     ((SELECT MAX(VoziloID)
                        FROM dbo.Vozilo)
                     ,0
                     ,GETDATE())";
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
            return @"INSERT INTO [dbo].[Cijena]
                     ([VoziloID]
                     ,[CijenaPoDanu]
                     ,[DatumCijene])
                     VALUES
                     (@VoziloID
                     ,@CijenaPoDanu
                     ,GETDATE())";
        }

        public string GetLookupQuery(string ID)
        {
            return @"SELECT 
                    [VoziloID]
                    FROM [dbo].[Cijena]
                    WHERE [CijenaID] = " + ID;
        }

        public string GetSelectQueryZaJedanItem(string broj)
        {
            return @"SELECT c.[CijenaID]
                    ,c.[VoziloID]
                    ,c.[CijenaPoDanu]
                    ,c.[DatumCijene]
                    FROM [dbo].[Cijena] as c
                        JOIN (SELECT c1.VoziloID, max(c1.DatumCijene) as DatumCijene
					          FROM [dbo].[Cijena] as c1 GROUP BY c1.VoziloID) as c1
					       on c1.VoziloID = c.VoziloID
                    WHERE (c1.VoziloID = c.VoziloID and  c.[DatumCijene] =c1.[DatumCijene])
                    and c.VoziloID =" + broj;
        }
        #endregion
    }
}
