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
    public class PropertyVozilo : PropertyInterface
    {
        #region Attributes

        [SqlName("VoziloID")]
        [DisplayName("Vozilo ID")]
        [PrimaryKey]
        public int VoziloID { get; set; }

        [SqlName("ModelID")]
        [DisplayName("Model ID")]
        [ForeignKey("Model", "ModelID", "RentACarOscar.PropertyClass.PropertyModel")]
        public int ModelID { get; set; }

        [SqlName("GodinaProizvodnje")]
        [DisplayName("Godina proizvodnje")]
        public DateTime GodinaProizvodnje { get; set; }

        [SqlName("BrojRegistracije")]
        [DisplayName("Broj registracije")]
        public string BrojRegistracije { get; set; }

        [SqlName("VrstaGoriva")]
        [DisplayName("Vrsta goriva")]
        public string VrstaGoriva { get; set; }

        [SqlName("Boja")]
        [DisplayName("Boja")]
        public string Boja { get; set; }

        [SqlName("BrojVrata")]
        [DisplayName("Broj vrata")]
        public int BrojVrata { get; set; }

        [SqlName("ZadnjiServis")]
        [DisplayName("Zadnji servis")]
        public DateTime ZadnjiServis { get; set; }

        [SqlName("Kilometraza")]
        [DisplayName("Kilometraza")]
        public decimal Kilometraza { get; set; }
        #endregion

        #region Parameters
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                parameter.Value = VoziloID;
                parameters.Add(parameter);
            }
            return parameters;
        }

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ModelID", System.Data.SqlDbType.Int);
                parameter.Value = ModelID;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@GodinaProizvodnje", System.Data.SqlDbType.Date);
                parameter.Value = GodinaProizvodnje;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@BrojRegistracije", System.Data.SqlDbType.NVarChar);
                parameter.Value = BrojRegistracije;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@VrstaGoriva", System.Data.SqlDbType.NVarChar);
                parameter.Value = VrstaGoriva;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Boja", System.Data.SqlDbType.NVarChar);
                parameter.Value = Boja;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@BrojVrata", System.Data.SqlDbType.Int);
                parameter.Value = BrojVrata;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@ZadnjiServis", System.Data.SqlDbType.Date);
                parameter.Value = ZadnjiServis;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Kilometraza", System.Data.SqlDbType.Decimal);
                parameter.Value = Kilometraza;
                parameters.Add(parameter);
            }

            return parameters;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                parameter.Value = VoziloID;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@ModelID", System.Data.SqlDbType.Int);
                parameter.Value = ModelID;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@GodinaProizvodnje", System.Data.SqlDbType.Date);
                parameter.Value = GodinaProizvodnje;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@BrojRegistracije", System.Data.SqlDbType.NVarChar);
                parameter.Value = BrojRegistracije;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@VrstaGoriva", System.Data.SqlDbType.NVarChar);
                parameter.Value = VrstaGoriva;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Boja", System.Data.SqlDbType.NVarChar);
                parameter.Value = Boja;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@BrojVrata", System.Data.SqlDbType.Int);
                parameter.Value = BrojVrata;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@ZadnjiServis", System.Data.SqlDbType.Date);
                parameter.Value = ZadnjiServis;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Kilometraza", System.Data.SqlDbType.Decimal);
                parameter.Value = Kilometraza;
                parameters.Add(parameter);
            }

            return parameters;
        }
        #endregion

        #region Queries
        public string GetDeleteQuery()
        {
            return @"DELETE FROM [dbo].[Vozilo]
                    WHERE [VoziloID] = @VoziloID";
        }
        
        public string GetInsertQuery()
        {
            return
           @"INSERT INTO [dbo].[Vozilo]
           (
           [ModelID]
           ,[GodinaProizvodnje]
           ,[BrojRegistracije]
           ,[VrstaGoriva]
           ,[Boja]
           ,[BrojVrata]
           ,[ZadnjiServis]
           ,[Kilometraza])
           VALUES
           (
           @ModelID
           ,@GodinaProizvodnje
           ,@BrojRegistracije
           ,@VrstaGoriva
           ,@Boja
           ,@BrojVrata
           ,@ZadnjiServis
           ,@Kilometraza)";
        }

        public string GetSelectQuery()
        {
            return @"SELECT 
                 [VoziloID]
                ,[ModelID]
                ,[GodinaProizvodnje]
                ,[BrojRegistracije]
                ,[VrstaGoriva]
                ,[Boja]
                ,[BrojVrata]
                ,[ZadnjiServis]
                ,[Kilometraza]
                FROM [dbo].[Vozilo]";
        }
        
        public string GetUpdateQuery()
        {
            return
                 @"UPDATE [dbo].[Vozilo]
                   SET [ModelID] = @ModelID
                    ,[GodinaProizvodnje] = @GodinaProizvodnje
                    ,[BrojRegistracije] = @BrojRegistracije
                    ,[VrstaGoriva] = @VrstaGoriva
                    ,[Boja] = @Boja
                    ,[BrojVrata] = @BrojVrata
                    ,[ZadnjiServis] = @ZadnjiServis
                    ,[Kilometraza] = @Kilometraza
                    WHERE [VoziloID] = @VoziloID";
        }
        #endregion
    }
}
