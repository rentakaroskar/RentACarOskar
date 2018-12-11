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
    class PropertyOsoba : PropertInterface
    {
        #region Atributi
        public int OsobaId;
        public string Ime;
        public string Prezime;
        public int Jmb;
        public DateTime DatumRodjenja;
        public char Pol;
        public string BrojTelefona;
        public string Adresa;
       
        [DisplayName("OsobaId")]
        [SqlName("OsobaID")]
        [PrimaryKey]
        public int osobaId
        {
            get
            {
                return OsobaId;
            }
            set
            {
                OsobaId = value;
            }
        }
        [DisplayName("Ime")]
        [SqlName("Ime")]
        public string ime
        {
            get
            {
                return Ime;
            }
            set
            {
                Ime = value;
            }
        }
        [DisplayName("Prezime")]
        [SqlName("Prezime")]
        public string prezime
        {
            get
            {
                return Prezime;
            }
            set
            {
                Prezime = value;
            }
        }
        [DisplayName("Jmb")]
        [SqlName("JMB")]
        public int jmb
        {
            get
            {
                return Jmb;
            }
            set
            {
                Jmb = value;
            }
        }
        [DisplayName("DatumRodjenja")]
        [SqlName("DatumRodjenja")]
        public DateTime datumRodjenja
        {
            get
            {
                return DatumRodjenja;
            }
            set
            {
                DatumRodjenja = value;
            }
        }
        [DisplayName("Pol")]
        [SqlName("Pol")]
        public char pol
        {
            get
            {
                return Pol;
            }
            set
            {
                Pol = value;
            }
        }
        [DisplayName("BrojTelefona")]
        [SqlName("BrojTelefona")]
        public string brojTelefona
        {
            get
            {
                return BrojTelefona;
            }
            set
            {
                BrojTelefona = value;
            }
        }
        [DisplayName("Adresa")]
        [SqlName("Adresa")]
        public string adresa
        {
            get
            {
                return Adresa;
            }
            set
            {
                Adresa = value;
            }
        }
        #endregion
        #region Parameters
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@Ime", System.Data.SqlDbType.NVarChar);
                parameter.Value = ime;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Prezime", System.Data.SqlDbType.NVarChar);
                parameter.Value = prezime;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@JMB", System.Data.SqlDbType.Int);
                parameter.Value = jmb;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DatumRodjenja", System.Data.SqlDbType.Date);
                parameter.Value = datumRodjenja;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Pol", System.Data.SqlDbType.NChar);
                parameter.Value = pol;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@BrojTelefona", System.Data.SqlDbType.NVarChar);
                parameter.Value = brojTelefona;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Adresa", System.Data.SqlDbType.NVarChar);
                parameter.Value = adresa;
                lista.Add(parameter);
            }
            return lista;
        }
        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@Ime", System.Data.SqlDbType.NVarChar);
                parameter.Value = ime;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Prezime", System.Data.SqlDbType.NVarChar);
                parameter.Value = prezime;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@JMB", System.Data.SqlDbType.Int);
                parameter.Value = jmb;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DatumRodjenja", System.Data.SqlDbType.Date);
                parameter.Value = datumRodjenja;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Pol", System.Data.SqlDbType.NChar);
                parameter.Value = pol;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@BrojTelefona", System.Data.SqlDbType.NVarChar);
                parameter.Value = brojTelefona;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Adresa", System.Data.SqlDbType.NVarChar);
                parameter.Value = adresa;
                lista.Add(parameter);
            }
            return lista;
        }
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@Ime", System.Data.SqlDbType.NVarChar);
                parameter.Value = ime;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Prezime", System.Data.SqlDbType.NVarChar);
                parameter.Value = prezime;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@JMB", System.Data.SqlDbType.Int);
                parameter.Value = jmb;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DatumRodjenja", System.Data.SqlDbType.Date);
                parameter.Value = datumRodjenja;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Pol", System.Data.SqlDbType.NChar);
                parameter.Value = pol;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@BrojTelefona", System.Data.SqlDbType.NVarChar);
                parameter.Value = brojTelefona;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Adresa", System.Data.SqlDbType.NVarChar);
                parameter.Value = adresa;
                lista.Add(parameter);
            }
            return lista;
        }
        #endregion
        #region Queries
        public List<SqlParameter> GetDeleteParameters()
        {
            throw new NotImplementedException();
        }

        public string GetDeleteQuery()
        {
            throw new NotImplementedException();
        }

        public List<SqlParameter> GetInsertParameters()
        {
            throw new NotImplementedException();
        }

        public string GetInsertQuery()
        {
            throw new NotImplementedException();
        }

        public string GetSelectQuery()
        {
            throw new NotImplementedException();
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            throw new NotImplementedException();
        }

        public string GetUpdateQuery()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
