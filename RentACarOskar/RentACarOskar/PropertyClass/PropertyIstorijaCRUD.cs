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
    public class PropertyIstorijaCRUD : PropertyInterface
    {
        #region Attributes

        [DisplayName("ID ackije")]
        [SqlName("IDcrud")]
        [PrimaryKey]
        public int IDcrud { get; set; }

        [DisplayName("Mail")]
        [SqlName("KorisnickiMail")]
        public string KorisnickiMail { get; set; }

        [DisplayName("Datum")]
        [SqlName("Datum")]
        public DateTime Datum { get; set; }


        [DisplayName("Opis")]
        [SqlName("Opis")]
        public string Opis { get; set; }
        #endregion

        #region Parameters



       

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@IDcrud", System.Data.SqlDbType.Int);
                parameter.Value = IDcrud;
                lista.Add(parameter);
            }
            return lista;
        }

       

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
          
            {
                SqlParameter parameter = new SqlParameter("@KorisnickiMail", System.Data.SqlDbType.NVarChar);
                parameter.Value = KorisnickiMail;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Datum", System.Data.SqlDbType.Date);
                parameter.Value = Datum;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Opis", System.Data.SqlDbType.NVarChar);
                parameter.Value = Opis;
                lista.Add(parameter);
            }

            return lista;
        }
        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();

            {
                SqlParameter parameter = new SqlParameter("@KorisnickiMail", System.Data.SqlDbType.NVarChar);
                parameter.Value = KorisnickiMail;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Datum", System.Data.SqlDbType.Date);
                parameter.Value = Datum;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Opis", System.Data.SqlDbType.NVarChar);
                parameter.Value = Opis;
                lista.Add(parameter);
            }
            return lista;
        }
        #endregion

        #region Queries
        public string GetDeleteQuery()
        {
            return @"DELETE FROM [dbo].[IstorijaCRUD] WHERE [IDcrud]=@IDcrud";
        }
        public string GetInsertQuery()
        {
            return @"INSERT INTO[dbo].[IstorijaCRUD] (KorisnickiMail, Datum, Opis)
                    VALUES (@KorisnickiMail, @Datum, @Opis)";
        }
        public string GetSelectQuery()
        {
            return @"SELECT [IDcrud]
                           ,[KorisnickiMail]
                           ,[Datum]
                           ,[Opis]
                    FROM [dbo].[IstorijaCRUD]";
        }
        public string GetUpdateQuery()
        {
            return @" UPDATE[dbo].[IstorijaCRUD] SET [KorisnickiMail] = @KorisnickiMail, [Datum] = @Datum
                    ,[Opis] = @Opis ";
        }

        public string GetLookupQuery(string ID)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
