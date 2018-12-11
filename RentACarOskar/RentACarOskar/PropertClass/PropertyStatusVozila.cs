﻿using RentACarOskar.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarOskar.PropertClass
{
    class PropertyStatusVozila:PropertInterface
    {
        #region Atributi


        [DisplayName("StatusID")]
        [SqlName("StatusID")]
        [PrimaryKey]
        public int StatusID { get; set; }

        [DisplayName("DostupnostId")]
        [SqlName("DostupnostID")]
        public int DostupnostID { get; set; }

        [DisplayName("VoziloId")]
        [SqlName("VoziloID")]
        public int VoziloID { get; set; }

        [DisplayName("DatumStatusa")]
        [SqlName("DatumStatusa")]
        public DateTime DatumStatusa { get; set; }
        #endregion
        #region Parameters
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@StatusID", System.Data.SqlDbType.Int);
                parameter.Value = StatusID;
                lista.Add(parameter);
            }
           
            return lista;
        }
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@DostupnostID", System.Data.SqlDbType.Int);
                parameter.Value = DostupnostID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                parameter.Value = VoziloID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DatumStatusa", System.Data.SqlDbType.Date);
                parameter.Value = DatumStatusa;
                lista.Add(parameter);
            }
            return lista;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@StatusID", System.Data.SqlDbType.Int);
                parameter.Value = StatusID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DostupnostID", System.Data.SqlDbType.Int);
                parameter.Value = DostupnostID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                parameter.Value = VoziloID;
                lista.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DatumStatusa", System.Data.SqlDbType.Date);
                parameter.Value = DatumStatusa;
                lista.Add(parameter);
            }
            return lista;
        }
        #endregion

        #region Queries
        public string GetSelectQuery()
        {
            return @"SELECT [StatusID], [DostupnostID], [VoziloID], [DatumStatusa]
            FROM [dbo].[StatusVozila]";
        }
        public string GetDeleteQuery()
        {
            return @"DELETE FROM [dbo].[StatusVozila]
                    WHERE [StatusID] = @StatusID";
        }
        public string GetInsertQuery()
        {
            return @"INSERT INTO[dbo].[StatusVozila]
                     ([DostupnosID], [VoziloID], [DatumStatusa])
                     VALUES
                    (@DostupnostID, @VoziloID, @DatumStatusa)";

        }
    public string GetUpdateQuery()
        {
            return @"UPDATE [dbo].[StatusVozila]
                    SET [DostupnostID] = @DostupnostID, [VoziloID]=@VoziloID, [DatumStatusa]=@DatumStatusa
                     WHERE [StatusID] = @StatusID";
        }

        #endregion

    }
}