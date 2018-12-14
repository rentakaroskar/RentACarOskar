using KonekcijaNaBazu;
using RentACarOskar.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        public InputForma()
        {
            InitializeComponent();
        }

        public InputForma(PropertyInterface myInterface, StateEnum state)
        {
            InitializeComponent();

            this.myInterface = myInterface;
            this.state = state;
            PopulateControls();
        }


        // PopulateControls je gotov treba jos napraviti lookup funkciju
        private void PopulateControls()
        {
            bool i = true;
            foreach (PropertyInfo item in myInterface.GetType().GetProperties())
            {
                if (i == false)
                {
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
                    else if(item.GetCustomAttributes<ForeignKeyAttribute>() != null && item.Name.Contains("ID"))
                    {
                        LookUpControl uc = new LookUpControl(myInterface);
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

            foreach (var item in flowPanel.Controls)
            {
                if (item.GetType() == typeof(InputControl))
                {
                    InputControl input = item as InputControl;
                    string value = input.GetValueFromTextBox();

                    PropertyInfo property = properties.Where(x => input.Name == x.Name).FirstOrDefault();
                    property.SetValue(myInterface, Convert.ChangeType(value, property.PropertyType));
                }
            }
            if (state == StateEnum.Create)
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                    myInterface.GetInsertQuery(), myInterface.GetInsertParameters().ToArray());
            }
            else if (state == StateEnum.Update)
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.GetConnectionString(), CommandType.Text,
                                    myInterface.GetUpdateQuery(), myInterface.GetUpdateParameters().ToArray());
            }
        }
    }
}
