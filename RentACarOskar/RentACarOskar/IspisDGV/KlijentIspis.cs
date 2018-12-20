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
    class KlijentIspis: PropertyInterface
    {
        #region Attributes
        [DisplayName("KlijentID")]
        [SqlName("KlijentID")]
        [PrimaryKey]
        public int KlijentID { get; set; }

        [DisplayName("Ime")]
        [SqlName("Ime")]
        public string Ime { get; set; }

        [DisplayName("Prezime")]
        [SqlName("Prezime")]
        public string Prezime { get; set; }

        [DisplayName("Tip")]
        [SqlName("Tip")]
        public string Tip { get; set; }

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
            return @"SELECT[KlijentID]
                                  ,[Ime]
                                  ,[Prezime]
                                  ,[Tip]
                    FROM[RentACarTim5].[dbo].[vIspisKlijenata]";
        }
        public string GetUpdateQuery()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
