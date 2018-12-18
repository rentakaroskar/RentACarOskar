using KonekcijaNaBazu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using RentACarOskar.PropertyClass;

namespace RentACarOskar.CRUD
{
    public class IstorijaCRUD
    {
        
        StateEnum state;
        PropertyInterface PropertyIstorijaCRUD;

        public static void Istorija(string UserMail, StateEnum state, PropertyInterface myInterface)
        {
            //string akcija = "";
            //akcija : create,update ili delete
            DateTime datum = DateTime.Now;
            PropertyIstorijaCRUD PropertyIstorija = new PropertyIstorijaCRUD();

            var type = PropertyIstorija.GetType();
            var properties = type.GetProperties();

            string Opis = $"Korisnik: {UserMail} Akcija: {state} Datum: {datum} , {myInterface.ToString()} ";

            PropertyIstorija.KorisnickiMail = UserMail;
            PropertyIstorija.Datum = datum;
            PropertyIstorija.Opis = Opis;

            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                                 PropertyIstorija.GetInsertQuery(), PropertyIstorija.GetInsertParameters().ToArray());
         

        }
    }
}
