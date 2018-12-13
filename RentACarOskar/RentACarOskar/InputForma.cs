using KonekcijaNaBazu;
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

        List<string> listaUpdate;

        public InputForma()
        {
            InitializeComponent();
        }

        public InputForma(PropertyInterface myInterface, StateEnum state, List<string> listaUpdate)
        {
            InitializeComponent();

            this.myInterface = myInterface;
            this.listaUpdate = listaUpdate;
            this.state = state;
            PopulateControls();
        }


        public InputForma(PropertyInterface myInterface, StateEnum state)
        {
            InitializeComponent();

            this.myInterface = myInterface;
            this.state = state;
            PopulateControls();
        }
        private void PopulateControls()
        {
            // int i = 0;
            foreach (PropertyInfo item in myInterface.GetType().GetProperties())
            {
                InputControl inputControl = new InputControl();
                inputControl.Name = item.Name;
                inputControl.SetLabel(item.GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault().DisplayName);
                if (state == StateEnum.Update)
                {
                    inputControl.SetValueInTextBox(item.GetValue(myInterface).ToString());
                    // inputControl.SetValue(listaUpdate[i]);
                    // i++;

                }
                flowPanel.Controls.Add(inputControl);
                //if (item.)
                //{

                //}
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
