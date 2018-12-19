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
    class FakturaIspis : PropertyInterface
    {
        #region Attributes
        [DisplayName("Faktura ID")]
        [SqlName("BrojFakture")]
        [PrimaryKey]
        public int FakturaID { get; set; }

        [DisplayName("Datum fakture")]
        [SqlName("DatumFakture")]
        public DateTime DatumFakture { get; set; }

        [DisplayName("Klijent")]
        [SqlName("Klijent")]
        public string Klijent { get; set; }

        [DisplayName("Iznos")]
        [SqlName("Iznos")]
        public decimal Iznos { get; set; }

        [DisplayName("Tipa fakture")]
        [SqlName("TipFakture")]
        public string TipFakture { get; set; }

        #endregion


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
            return @"EXEC dbo.IspisFakturaProc";
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            throw new NotImplementedException();
        }

        public string GetUpdateQuery()
        {
            throw new NotImplementedException();
        }
    }
}
