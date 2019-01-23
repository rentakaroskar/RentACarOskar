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
    class PropertyFaktura : PropertyInterface
    {
        #region Attributes

        [DisplayName("Faktura ID")]
        [SqlName("FakturaID")]
        [PrimaryKey]
        public int FakturaID { get; set; }

        [DisplayName("Radnik ID")]
        [SqlName("RadnikID")]
        [ForeignKey("Radnik", "RadnikID", "RentACarOskar.PropertyClass.PropertyRadnik")]
        public int RadnikID { get; set; }

        [DisplayName("Klijent ID")]
        [SqlName("KlijentID")]
        [ForeignKey("Klijent", "KlijentID", "RentACarOskar.PropertyClass.PropertyKlijent")]
        public int KlijentID { get; set; }

        [DisplayName("TipFakture ID")]
        [SqlName("TipFaktureID")]
        [ForeignKey("TipFakture", "TipFaktureID", "RentACarOskar.PropertyClass.PropertyTipFakture")]
        public int TipFaktureID { get; set; }

        [DisplayName("Napomena")]
        [SqlName("Napomena")]
        [NotRequired]
        public string Napomena { get; set; } 

        [DisplayName("Datum fakture")]
        [SqlName("DatumFakture")]
        public DateTime DatumFakture { get; set; }

        #endregion

        #region Parameters
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@FakturaID", System.Data.SqlDbType.Int);
                parameter.Value = FakturaID;
                lista.Add(parameter);
            }
            return lista;
        }
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@RadnikID", System.Data.SqlDbType.Int);
                parameter.Value = RadnikID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@KlijentID", System.Data.SqlDbType.Int);
                parameter.Value = KlijentID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@TipFaktureID", System.Data.SqlDbType.Int);
                parameter.Value = TipFaktureID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Napomena", System.Data.SqlDbType.Text);
                parameter.Value = Napomena;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DatumFakture", System.Data.SqlDbType.DateTime);
                parameter.Value = DatumFakture;
                lista.Add(parameter);
            }
            return lista;
        }
        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@FakturaID", System.Data.SqlDbType.Int);
                parameter.Value = FakturaID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@RadnikID", System.Data.SqlDbType.Int);
                parameter.Value = RadnikID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@KlijentID", System.Data.SqlDbType.Int);
                parameter.Value = KlijentID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@TipFaktureID", System.Data.SqlDbType.Int);
                parameter.Value = TipFaktureID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Napomena", System.Data.SqlDbType.Text);
                parameter.Value = Napomena;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DatumFakture", System.Data.SqlDbType.DateTime);
                parameter.Value = DatumFakture;
                lista.Add(parameter);
            }
            return lista;
        }
        #endregion

        #region Queries
        public string GetDeleteQuery()
        {
            return @"DELETE FROM [dbo].[Faktura] WHERE [FakturaID]=@FakturaID";
        }
        public string GetInsertQuery()
        {
            return @"INSERT INTO[dbo].[Faktura] (RadnikID, KlijentID, TipFaktureID, Napomena, 
                    DatumFakture) VALUES (@RadnikID, @KlijentID, @TipFaktureID, @Napomena, @DatumFakture)";
        }
        public string GetSelectQuery()
        {
            return @"SELECT 
                        FakturaID,
                        RadnikID,
                        KlijentID,
                        TipFaktureID,
                        Napomena,
                        DatumFakture
                     FROM dbo.Faktura";
        }
        public string GetUpdateQuery()
        {
            return @" UPDATE[dbo].[Faktura] SET [RadnikID] = @RadnikID, [KlijentID] = @KlijentID
                    ,[TipFaktureID] = @TipFaktureID, [DatumFakture] = @DatumFakture
                    WHERE[FakturaID] = @FakturaID";
        }

        public string GetLookupQuery(string ID)
        {
            return @"SELECT
                        RadnikID,
                        KlijentID,
                        TipFaktureID
                     FROM dbo.Faktura
                    WHERE FakturaID = " + ID;
        }

        public string GetSelectQueryZaJedanItem(string broj)
        {
            return @"SELECT
                        FakturaID,
                        RadnikID,
                        KlijentID,
                        TipFaktureID,
                        Napomena,
                        DatumFakture
                     FROM dbo.Faktura
                    WHERE FakturaID = " + broj;
        }
        #endregion
    }
}
