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
    public class PropertyRadnik : PropertyInterface
    {
        #region Properties
        [DisplayName("Radnik ID")]
        [SqlName("RadnikID")]
        [PrimaryKey]
        public int RadnikID { get; set; }

        [DisplayName("Osoba ID")]
        [SqlName("OsobaID")]
        public int OsobaID { get; set; }

        [DisplayName("Pozicija")]
        [SqlName("Pozicija")]
        public string Pozicija { get; set; }

        [DisplayName("Plata")]
        [SqlName("Plata")]
        public decimal Plata { get; set; }

        [DisplayName("Mjesto rodjenja")]
        [SqlName("MjestoRodjenja")]
        public string MjestoRodjenja { get; set; }

        [DisplayName("Bracni status")]
        [SqlName("BracniStatus")]
        public char BracniStatus { get; set; }

        [DisplayName("Datum zaposlenja")]
        [SqlName("DatumZaposlenja")]
        public DateTime DatumZaposlenja { get; set; }

        #endregion

        #region Parameters
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> parametri = new List<SqlParameter>();
            {
                SqlParameter novi = new SqlParameter("@RadnikID", System.Data.SqlDbType.Int);
                novi.Value = RadnikID ;
                parametri.Add(novi);

            }
            return parametri;
        }

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> parametri = new List<SqlParameter>();
            {
                SqlParameter novi = new SqlParameter("@OsobaID", System.Data.SqlDbType.Int);
                novi.Value = OsobaID;
                parametri.Add(novi);
            }
            {
                SqlParameter novi = new SqlParameter("@Pozicija", System.Data.SqlDbType.NVarChar);
                novi.Value = Pozicija;
                parametri.Add(novi);
            }
            {
                SqlParameter novi = new SqlParameter("@Plata", System.Data.SqlDbType.Decimal);
                novi.Value = Plata;
                parametri.Add(novi);
            }
            {
                SqlParameter novi = new SqlParameter("@MjestoRodjenja", System.Data.SqlDbType.NVarChar);
                novi.Value = MjestoRodjenja;
                parametri.Add(novi);
            }
            {
                SqlParameter novi = new SqlParameter("@BracniStatus", System.Data.SqlDbType.Char);
                novi.Value = BracniStatus;
                parametri.Add(novi);
            }
            {
                SqlParameter novi = new SqlParameter("@DatumZaposlenja", System.Data.SqlDbType.Date);
                novi.Value = DatumZaposlenja;
                parametri.Add(novi);
            }
            return parametri;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> parametri = new List<SqlParameter>();
            {
                SqlParameter novi = new SqlParameter("@RadnikID", System.Data.SqlDbType.Int);
                novi.Value = RadnikID;
                parametri.Add(novi);
            }
            {
                SqlParameter novi = new SqlParameter("@OsobaID", System.Data.SqlDbType.Int);
                novi.Value = OsobaID;
                parametri.Add(novi);
            }
            {
                SqlParameter novi = new SqlParameter("@Pozicija", System.Data.SqlDbType.NVarChar);
                novi.Value = Pozicija;
                parametri.Add(novi);
            }
            {
                SqlParameter novi = new SqlParameter("@Plata", System.Data.SqlDbType.Decimal);
                novi.Value = Plata;
                parametri.Add(novi);
            }
            {
                SqlParameter novi = new SqlParameter("@MjestoRodjenja", System.Data.SqlDbType.NVarChar);
                novi.Value = MjestoRodjenja;
                parametri.Add(novi);
            }
            {
                SqlParameter novi = new SqlParameter("@BracniStatus", System.Data.SqlDbType.Char);
                novi.Value = BracniStatus;
                parametri.Add(novi);
            }
            {
                SqlParameter novi = new SqlParameter("@DatumZaposlenja", System.Data.SqlDbType.Date);
                novi.Value = DatumZaposlenja;
                parametri.Add(novi);
            }
            return parametri;
        }
        #endregion

        #region Queries
        public string GetDeleteQuery()
        {
            return @"DELETE FROM[dbo].[Radnik]
              WHERE[RadnikID] = @RadnikID";
        }

        public string GetInsertQuery()
        {
          return
            @"INSERT INTO [dbo].[Radnik]
                ([OsobaID]
                ,[Pozicija]
                ,[Plata]
                ,[MjestoRodjenja]
                ,[BracniStatus]
                ,[DatumZaposlenja])
           VALUES
               (@OsobaID
               ,@Pozicija
               ,@Plata
               ,@MjestoRodjenja
               ,@BracniStatus
               ,@DatumZaposlenja)";
        }

        public string GetSelectQuery()
        {
            return 
                @"SELECT 
                    [RadnikID]
                   ,[OsobaID]
                   ,[Pozicija]
                   ,[Plata]
                   ,[MjestoRodjenja]
                   ,[BracniStatus]
                   ,[DatumZaposlenja]
               FROM [dbo].[Radnik]";
        }       

        public string GetUpdateQuery()
        {
            return @"UPDATE [dbo].[Radnik]
                   SET [OsobaID] = @OsobaID
                      ,[Pozicija] = @Pozicija
                      ,[Plata] = @Plata
                      ,[MjestoRodjenja] = @MjestoRodjenja
                      ,[BracniStatus] = @BracniStatus
                      ,[DatumZaposlenja] = @DatumZaposlenja
                  WHERE [RadnikID] = @RadnikID";
        }
        #endregion
    }
}