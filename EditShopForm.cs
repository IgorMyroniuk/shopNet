using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shopNet
{
    public partial class EditShopForm : Form
    {
        Shop tempShop;
        bool editShopFlag = false;
        bool saveChangeFlag;

        public EditShopForm(string formName, ref Shop refShop, bool editFlag, ref bool refSaveFlag)
        {
            InitializeComponent();
            this.Text = formName;
            this.tempShop = refShop;
            this.editShopFlag = editFlag;
            this.saveChangeFlag = refSaveFlag;

            connectionTypeComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            connectionTypeComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            connectionTypeComboBox1.SelectedIndex = 0;
            eth1GroupBox.Visible = false;
            connectionTypeComboBox2.SelectedIndex = 0;
            eth2GroupBox.Visible = false;

            if (editShopFlag) // заповнення даних якщо магазин редагується
            {
                shopNameTextBox.Text = refShop.name;
                shopAddressTextBox.Text = refShop.address;
                connectionTypeComboBox1.SelectedIndex = refShop.provider1.connectionType;
                eth1GroupBox.Visible = refShop.provider1.isActive;
                eth1CheckBox.Checked = refShop.provider1.isActive;

                if (refShop.provider1.isActive)
                {
                    providerNameTextBox1.Text = refShop.provider1.name;
                    ipAddressTextBox1.Text = refShop.provider1.ipAddress;
                    customerTextBox1.Text = refShop.provider1.customer;
                    contractNumberTextBox1.Text = refShop.provider1.contractNumber;
                    phoneNumberTextBox1.Text = refShop.provider1.phoneNumber;
                    connectionDateTimePicker1.Value = refShop.provider1.connectDayTime;

                    switch (refShop.provider1.connectionType)
                    {
                        case 0:
                            provInfoLine1TextBox1.Text = "";
                            provInfoLine2TextBox1.Text = "";
                            provInfoLine3TextBox1.Text = "";
                            break;
                        case 1:
                            provInfoLine1TextBox1.Text = refShop.provider1.connectionSettings0;
                            provInfoLine2TextBox1.Text = refShop.provider1.connectionSettings1;
                            provInfoLine3TextBox1.Text = "";
                            break;
                        case 2:
                            provInfoLine1TextBox1.Text = refShop.provider1.connectionSettings0;
                            provInfoLine2TextBox1.Text = refShop.provider1.connectionSettings1;
                            provInfoLine3TextBox1.Text = refShop.provider1.connectionSettings2;
                            break;
                    }
                }
                if (refShop.provider2.isActive)
                {
                    providerNameTextBox2.Text = refShop.provider2.name;
                    ipAddressTextBox2.Text = refShop.provider2.ipAddress;
                    customerTextBox2.Text = refShop.provider2.customer;
                    contractNumberTextBox2.Text = refShop.provider2.contractNumber;
                    phoneNumberTextBox2.Text = refShop.provider2.phoneNumber;
                    connectionTypeComboBox2.SelectedIndex = refShop.provider2.connectionType;
                    connectionDateTimePicker2.Value = refShop.provider2.connectDayTime;

                    switch (refShop.provider2.connectionType)
                    {
                        case 0:
                            provInfoLine1TextBox2.Text = "";
                            provInfoLine2TextBox2.Text = "";
                            provInfoLine3TextBox2.Text = "";
                            break;
                        case 1:
                            provInfoLine1TextBox2.Text = refShop.provider2.connectionSettings0;
                            provInfoLine2TextBox2.Text = refShop.provider2.connectionSettings1;
                            provInfoLine3TextBox2.Text = "";
                            break;
                        case 2:
                            provInfoLine1TextBox2.Text = refShop.provider2.connectionSettings0;
                            provInfoLine2TextBox2.Text = refShop.provider2.connectionSettings1;
                            provInfoLine3TextBox2.Text = refShop.provider2.connectionSettings2;
                            break;
                    }
                }
                eth2GroupBox.Visible = refShop.provider2.isActive;
                eth2CheckBox.Checked = refShop.provider2.isActive;
            }
        }

        private void EditShop_Load(object sender, EventArgs e)
        {

        }

        private void Eth1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            eth1GroupBox.Visible = eth1CheckBox.Checked;
        }

        private void ConnectionTypeComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //зміна типу інтернет-підключення eth1 
            if (providerNameTextBox1.Text != "Укртелеком")
                switch (connectionTypeComboBox1.SelectedIndex)
                {
                    case 0:
                        provInfoLine1Label1.Visible = false;
                        provInfoLine1TextBox1.Visible = false;
                        provInfoLine2Label1.Visible = false;
                        provInfoLine2TextBox1.Visible = false;
                        provInfoLine3Label1.Visible = false;
                        provInfoLine3TextBox1.Visible = false;
                        break;
                    case 1:
                        provInfoLine1Label1.Visible = true;
                        provInfoLine1Label1.Text = "PPPoE-логін:";
                        provInfoLine1TextBox1.Visible = true;
                        provInfoLine2Label1.Visible = true;
                        provInfoLine2Label1.Text = "PPPoE-пароль:";
                        provInfoLine2TextBox1.Visible = true;
                        provInfoLine3Label1.Visible = false;
                        provInfoLine3TextBox1.Visible = false;
                        break;
                    case 2:
                        provInfoLine1Label1.Visible = true;
                        provInfoLine1Label1.Text = "ІР-адреса:";
                        provInfoLine1TextBox1.Visible = true;
                        provInfoLine2Label1.Visible = true;
                        provInfoLine2Label1.Text = "Маска:";
                        provInfoLine2TextBox1.Visible = true;
                        provInfoLine3Label1.Visible = true;
                        provInfoLine3Label1.Text = "Шлюз:";
                        provInfoLine3TextBox1.Visible = true;
                        break;
                }
        }

        private void Eth2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            eth2GroupBox.Visible = eth2CheckBox.Checked;
        }

        private void ConnectionTypeComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //зміна типу інтернет-підключення eth1
            if (providerNameTextBox2.Text != "Укртелеком")
                switch (connectionTypeComboBox2.SelectedIndex)
                {
                    case 0:
                        provInfoLine1Label2.Visible = false;
                        provInfoLine1TextBox2.Visible = false;
                        provInfoLine2Label2.Visible = false;
                        provInfoLine2TextBox2.Visible = false;
                        provInfoLine3Label2.Visible = false;
                        provInfoLine3TextBox2.Visible = false;
                        break;
                    case 1:
                        provInfoLine1Label2.Visible = true;
                        provInfoLine1Label2.Text = "PPPoE-логін:";
                        provInfoLine1TextBox2.Visible = true;
                        provInfoLine2Label2.Visible = true;
                        provInfoLine2Label2.Text = "PPPoE-пароль:";
                        provInfoLine2TextBox2.Visible = true;
                        provInfoLine3Label2.Visible = false;
                        provInfoLine3TextBox2.Visible = false;
                        break;
                    case 2:
                        provInfoLine1Label2.Visible = true;
                        provInfoLine1Label2.Text = "ІР-адреса:";
                        provInfoLine1TextBox2.Visible = true;
                        provInfoLine2Label2.Visible = true;
                        provInfoLine2Label2.Text = "Маска:";
                        provInfoLine2TextBox2.Visible = true;
                        provInfoLine3Label2.Visible = true;
                        provInfoLine3Label2.Text = "Шлюз:";
                        provInfoLine3TextBox2.Visible = true;
                        break;
                }
        }

        private void ChangeProvidersButton_Click(object sender, EventArgs e)
        {
            byte flagProvider = 0;                              //
            if (!eth1CheckBox.Checked && !eth2CheckBox.Checked) //
                flagProvider = 0;                               //
                                                                //
            if (eth1CheckBox.Checked && !eth2CheckBox.Checked)  //
                flagProvider = 1;                               // перевірка стану чекбоксів
                                                                // eth1 та eth2
            if (!eth1CheckBox.Checked && eth2CheckBox.Checked)  //
                flagProvider = 2;                               //
                                                                //
            if (eth1CheckBox.Checked && eth2CheckBox.Checked)   //
                flagProvider = 3;                               //

            //взаємозаміна даних в полях провайдера
            switch (flagProvider)
            {
                case 0:
                    break;
                case 1:
                    eth2CheckBox.Checked = eth1CheckBox.Checked;
                    providerNameTextBox2.Text = providerNameTextBox1.Text;
                    connectionDateTimePicker2.Value = connectionDateTimePicker1.Value;
                    ipAddressTextBox2.Text = ipAddressTextBox1.Text;
                    customerTextBox2.Text = customerTextBox1.Text;
                    contractNumberTextBox2.Text = contractNumberTextBox1.Text;
                    phoneNumberTextBox2.Text = phoneNumberTextBox1.Text;
                    connectionTypeComboBox2.SelectedIndex = connectionTypeComboBox1.SelectedIndex;
                    provInfoLine1TextBox2.Text = provInfoLine1TextBox1.Text;
                    provInfoLine2TextBox2.Text = provInfoLine2TextBox1.Text;
                    provInfoLine3TextBox2.Text = provInfoLine3TextBox1.Text;
                    eth1CheckBox.Checked = false;
                    break;
                case 2:
                    eth1CheckBox.Checked = eth2CheckBox.Checked;
                    providerNameTextBox1.Text = providerNameTextBox2.Text;
                    connectionDateTimePicker1.Value = connectionDateTimePicker2.Value;
                    ipAddressTextBox1.Text = ipAddressTextBox2.Text;
                    customerTextBox1.Text = customerTextBox2.Text;
                    contractNumberTextBox1.Text = contractNumberTextBox2.Text;
                    phoneNumberTextBox1.Text = phoneNumberTextBox2.Text;
                    connectionTypeComboBox1.SelectedIndex = connectionTypeComboBox2.SelectedIndex;
                    provInfoLine1TextBox1.Text = provInfoLine1TextBox2.Text;
                    provInfoLine2TextBox1.Text = provInfoLine2TextBox2.Text;
                    provInfoLine3TextBox1.Text = provInfoLine3TextBox2.Text;
                    eth2CheckBox.Checked = false;
                    break;
                case 3:
                    string providerNameTEMP = providerNameTextBox1.Text;
                    providerNameTextBox1.Text = providerNameTextBox2.Text;
                    providerNameTextBox2.Text = providerNameTEMP;

                    DateTime connectionDateTEMP = connectionDateTimePicker1.Value;
                    connectionDateTimePicker1.Value = connectionDateTimePicker2.Value;
                    connectionDateTimePicker2.Value = connectionDateTEMP;

                    string ipAddressTEMP = ipAddressTextBox1.Text;
                    ipAddressTextBox1.Text = ipAddressTextBox2.Text;
                    ipAddressTextBox2.Text = ipAddressTEMP;

                    string customerTEMP = customerTextBox1.Text;
                    customerTextBox1.Text = customerTextBox2.Text;
                    customerTextBox2.Text = customerTEMP;

                    string contractNumberTEMP = contractNumberTextBox1.Text;
                    contractNumberTextBox1.Text = contractNumberTextBox2.Text;
                    contractNumberTextBox2.Text = contractNumberTEMP;

                    string phoneNumberTEMP = phoneNumberTextBox1.Text;
                    phoneNumberTextBox1.Text = phoneNumberTextBox2.Text;
                    phoneNumberTextBox2.Text = phoneNumberTEMP;

                    int connectionTypeTEMP = connectionTypeComboBox1.SelectedIndex;
                    connectionTypeComboBox1.SelectedIndex = connectionTypeComboBox2.SelectedIndex;
                    connectionTypeComboBox2.SelectedIndex = connectionTypeTEMP;

                    string provInfoLine1TEMP = provInfoLine1TextBox1.Text;
                    provInfoLine1TextBox1.Text = provInfoLine1TextBox2.Text;
                    provInfoLine1TextBox2.Text = provInfoLine1TEMP;

                    string provInfoLine2TEMP = provInfoLine2TextBox1.Text;
                    provInfoLine2TextBox1.Text = provInfoLine2TextBox2.Text;
                    provInfoLine2TextBox2.Text = provInfoLine2TEMP;


                    string provInfoLine3TEMP = provInfoLine3TextBox1.Text;
                    provInfoLine3TextBox1.Text = provInfoLine3TextBox2.Text;
                    provInfoLine3TextBox2.Text = provInfoLine3TEMP;

                    break;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            tempShop.saveChangeFlag = true;      // дані зберігаються

            // якщо магазин редагувався
            if (editShopFlag)
            {
                tempShop.address = shopAddressTextBox.Text;
                tempShop.name = shopNameTextBox.Text;
                tempShop.openDate = openDateTimePicker.Value;

                byte flagProvider = 0;
                if (!eth1CheckBox.Checked && !eth2CheckBox.Checked)
                    flagProvider = 0;

                if (eth1CheckBox.Checked && !eth2CheckBox.Checked)
                    flagProvider = 1;

                if (!eth1CheckBox.Checked && eth2CheckBox.Checked)
                    flagProvider = 2;

                if (eth1CheckBox.Checked && eth2CheckBox.Checked)
                    flagProvider = 3;

                switch (flagProvider)
                {
                    case 0:
                        tempShop.provider1.isActive = eth1CheckBox.Checked;
                        tempShop.provider1.name = "";
                        tempShop.provider1.connectDayTime = default;
                        tempShop.provider1.ipAddress = "";
                        tempShop.provider1.customer = "";
                        tempShop.provider1.contractNumber = "";
                        tempShop.provider1.phoneNumber = "";
                        tempShop.provider1.connectionType = 0;
                        tempShop.provider1.connectionSettings0 = "";
                        tempShop.provider1.connectionSettings1 = "";
                        tempShop.provider1.connectionSettings2 = "";

                        tempShop.provider2.isActive = eth2CheckBox.Checked;
                        tempShop.provider2.name = "";
                        tempShop.provider2.connectDayTime = default;
                        tempShop.provider2.ipAddress = "";
                        tempShop.provider2.customer = "";
                        tempShop.provider2.contractNumber = "";
                        tempShop.provider2.phoneNumber = "";
                        tempShop.provider2.connectionType = 0;
                        tempShop.provider2.connectionSettings0 = "";
                        tempShop.provider2.connectionSettings1 = "";
                        tempShop.provider2.connectionSettings2 = "";
                        break;
                    case 1:
                        tempShop.provider2.isActive = eth2CheckBox.Checked;
                        tempShop.provider2.name = "";
                        tempShop.provider2.connectDayTime = default;
                        tempShop.provider2.ipAddress = "";
                        tempShop.provider2.customer = "";
                        tempShop.provider2.contractNumber = "";
                        tempShop.provider2.phoneNumber = "";
                        tempShop.provider2.connectionType = 0;
                        tempShop.provider2.connectionSettings0 = "";
                        tempShop.provider2.connectionSettings1 = "";
                        tempShop.provider2.connectionSettings2 = "";

                        tempShop.provider1.isActive = eth1CheckBox.Checked;
                        tempShop.provider1.name = providerNameTextBox1.Text;
                        tempShop.provider1.connectDayTime = connectionDateTimePicker1.Value;
                        tempShop.provider1.ipAddress = ipAddressTextBox1.Text;
                        tempShop.provider1.customer = customerTextBox1.Text;
                        tempShop.provider1.contractNumber = contractNumberTextBox1.Text;
                        tempShop.provider1.phoneNumber = phoneNumberTextBox1.Text;
                        tempShop.provider1.connectionType = Convert.ToByte(connectionTypeComboBox1.SelectedIndex);
                        switch (tempShop.provider1.connectionType)
                        {
                            case 0:
                                tempShop.provider1.connectionSettings0 = "";
                                tempShop.provider1.connectionSettings1 = "";
                                tempShop.provider1.connectionSettings2 = "";
                                break;
                            case 1:
                                tempShop.provider1.connectionSettings0 = provInfoLine1TextBox1.Text;
                                tempShop.provider1.connectionSettings1 = provInfoLine2TextBox1.Text;
                                tempShop.provider1.connectionSettings2 = "";
                                break;
                            case 2:
                                tempShop.provider1.connectionSettings0 = provInfoLine1TextBox1.Text;
                                tempShop.provider1.connectionSettings1 = provInfoLine2TextBox1.Text;
                                tempShop.provider1.connectionSettings2 = provInfoLine3TextBox1.Text;
                                break;
                        }
                        break;
                    case 2:
                        tempShop.provider1.isActive = eth1CheckBox.Checked;
                        tempShop.provider1.name = "";
                        tempShop.provider1.connectDayTime = default;
                        tempShop.provider1.ipAddress = "";
                        tempShop.provider1.customer = "";
                        tempShop.provider1.contractNumber = "";
                        tempShop.provider1.phoneNumber = "";
                        tempShop.provider1.connectionType = 0;
                        tempShop.provider1.connectionSettings0 = "";
                        tempShop.provider1.connectionSettings1 = "";
                        tempShop.provider1.connectionSettings2 = "";

                        tempShop.provider2.isActive = eth2CheckBox.Checked;
                        tempShop.provider2.name = providerNameTextBox2.Text;
                        tempShop.provider2.connectDayTime = connectionDateTimePicker2.Value;
                        tempShop.provider2.ipAddress = ipAddressTextBox2.Text;
                        tempShop.provider2.customer = customerTextBox2.Text;
                        tempShop.provider2.contractNumber = contractNumberTextBox2.Text;
                        tempShop.provider2.phoneNumber = phoneNumberTextBox2.Text;
                        tempShop.provider2.connectionType = Convert.ToByte(connectionTypeComboBox2.SelectedIndex);
                        switch (tempShop.provider2.connectionType)
                        {
                            case 0:
                                tempShop.provider2.connectionSettings0 = "";
                                tempShop.provider2.connectionSettings1 = "";
                                tempShop.provider2.connectionSettings2 = "";
                                break;
                            case 1:
                                tempShop.provider2.connectionSettings0 = provInfoLine1TextBox2.Text;
                                tempShop.provider2.connectionSettings1 = provInfoLine2TextBox2.Text;
                                tempShop.provider2.connectionSettings2 = "";
                                break;
                            case 2:
                                tempShop.provider2.connectionSettings0 = provInfoLine1TextBox2.Text;
                                tempShop.provider2.connectionSettings1 = provInfoLine2TextBox2.Text;
                                tempShop.provider2.connectionSettings2 = provInfoLine3TextBox2.Text;
                                break;
                        }
                        break;
                    case 3:
                        tempShop.provider1.isActive = eth1CheckBox.Checked;
                        tempShop.provider1.name = providerNameTextBox1.Text;
                        tempShop.provider1.connectDayTime = connectionDateTimePicker1.Value;
                        tempShop.provider1.ipAddress = ipAddressTextBox1.Text;
                        tempShop.provider1.customer = customerTextBox1.Text;
                        tempShop.provider1.contractNumber = contractNumberTextBox1.Text;
                        tempShop.provider1.phoneNumber = phoneNumberTextBox1.Text;
                        tempShop.provider1.connectionType = Convert.ToByte(connectionTypeComboBox1.SelectedIndex);
                        switch (tempShop.provider1.connectionType)
                        {
                            case 0:
                                tempShop.provider1.connectionSettings0 = "";
                                tempShop.provider1.connectionSettings1 = "";
                                tempShop.provider1.connectionSettings2 = "";
                                break;
                            case 1:
                                tempShop.provider1.connectionSettings0 = provInfoLine1TextBox1.Text;
                                tempShop.provider1.connectionSettings1 = provInfoLine2TextBox1.Text;
                                tempShop.provider1.connectionSettings2 = "";
                                break;
                            case 2:
                                tempShop.provider1.connectionSettings0 = provInfoLine1TextBox1.Text;
                                tempShop.provider1.connectionSettings1 = provInfoLine2TextBox1.Text;
                                tempShop.provider1.connectionSettings2 = provInfoLine3TextBox1.Text;
                                break;
                        }
                        tempShop.provider2.isActive = eth2CheckBox.Checked;
                        tempShop.provider2.name = providerNameTextBox2.Text;
                        tempShop.provider2.connectDayTime = connectionDateTimePicker2.Value;
                        tempShop.provider2.ipAddress = ipAddressTextBox2.Text;
                        tempShop.provider2.customer = customerTextBox2.Text;
                        tempShop.provider2.contractNumber = contractNumberTextBox2.Text;
                        tempShop.provider2.phoneNumber = phoneNumberTextBox2.Text;
                        tempShop.provider2.connectionType = Convert.ToByte(connectionTypeComboBox2.SelectedIndex);

                        switch (tempShop.provider2.connectionType)
                        {
                            case 0:
                                tempShop.provider2.connectionSettings0 = "";
                                tempShop.provider2.connectionSettings1 = "";
                                tempShop.provider2.connectionSettings2 = "";
                                break;
                            case 1:
                                tempShop.provider2.connectionSettings0 = provInfoLine1TextBox2.Text;
                                tempShop.provider2.connectionSettings1 = provInfoLine2TextBox2.Text;
                                tempShop.provider2.connectionSettings2 = "";
                                break;
                            case 2:
                                tempShop.provider2.connectionSettings0 = provInfoLine1TextBox2.Text;
                                tempShop.provider2.connectionSettings1 = provInfoLine2TextBox2.Text;
                                tempShop.provider2.connectionSettings2 = provInfoLine3TextBox2.Text;
                                break;
                        }
                        break;
                }
                Close();
            }
            else
            {
                tempShop.address = shopAddressTextBox.Text;
                tempShop.name = shopNameTextBox.Text;

                byte flagProvider = 0;
                if (!eth1CheckBox.Checked && !eth2CheckBox.Checked)
                    flagProvider = 0;

                if (eth1CheckBox.Checked && !eth2CheckBox.Checked)
                    flagProvider = 1;

                if (!eth1CheckBox.Checked && eth2CheckBox.Checked)
                    flagProvider = 2;

                if (eth1CheckBox.Checked && eth2CheckBox.Checked)
                    flagProvider = 3;

                switch (flagProvider)
                {
                    case 0:
                        break;
                    case 1:
                        tempShop.provider1.isActive = eth1CheckBox.Checked;
                        tempShop.provider1.name = providerNameTextBox1.Text;
                        tempShop.provider1.connectDayTime = connectionDateTimePicker1.Value;
                        tempShop.provider1.ipAddress = ipAddressTextBox1.Text;
                        tempShop.provider1.customer = customerTextBox1.Text;
                        tempShop.provider1.contractNumber = contractNumberTextBox1.Text;
                        tempShop.provider1.phoneNumber = phoneNumberTextBox1.Text;
                        tempShop.provider1.connectionType = Convert.ToByte(connectionTypeComboBox1.SelectedIndex);
                        switch (tempShop.provider1.connectionType)
                        {
                            case 0:
                                tempShop.provider1.connectionSettings0 = "";
                                tempShop.provider1.connectionSettings1 = "";
                                tempShop.provider1.connectionSettings2 = "";
                                break;
                            case 1:
                                tempShop.provider1.connectionSettings0 = provInfoLine1TextBox1.Text;
                                tempShop.provider1.connectionSettings1 = provInfoLine2TextBox1.Text;
                                tempShop.provider1.connectionSettings2 = "";
                                break;
                            case 2:
                                tempShop.provider1.connectionSettings0 = provInfoLine1TextBox1.Text;
                                tempShop.provider1.connectionSettings1 = provInfoLine2TextBox1.Text;
                                tempShop.provider1.connectionSettings2 = provInfoLine3TextBox1.Text;
                                break;
                        }
                        break;
                    case 2:
                        tempShop.provider2.isActive = eth2CheckBox.Checked;
                        tempShop.provider2.name = providerNameTextBox2.Text;
                        tempShop.provider2.connectDayTime = connectionDateTimePicker2.Value;
                        tempShop.provider2.ipAddress = ipAddressTextBox2.Text;
                        tempShop.provider2.customer = customerTextBox2.Text;
                        tempShop.provider2.contractNumber = contractNumberTextBox2.Text;
                        tempShop.provider2.phoneNumber = phoneNumberTextBox2.Text;
                        tempShop.provider2.connectionType = Convert.ToByte(connectionTypeComboBox2.SelectedIndex);
                        switch (tempShop.provider2.connectionType)
                        {
                            case 0:
                                tempShop.provider2.connectionSettings0 = "";
                                tempShop.provider2.connectionSettings1 = "";
                                tempShop.provider2.connectionSettings2 = "";
                                break;
                            case 1:
                                tempShop.provider2.connectionSettings0 = provInfoLine1TextBox2.Text;
                                tempShop.provider2.connectionSettings1 = provInfoLine2TextBox2.Text;
                                tempShop.provider2.connectionSettings2 = "";
                                break;
                            case 2:
                                tempShop.provider2.connectionSettings0 = provInfoLine1TextBox2.Text;
                                tempShop.provider2.connectionSettings1 = provInfoLine2TextBox2.Text;
                                tempShop.provider2.connectionSettings2 = provInfoLine3TextBox2.Text;
                                break;
                        }
                        break;
                    case 3:
                        tempShop.provider1.isActive = eth1CheckBox.Checked;
                        tempShop.provider1.name = providerNameTextBox1.Text;
                        tempShop.provider1.connectDayTime = connectionDateTimePicker1.Value;
                        tempShop.provider1.ipAddress = ipAddressTextBox1.Text;
                        tempShop.provider1.customer = customerTextBox1.Text;
                        tempShop.provider1.contractNumber = contractNumberTextBox1.Text;
                        tempShop.provider1.phoneNumber = phoneNumberTextBox1.Text;
                        tempShop.provider1.connectionType = Convert.ToByte(connectionTypeComboBox1.SelectedIndex);
                        switch (tempShop.provider1.connectionType)
                        {
                            case 0:
                                tempShop.provider1.connectionSettings0 = "";
                                tempShop.provider1.connectionSettings1 = "";
                                tempShop.provider1.connectionSettings2 = "";
                                break;
                            case 1:
                                tempShop.provider1.connectionSettings0 = provInfoLine1TextBox1.Text;
                                tempShop.provider1.connectionSettings1 = provInfoLine2TextBox1.Text;
                                tempShop.provider1.connectionSettings2 = "";
                                break;
                            case 2:
                                tempShop.provider1.connectionSettings0 = provInfoLine1TextBox1.Text;
                                tempShop.provider1.connectionSettings1 = provInfoLine2TextBox1.Text;
                                tempShop.provider1.connectionSettings2 = provInfoLine3TextBox1.Text;
                                break;
                        }
                        tempShop.provider2.isActive = eth2CheckBox.Checked;
                        tempShop.provider2.name = providerNameTextBox2.Text;
                        tempShop.provider2.connectDayTime = connectionDateTimePicker2.Value;
                        tempShop.provider2.ipAddress = ipAddressTextBox2.Text;
                        tempShop.provider2.customer = customerTextBox2.Text;
                        tempShop.provider2.contractNumber = contractNumberTextBox2.Text;
                        tempShop.provider2.phoneNumber = phoneNumberTextBox2.Text;
                        tempShop.provider2.connectionType = Convert.ToByte(connectionTypeComboBox2.SelectedIndex);
                        switch (tempShop.provider2.connectionType)
                        {
                            case 0:
                                tempShop.provider2.connectionSettings0 = "";
                                tempShop.provider2.connectionSettings1 = "";
                                tempShop.provider2.connectionSettings2 = "";
                                break;
                            case 1:
                                tempShop.provider2.connectionSettings0 = provInfoLine1TextBox2.Text;
                                tempShop.provider2.connectionSettings1 = provInfoLine2TextBox2.Text;
                                tempShop.provider2.connectionSettings2 = "";
                                break;
                            case 2:
                                tempShop.provider2.connectionSettings0 = provInfoLine1TextBox2.Text;
                                tempShop.provider2.connectionSettings1 = provInfoLine2TextBox2.Text;
                                tempShop.provider2.connectionSettings2 = provInfoLine3TextBox2.Text;
                                break;
                        }
                        break;
                }
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void providerNameTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (providerNameTextBox1.Text == "Укртелеком")
            {
                provInfoLine1Label1.Text = "Мережа";
                provInfoLine1Label1.Visible = true;
                provInfoLine1TextBox1.Visible = true;
                provInfoLine2Label1.Text = "Логін послуги";
                provInfoLine2Label1.Visible = true;
                provInfoLine2TextBox1.Visible = true;
                provInfoLine3Label1.Text = "Додаткова інформація";
                provInfoLine3TextBox1.Visible = true;
                provInfoLine3Label1.Visible = true;
            }
            if (providerNameTextBox2.Text == "Укртелеком")
            {
                provInfoLine1Label2.Text = "Мережа";
                provInfoLine1Label2.Visible = true;
                provInfoLine1TextBox2.Visible = true;
                provInfoLine2Label2.Text = "Логін послуги";
                provInfoLine2Label2.Visible = true;
                provInfoLine2TextBox2.Visible = true;
                provInfoLine3Label2.Text = "Додаткова інформація";
                provInfoLine3TextBox2.Visible = true;
                provInfoLine3Label2.Visible = true;
            }
        }
    }
}
