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
    class VoziloIspis : PropertyInterface
    {

        [SqlName("VoziloID")]
        [DisplayName("Vozilo ID")]
        [PrimaryKey]
        public int VoziloID { get; set; }

        [DisplayName("Proizvodjac")]
        [SqlName("Proizvodjac")]
        public string Proizvodjac { get; set; }

        [DisplayName("Model")]
        [SqlName("Model")]
        public string Model { get; set; }

        [DisplayName("Registracija")]
        [SqlName("BrojRegistracije")]
        public string Registracija { get; set; }

        [DisplayName("Boja")]
        [SqlName("Boja")]
        public string Boja { get; set; }

        [DisplayName("Dostupnost")]
        [SqlName("Dostupnost")]
        public string Dostupnost { get; set; }

        [DisplayName("Datum Rezervacije")]
        [SqlName("DatumRezervacije")]
        public DateTime DatumRezervacije { get; set; }

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
            return @"EXEC dbo.spIspisVozila";
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
