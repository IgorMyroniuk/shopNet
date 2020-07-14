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
    public partial class MainForm : Form
    {

        DataManager listOfShop = new DataManager();      //  
        Shop tempShop;
        bool saveChangeFlag = false;                     // змінна для перевірки чи зберігалися зміни
        string message;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ShopsListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewShopButton_Click(object sender, EventArgs e)
        {
            Shop newShop = new Shop("Новий 1");
            Form editShop = new EditShopForm("Додати новий магазин", ref newShop, false, ref saveChangeFlag);
            editShop.ShowDialog();
            this.Visible = false;

            if (newShop.saveChangeFlag)
            {
                shopsListBox.Items.Clear();
                listOfShop.shopsList.Add(newShop);
                foreach (Shop shops in listOfShop.shopsList)
                {
                    shopsListBox.Items.Add(shops);
                }
            }
            this.Visible = true;
        }

        private void зберегтиДаніToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin";
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
                listOfShop.saveShopsListInFile(listOfShop.shopsList, saveFileDialog.FileName);
        }

        private void editShopButton_Click(object sender, EventArgs e)
        {
            if (shopsListBox.SelectedIndex > -1)
            {
                tempShop = shopsListBox.SelectedItem as Shop;
                Form editShop = new EditShopForm("Редагувати магазин", ref tempShop, true, ref saveChangeFlag);
                this.Visible = false;
                editShop.ShowDialog();
                shopsListBox.Items.Clear();
                foreach (Shop shops in listOfShop.shopsList)
                {
                    shopsListBox.Items.Add(shops);
                }
                this.Visible = true;

            }
            else
                MessageBox.Show("Виберіть магазин зі списку", "Помилка");
        }

        private void deleteShopButton_Click(object sender, EventArgs e)
        {
            listOfShop.shopsList.Remove(shopsListBox.SelectedItem as Shop);
            shopsListBox.Items.RemoveAt(shopsListBox.SelectedIndex);

        }

        private void ShopsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shopsListBox.SelectedIndex > -1)
            {
                Shop viewShop = shopsListBox.SelectedItem as Shop;

                connectionTypeComboBox1.SelectedIndex = viewShop.provider1.connectionType;
                eth1.Visible = viewShop.provider1.isActive;
                eth2.Visible = viewShop.provider2.isActive;
                if (viewShop.provider1.isActive)
                {
                    providerNameTextBox1.Text = viewShop.provider1.name;
                    ipAddressTextBox1.Text = viewShop.provider1.ipAddress;
                    customerTextBox1.Text = viewShop.provider1.customer;
                    contractNumberTextBox1.Text = viewShop.provider1.contractNumber;
                    phoneNumberTextBox1.Text = viewShop.provider1.phoneNumber;
                    switch (viewShop.provider1.connectionType)
                    {
                        case 0:
                            provInfoLine1TextBox1.Text = "";
                            provInfoLine1TextBox1.Visible = false;
                            provInfoLine1Label1.Visible = false;
                            provInfoLine2TextBox1.Text = "";
                            provInfoLine2TextBox1.Visible = false;
                            provInfoLine2Label1.Visible = false;
                            provInfoLine3TextBox1.Text = "";
                            provInfoLine3TextBox1.Visible = false;
                            provInfoLine3Label1.Visible = false;
                            break;

                        case 1:
                            provInfoLine1TextBox1.Text = viewShop.provider1.connectionSettings0;
                            provInfoLine1TextBox1.Visible = true;
                            provInfoLine1Label1.Text = "PPPoE-логін";
                            provInfoLine1Label1.Visible = true;
                            provInfoLine2TextBox1.Text = viewShop.provider1.connectionSettings1;
                            provInfoLine2TextBox1.Visible = true;
                            provInfoLine2Label1.Text = "PPPoE-пароль";
                            provInfoLine2Label1.Visible = true;
                            provInfoLine3TextBox1.Text = "";
                            provInfoLine3TextBox1.Visible = false;
                            provInfoLine3Label1.Visible = false;

                            if (viewShop.provider1.name == "Укртелеком")
                            {
                                provInfoLine1Label1.Text = "Мережа";
                                provInfoLine2Label1.Text = "Логін послуги";
                                provInfoLine3Label1.Text = "Додаткова інформація";
                                provInfoLine3TextBox1.Text = viewShop.provider1.connectionSettings2;
                                provInfoLine3TextBox1.Visible = true;
                                provInfoLine3Label1.Visible = true;
                            }
                            break;

                        case 2:
                            provInfoLine1TextBox1.Text = viewShop.provider1.connectionSettings0;
                            provInfoLine1TextBox1.Visible = true;
                            provInfoLine1Label1.Text = "ІР-адреса";
                            provInfoLine1Label1.Visible = true;
                            provInfoLine2TextBox1.Text = viewShop.provider1.connectionSettings1;
                            provInfoLine2TextBox1.Visible = true;
                            provInfoLine2Label1.Text = "Маска";
                            provInfoLine2Label1.Visible = true;
                            provInfoLine3TextBox1.Text = viewShop.provider1.connectionSettings2;
                            provInfoLine3TextBox1.Visible = true;
                            provInfoLine3Label1.Text = "Шлюз";
                            provInfoLine3Label1.Visible = true;

                            if (viewShop.provider1.name == "Укртелеком")
                            {
                                provInfoLine1Label1.Text = "Мережа";
                                provInfoLine2Label1.Text = "Логін послуги";
                                provInfoLine3Label1.Text = "Додаткова інформація";
                                provInfoLine3TextBox1.Text = viewShop.provider1.connectionSettings2;
                                provInfoLine3TextBox1.Visible = true;
                                provInfoLine3Label1.Visible = true;
                            }
                            break;
                    }
                }
                if (viewShop.provider2.isActive)
                {
                    providerNameTextBox2.Text = viewShop.provider2.name;
                    ipAddressTextBox2.Text = viewShop.provider2.ipAddress;
                    customerTextBox2.Text = viewShop.provider2.customer;
                    contractNumberTextBox2.Text = viewShop.provider2.contractNumber;
                    phoneNumberTextBox2.Text = viewShop.provider2.phoneNumber;
                    connectionTypeComboBox2.SelectedIndex = viewShop.provider2.connectionType;
                    switch (viewShop.provider2.connectionType)
                    {
                        case 0:
                            provInfoLine1TextBox2.Text = "";
                            provInfoLine1TextBox2.Visible = false;
                            provInfoLine1Label2.Visible = false;
                            provInfoLine2TextBox2.Text = "";
                            provInfoLine2TextBox2.Visible = false;
                            provInfoLine2Label2.Visible = false;
                            provInfoLine3TextBox2.Text = "";
                            provInfoLine3TextBox2.Visible = false;
                            provInfoLine3Label2.Visible = false;
                            break;
                        case 1:
                            provInfoLine1TextBox2.Text = viewShop.provider2.connectionSettings0;
                            provInfoLine1TextBox2.Visible = true;
                            provInfoLine1Label2.Text = "PPPoE-логін";
                            provInfoLine1Label2.Visible = true;
                            provInfoLine2TextBox2.Text = viewShop.provider2.connectionSettings1;
                            provInfoLine2TextBox2.Visible = true;
                            provInfoLine2Label2.Text = "PPPoE-пароль";
                            provInfoLine2Label2.Visible = true;
                            provInfoLine3TextBox2.Text = "";
                            provInfoLine3TextBox2.Visible = false;
                            provInfoLine3Label2.Visible = false;
                            if (viewShop.provider2.name == "Укртелеком")
                            {
                                provInfoLine1Label2.Text = "Мережа";
                                provInfoLine2Label2.Text = "Логін послуги";
                                provInfoLine3Label2.Text = "Додаткова інформація";
                                provInfoLine3TextBox2.Text = viewShop.provider2.connectionSettings2;
                                provInfoLine3TextBox2.Visible = true;
                                provInfoLine3Label2.Visible = true;
                            }
                            break;
                        case 2:
                            provInfoLine1TextBox2.Text = viewShop.provider2.connectionSettings0;
                            provInfoLine1TextBox2.Visible = true;
                            provInfoLine1Label2.Text = "ІР-адреса";
                            provInfoLine1Label2.Visible = true;
                            provInfoLine2TextBox2.Text = viewShop.provider2.connectionSettings1;
                            provInfoLine2TextBox2.Visible = true;
                            provInfoLine2Label2.Text = "Маска";
                            provInfoLine2Label2.Visible = true;
                            provInfoLine3TextBox2.Text = viewShop.provider2.connectionSettings2;
                            provInfoLine3TextBox2.Visible = true;
                            provInfoLine3Label2.Text = "Шлюз";
                            provInfoLine3Label2.Visible = true;
                            if (viewShop.provider2.name == "Укртелеком")
                            {
                                provInfoLine1Label2.Text = "Мережа";
                                provInfoLine2Label2.Text = "Логін послуги";
                                provInfoLine3Label2.Text = "Додаткова інформація";
                                provInfoLine3TextBox2.Text = viewShop.provider2.connectionSettings2;
                                provInfoLine3TextBox2.Visible = true;
                                provInfoLine3Label2.Visible = true;
                            }
                            break;
                    }
                }
            }
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tempShop != null)
                if (MessageBox.Show("Зберегти зміни?", "Вихід", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    listOfShop.saveShopsListInFile(listOfShop.shopsList);
        }

        private void відкритиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary files (*.bin)|*.bin";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    listOfShop.shopsList = listOfShop.loadShopsFromFile(openFileDialog.FileName);     // загружаємо дані із файлу
                    listOfShop.ListPath = openFileDialog.FileName;

                    message = "Файл завантажено";

                    shopsListBox.Items.Clear();                             //
                    foreach (Shop shops in listOfShop.shopsList)            //
                    {                                                       // заповнення ListBox
                        shopsListBox.Items.Add(shops);                      // 
                    }                                                       //
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
                finally
                {
                    MessageBox.Show(message);
                }
        }

        private void новийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shopsListBox.Items.Clear();
            listOfShop.shopsList = new List<Shop>();

        }

        private void імпортЗExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int index;
            index = shopsListBox.FindString(searchTextBox.Text);
            if (index > -1)
                shopsListBox.SelectedIndex = index;
        }
    }
}
