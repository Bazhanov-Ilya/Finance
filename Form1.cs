using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finance {
    public partial class MainForm : Form {
        DbConnector db;
        public MainForm() {
            InitializeComponent();
            db = new DbConnector();
            Start_deposit.Text = db.LoadStartDeposit() + " руб.";
            depositNow.Text = db.LoadDeposit() + " руб.";
            persentDeposite.Text = db.LoadPercentDeposit(float.Parse(db.LoadStartDeposit()), float.Parse(db.LoadDeposit())) + " %";
            startDepositeBtn.Hide();
            textBoxEditStartDeposit.Hide();
            CloseEditDepositButton.Hide();
            CloseEditDepositButton.Hide();
            AddFuturesTextBox.Hide();
            Editbutton.Hide();
            DelButton.Hide();
            Addutton.Hide();
            CloseEditFuturesButton.Hide();
            checkBoxDateFilter.Hide();
            checkBoxFuturesFilter.Hide();
            dateTimePicker2.Hide();
            dateTimePicker3.Hide();
            comboBoxFuturesFilter.Hide();
            buttonFilter.Hide();
            buttonCloseFinter.Hide();
        }

        public void Clear() {
            profitBox.Clear();
            dateTimePicker1.Value = DateTime.Now;
            
        }

        private void AddProfitBtn_Click(object sender, EventArgs e) {
            bool check;
            bool check2;
            if (dateTimePicker1.Text.Trim() == string.Empty || profitBox.Text.Trim() == string.Empty || FuturesComboBox.Text.Trim() == string.Empty)
                MessageBox.Show("Please fill out all fields");
            else {
                check = db.AddProfit(dateTimePicker1.Value.ToShortDateString(), profitBox.Text, FuturesComboBox.Text);
                check2= db.AddDeposite();
                
                if (check && check2)
                    Clear();
                depositNow.Text = db.LoadDeposit() + " руб.";
                persentDeposite.Text = db.LoadPercentDeposit(float.Parse(db.LoadStartDeposit()), float.Parse(db.LoadDeposit())) + " %";
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dBFinanceDataSet.Futures". При необходимости она может быть перемещена или удалена.
            this.futuresTableAdapter.Fill(this.dBFinanceDataSet.Futures);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dBFinanceDataSet.Futures". При необходимости она может быть перемещена или удалена.
            this.futuresTableAdapter.Fill(this.dBFinanceDataSet.Futures);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dBFinanceDataSet.Futures". При необходимости она может быть перемещена или удалена.
            this.futuresTableAdapter.Fill(this.dBFinanceDataSet.Futures);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dBFinanceDataSet.Futures". При необходимости она может быть перемещена или удалена.
            this.futuresTableAdapter.Fill(this.dBFinanceDataSet.Futures);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dBFinanceDataSet.Table". При необходимости она может быть перемещена или удалена.


        }

        private void profitBox_KeyPress(object sender, KeyPressEventArgs e) {

char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number != 45) //цифры, клавиша BackSpace и запятая и минус в ASCII
            {
                e.Handled = true;
            }
        }

        private void startDepositeBtn_Click(object sender, EventArgs e) {
            db.edidStartDeposit(textBoxEditStartDeposit.Text);
            
            
        }

       

        private void CloseEditDepositButton_Click(object sender, EventArgs e) {

            buttonEditStartDeposit.Show();
            startDepositeBtn.Hide();
            textBoxEditStartDeposit.Hide();
            CloseEditDepositButton.Hide();
        }

        private void button1_Click(object sender, EventArgs e) {
         
            CloseEditFuturesButton.Show();
        }

        private void CloseEditFuturesButton_Click(object sender, EventArgs e) {
            buttonEdidFutures.Show();
            AddFuturesTextBox.Hide();
            Editbutton.Hide();
            DelButton.Hide();
            Addutton.Hide();
            CloseEditFuturesButton.Hide();



        }

        private void button4_Click(object sender, EventArgs e) {
            buttonEdidFutures.Hide();
            AddFuturesTextBox.Show();
            Editbutton.Show();
            DelButton.Show();
            Addutton.Show();
            CloseEditFuturesButton.Show();
        }

        private void buttonUpdate_Click(object sender, EventArgs e) {
            this.Hide();
            MainForm form = new MainForm();
            
            form.Show();
        }

        private void buttonEditStartDeposit_Click(object sender, EventArgs e) {
            buttonEditStartDeposit.Hide();
            textBoxEditStartDeposit.Show();
            CloseEditDepositButton.Show();
            startDepositeBtn.Show();
        }

        private void Addutton_Click(object sender, EventArgs e) {
            db.AddFutures(AddFuturesTextBox.Text);
        }

        private void DelButton_Click(object sender, EventArgs e) {
            db.DeleteFutures(FuturesComboBox.Text);
        }

        private void Editbutton_Click(object sender, EventArgs e) {
            db.EditFutures(FuturesComboBox.Text, AddFuturesTextBox.Text);
        }

        private void buttonShowFilter_Click(object sender, EventArgs e) {
            checkBoxDateFilter.Show();
            checkBoxFuturesFilter.Show();
            dateTimePicker2.Show();
            dateTimePicker3.Show();
            comboBoxFuturesFilter.Show();
            buttonFilter.Show();
            buttonCloseFinter.Show();
            buttonShowFilter.Hide();
        }

        private void buttonCloseFinter_Click(object sender, EventArgs e) {
            checkBoxDateFilter.Hide();
            checkBoxFuturesFilter.Hide();
            dateTimePicker2.Hide();
            dateTimePicker3.Hide();
            comboBoxFuturesFilter.Hide();
            buttonFilter.Hide();
            buttonCloseFinter.Hide();
            buttonShowFilter.Show();
        }

        private void buttonFilter_Click(object sender, EventArgs e) {
            if (checkBoxDateFilter.Checked && checkBoxFuturesFilter.Checked) {
                depositNow.Text = db.AllFilters(dateTimePicker2.Value.ToShortDateString(), dateTimePicker3.Value.ToShortDateString(), comboBoxFuturesFilter.Text);
            } else if(checkBoxDateFilter.Checked) {
                depositNow.Text = db.DateFilters(dateTimePicker2.Value.ToShortDateString(), dateTimePicker3.Value.ToShortDateString());
                persentDeposite.Text = db.LoadPercentDeposit(float.Parse(db.LoadStartDeposit()), float.Parse(db.DateFilters(dateTimePicker2.Value.ToShortDateString(), dateTimePicker3.Value.ToShortDateString())));
            } else if (checkBoxFuturesFilter.Checked) {
                depositNow.Text = db.FuturesFilter(comboBoxFuturesFilter.Text) + " руб.";
                persentDeposite.Text = db.LoadPercentDeposit(float.Parse(db.LoadStartDeposit()), float.Parse(db.FuturesFilter(comboBoxFuturesFilter.Text)));
            } else {
                MessageBox.Show("Error! \n Select filtes");
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e) {
            if (dateTimePicker3.Value < dateTimePicker2.Value) {
                dateTimePicker3.Value = dateTimePicker2.Value;
            }
        }
    }
}
