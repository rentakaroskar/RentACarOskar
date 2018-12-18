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
    class PropertyOsoba : PropertyInterface
    {
        #region Atributi
        [DisplayName("Osoba ID")]
        [SqlName("OsobaID")]
        [PrimaryKey]
        public int OsobaID { get; set; }

        [DisplayName("Ime")]
        [SqlName("Ime")]
        public string Ime { get; set; }

        [DisplayName("Prezime")]
        [SqlName("Prezime")]
        public string Prezime { get; set; }

        [DisplayName("Jmb")]
        [SqlName("JMB")]
        public string JMB { get; set; }

        [DisplayName("Datum rodjenja")]
        [SqlName("DatumRodjenja")]
        public DateTime DatumRodjenja { get; set; }

        [DisplayName("Pol")]
        [SqlName("Pol")]
        [NotRequired]
        [TwoRadioButtons("M", "F")]
        public char Pol { get; set; }

        [DisplayName("Broj telefona")]
        [SqlName("BrojTelefon")]
        [NotRequired]
        public string BrojTelefona { get; set; }

        [DisplayName("Adresa")]
        [SqlName("Adresa")]
        [NotRequired]
        public string Adresa { get; set; }
        #endregion

        #region Parameters
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@Ime", System.Data.SqlDbType.NVarChar);
                parameter.Value = Ime;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Prezime", System.Data.SqlDbType.NVarChar);
                parameter.Value = Prezime;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@JMB", System.Data.SqlDbType.NVarChar);
                parameter.Value = JMB;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DatumRodjenja", System.Data.SqlDbType.Date);
                parameter.Value = DatumRodjenja;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Pol", System.Data.SqlDbType.NChar);
                parameter.Value = Pol;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@BrojTelefon", System.Data.SqlDbType.NVarChar);
                parameter.Value = BrojTelefona;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Adresa", System.Data.SqlDbType.NVarChar);
                parameter.Value = Adresa;
                lista.Add(parameter);
            }
            return lista;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@OsobaID", System.Data.SqlDbType.Int);
                parameter.Value = OsobaID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Ime", System.Data.SqlDbType.NVarChar);
                parameter.Value = Ime;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Prezime", System.Data.SqlDbType.NVarChar);
                parameter.Value = Prezime;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@JMB", System.Data.SqlDbType.NVarChar);
                parameter.Value = JMB;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DatumRodjenja", System.Data.SqlDbType.Date);
                parameter.Value = DatumRodjenja;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Pol", System.Data.SqlDbType.NChar);
                parameter.Value = Pol;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@BrojTelefon", System.Data.SqlDbType.NVarChar);
                parameter.Value = BrojTelefona;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Adresa", System.Data.SqlDbType.NVarChar);
                parameter.Value = Adresa;
                lista.Add(parameter);
            }
            return lista;
        }

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@OsobaID", System.Data.SqlDbType.Int);
                parameter.Value = OsobaID;
                lista.Add(parameter);
            }
            return lista;
        }
        #endregion

        #region Queries
        public string GetDeleteQuery()
        {
            return @"DELETE FROM [dbo].[Osoba] WHERE [OsobaID] = @OsobaID";
        }
        
        public string GetInsertQuery()
        {
            return @"INSERT INTO[dbo].[Osoba] ([Ime], [Prezime], [JMB], [DatumRodjenja]
                      ,[Pol] ,[BrojTelefon] ,[Adresa])                  
                 VALUES(@Ime ,@Prezime  ,@JMB  ,@DatumRodjenja ,@Pol  ,@BrojTelefon ,@Adresa)";
        }

        public string GetSelectQuery()
        {
            return @"SELECT [OsobaID] ,[Ime] ,[Prezime],[JMB], [DatumRodjenja], [Pol], [BrojTelefon]
             ,[Adresa]  FROM [dbo].[Osoba]";
        }

        public string GetUpdateQuery()
        {
            return @" UPDATE[dbo].[Osoba] SET [Ime] = @Ime, [Prezime] = @Prezime
                 ,[JMB] = @JMB, [DatumRodjenja] = @DatumRodjenja, [Pol] = @Pol, [BrojTelefon] = @BrojTelefon
                 ,[Adresa] = @Adresa WHERE [OsobaID] = @OsobaID";
        }
    #endregion
    }
}
