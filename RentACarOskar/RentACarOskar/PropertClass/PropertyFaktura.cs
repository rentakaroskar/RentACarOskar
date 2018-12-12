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
    class PropertyFakturaL : PropertInterface
    {
        #region Attributes

        [DisplayName("FakturaID")]
        [SqlName("FakturaID")]
        [PrimaryKey]
        public int FakturaID { get; set; }

        [DisplayName("RadnikID")]
        [SqlName("RadnikID")]
        public int RadnikID { get; set; }

        [DisplayName("KlijentID")]
        [SqlName("KlijentID")]
        public int KlijentID { get; set; }

        [DisplayName("TipFaktureID")]
        [SqlName("TipFaktureID")]
        public int TipFaktureID { get; set; }

        [DisplayName("Napomena")]
        [SqlName("Napomena")]
        public string Napomena { get; set; }

        [DisplayName("DatumFakture")]
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
                SqlParameter parameter = new SqlParameter("@DatumFakture", System.Data.SqlDbType.Date);
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
                SqlParameter parameter = new SqlParameter("@DatumFakture", System.Data.SqlDbType.Date);
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
            return @"INSERT INTO[dbo].[Faktura]([FakturaID), (RadnikID), (KlijentID), (TipFaktureID), (Napomena), 
                    (DatumFakture)] VALUES (@FakturaID, @RadnikID, @KlijentID, @TipFaktureID, @Napomena, @DatumFakture)";
        }
        public string GetSelectQuery()
        {
            return @"SELECT [FakturaID], [RadnikID], [KlijentID], [TipFaktureID], [Napomena], [DatumFakture]
                     FROM [dbo].[Faktura]";
        }
        public string GetUpdateQuery()
        {
            return @" UPDATE[dbo].[Faktura] SET [RadnikID] = @RadnikID, [KlijentID] = @KlijentID
                    ,[TipFaktureID] = @TipFaktureID, [DatumFakture] = @DatumFakture
                    WHERE[FakturaID] = @FakturaID";
        }
        #endregion
    }
}
