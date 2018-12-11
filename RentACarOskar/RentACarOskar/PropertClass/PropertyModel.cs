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
    class PropertyModel: PropertInterface
    {
        #region Atributi
        public int ModelId;
        public string Naziv;
        public int ProizvodjacID;
        [DisplayName("ModelId")]
        [SqlName("ModelID")]
        [PrimaryKey]
        public int modelId
        {
            get
            {
                return ModelId;
            }
            set
            {
                ModelId = value;
            }
        }
        [DisplayName("Naziv")]
        [SqlName("Naziv")]
        public string naziv
        {
            get
            {
                return Naziv;
            }
            set
            {
                Naziv = value;
            }
        }
        [DisplayName("ProizvodjacID")]
        [SqlName("ProizvodjacID")]
        //[ForeignKey]
        public int proizvodjacId
        {
            get
            {
                return ProizvodjacID;
            }
            set
            {
                ProizvodjacID = value;
            }
        }
        #endregion
        #region Parameters
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@Naziv", System.Data.SqlDbType.NVarChar);
                parameter.Value = naziv;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@ProizvodjacID", System.Data.SqlDbType.Int);
                parameter.Value = proizvodjacId;
                lista.Add(parameter);
            }
            return lista;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();     
            {
                SqlParameter parameter = new SqlParameter("@Naziv", System.Data.SqlDbType.NVarChar);
                parameter.Value = naziv;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@ProizvodjacID", System.Data.SqlDbType.Int);
                parameter.Value = proizvodjacId;
                lista.Add(parameter);
            }
            return lista;
        }
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@Naziv", System.Data.SqlDbType.NVarChar);
                parameter.Value = naziv;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@ProizvodjacID", System.Data.SqlDbType.Int);
                parameter.Value = proizvodjacId;
                lista.Add(parameter);
            }
            return lista;
        }
        #endregion
        #region Queries
        public string GetSelectQuery()
        {
            throw new NotImplementedException();
        }

        public string GetInsertQuery()
        {
            throw new NotImplementedException();
        }

        public string GetUpdateQuery()
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

        public List<SqlParameter> GetUpdateParameters()
        {
            throw new NotImplementedException();
        }

        public List<SqlParameter> GetDeleteParameters()
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
