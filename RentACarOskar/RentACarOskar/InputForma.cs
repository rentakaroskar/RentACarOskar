using KonekcijaNaBazu;
using RentACarOskar.Attributes;
using RentACarOskar.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACarOskar
{
    public partial class InputForma : MetroFramework.Forms.MetroForm
    {

        PropertyInterface myInterface;
        StateEnum state;
        string userEmail;

        public InputForma(PropertyInterface myInterface, StateEnum state,string email)
        {
            InitializeComponent();
            userEmail = email;
            Text = myInterface.ToString().Remove(0, 36) + " " + state.ToString();
            this.myInterface = myInterface;
            this.state = state;
            PopulateControls();
        }

        //Funkcija za popunjavanje kontrole u Input formi
        private void PopulateControls()
        {
            bool i = true;
            foreach (PropertyInfo item in myInterface.GetType().GetProperties())
            {
                //Izbacivanje prikaza primarnog kljuca
                if (i == false)
                {
                    //Dodavanje kontrole za datum
                    if (item.PropertyType.Name == "DateTime")
                    {
                        InputDateControl uc = new InputDateControl();
                        uc.Name = item.Name;
                        uc.SetLabel(item.GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault().DisplayName);

                        if (state == StateEnum.Update)
                        {
                            try
                            {
                                uc.SetValueInDateBox(item.GetValue(myInterface).ToString());
                            }
                            catch { }
                        }

                        flowPanel.Controls.Add(uc);
                    }

                    //Dodavanje kontrole za Lookup
                    else if (item.GetCustomAttributes<Attributes.ForeignKeyAttribute>() != null && item.Name.Contains("ID"))
                    {
                        PropertyInterface foreignKeyInterface = Assembly.GetExecutingAssembly().
                         CreateInstance(item.GetCustomAttribute<ForeignKeyAttribute>().ClassName)
                         as PropertyInterface;


                        LookUpControl uc = new LookUpControl(foreignKeyInterface);
                        uc.Name = item.Name;
                        uc.SetLabel(item.GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault().DisplayName);

                        if (state == StateEnum.Update)
                        {
                            try
                            {
                                uc.SetValueTextBox(item.GetValue(myInterface).ToString());
                            }
                            catch { }
                        }

                        flowPanel.Controls.Add(uc);
                    }

                    //Dodavanje kontrole za 2 radio dugmica
                    else if (item.GetCustomAttribute<TwoRadioButtonsAttribute>() != null)
                    {
                        TwoRadioButtonsControl uc = new TwoRadioButtonsControl();
                        uc.Name = item.Name;
                        uc.SetLabel(item.GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault().DisplayName);
                        uc.SetRadioButtons(item.GetCustomAttribute<TwoRadioButtonsAttribute>().Value1, item.GetCustomAttribute<TwoRadioButtonsAttribute>().Value2);
                        if (state == StateEnum.Update)
                        {
                            try
                            {
                                uc.SetChecked(item.GetValue(myInterface).ToString());
                            }
                            catch { }
                        }

                        flowPanel.Controls.Add(uc);
                    }

                    //Dodavanje kontrole za TextBox
                    else
                    {
                        InputControl uc = new InputControl();
                        uc.Name = item.Name;
                        uc.SetLabel(item.GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault().DisplayName);

                        if (state == StateEnum.Update)
                        {
                            try
                            {
                                uc.SetValueInTextBox(item.GetValue(myInterface).ToString());
                            }
                            catch { }
                        }

                        flowPanel.Controls.Add(uc);
                    }
                }
                i = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var properties = myInterface.GetType().GetProperties();
            bool i = true;
            //String za dodavanje imena polja koja su obavezna a nisu popunjena
            string imenaPolja = "";
            foreach (var item in flowPanel.Controls)
            {
                string value = "";

                if (item.GetType() == typeof(InputControl))
                {
                    InputControl input = item as InputControl;
                    value = input.GetValueFromTextBox();

                    PropertyInfo property = properties.Where(x => input.Name == x.Name).FirstOrDefault();
                    property.SetValue(myInterface, Convert.ChangeType(value, property.PropertyType));

                    //Provjera da li je obavezno polje prazno
                    if (value == "" && property.GetCustomAttribute<NotRequiredAttribute>() == null)
                        imenaPolja += input.Name + "\n";
                }
                else if (item.GetType() == typeof(InputDateControl))
                {
                    InputDateControl input = item as InputDateControl;
                    value = input.GetValueFromDateBox();

                    PropertyInfo property = properties.Where(x => input.Name == x.Name).FirstOrDefault();
                    property.SetValue(myInterface, Convert.ChangeType(value, property.PropertyType));

                    //Provjera da li je obavezno polje prazno
                    if (value == "" && property.GetCustomAttribute<NotRequiredAttribute>() == null)
                        imenaPolja += input.Name + "\n";
                }
                else if (item.GetType() == typeof(LookUpControl))
                {
                    LookUpControl input = item as LookUpControl;
                    value = input.GetKeyValue();

                    PropertyInfo property = properties.Where(x => input.Name == x.Name).FirstOrDefault();
                    property.SetValue(myInterface, Convert.ChangeType(value, property.PropertyType));

                    //Provjera da li je obavezno polje prazno
                    if (value == "" && property.GetCustomAttribute<NotRequiredAttribute>() == null)
                        imenaPolja += input.Name + "\n";
                }
            }

            //Izbacivanje MessageBox-a jer obavezna polja nisu popunjena
            if (imenaPolja != "")
            {
                MessageBox.Show("POPUNITE OBAVEZNA POLJA\n" + imenaPolja, "Greska pri unosu", MessageBoxButtons.OK);
                return;
            }

            //Provjera poziva Input forme
            if (state == StateEnum.Create)
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                    myInterface.GetInsertQuery(), myInterface.GetInsertParameters().ToArray());

                CRUD.IstorijaCRUD.Istorija(userEmail, StateEnum.Create,myInterface);
            }
            else if (state == StateEnum.Update)
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                                    myInterface.GetUpdateQuery(), myInterface.GetUpdateParameters().ToArray());

                CRUD.IstorijaCRUD.Istorija(userEmail, StateEnum.Update, myInterface);
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
