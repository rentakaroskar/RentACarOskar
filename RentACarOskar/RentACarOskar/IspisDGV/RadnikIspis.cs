using RentACarOskar.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarOskar.IspisDGV
{

    class RadnikIspis : PropertyInterface
    {
        #region Attributes

        //  r.RadnikID
        // ,o.[Ime]
        //,o.[Prezime]
        //,o.[JMB]
        //,o.[DatumRodjenja]
        //,o.[BrojTelefon]
        //,o.[Adresa]
        //,r.[Pozicija]
        //,r.[Plata]

        [DisplayName("Radnik ID")]
        [SqlName("RadnikID")]
        [PrimaryKey]
        public int RadnikID { get; set; }

        [DisplayName("Ime")]
        [SqlName("Ime")]
        public string Ime { get; set; }
       
        [DisplayName("Prezime")]
        [SqlName("Prezime")]
        public string Prezime { get; set; }

        [DisplayName("JMB")]
        [SqlName("JMB")]
        public int JMB { get; set; }

        [DisplayName("Datum Rodjenja")]
        [SqlName("DatumRodjenja")]
        public DateTime DatumRodjenja { get; set; }

        [DisplayName("Adresa")]
        [SqlName("Adresa")]
        public string Adresa { get; set; }

        [DisplayName("Broj Telefona")]
        [SqlName("BrojTelefon")]
        public string BrojTelefon { get; set; }

        [DisplayName("Pozicija")]
        [SqlName("Pozicija")]
        public string Pozicija { get; set; }

        [DisplayName("Plata")]
        [SqlName("Plata")]
        public decimal Plata { get; set; }







        #endregion

        #region Parameters
        public List<SqlParameter> GetDeleteParameters()
        {
            throw new NotImplementedException();
        }
        public List<SqlParameter> GetInsertParameters()
        {
            throw new NotImplementedException();
        }
        public List<SqlParameter> GetUpdateParameters()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Queries
        public string GetDeleteQuery()
        {
            throw new NotImplementedException();
        }
        public string GetInsertQuery()
        {
            throw new NotImplementedException();
        }
        public string GetLookupQuery()
        {
            throw new NotImplementedException();
        }
        public string GetLookupQuery(string ID)
        {
            throw new NotImplementedException();
        }
        public string GetSelectQuery()
        {
            return @"SELECT
                                RadnikID
                                ,[Ime]
                                ,[Prezime]
                                ,[JMB]
                                ,[DatumRodjenja]
                                ,[BrojTelefon]
                                ,[Adresa]
                                ,[Pozicija]
                                ,[Plata]
                           
                    FROM[RentACarTim5].[dbo].[vIspisRadnika]";
        }
        public string GetUpdateQuery()
        {
            throw new NotImplementedException();
        }

        public string GetSelectQueryZaJedanItem(string broj)
        {
            throw new NotImplementedException();
        }

        List<SqlParameter> PropertyInterface.GetInsertParameters()
        {
            throw new NotImplementedException();
        }

        List<SqlParameter> PropertyInterface.GetUpdateParameters()
        {
            throw new NotImplementedException();
        }

        List<SqlParameter> PropertyInterface.GetDeleteParameters()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}


