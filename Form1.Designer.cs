
namespace Finance {
    partial class MainForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.profitBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FuturesComboBox = new System.Windows.Forms.ComboBox();
            this.futuresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBFinanceDataSet = new Finance.DBFinanceDataSet();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.depositNow = new System.Windows.Forms.Label();
            this.persentDeposite = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AddProfitBtn = new System.Windows.Forms.Button();
            this.startDepositeBtn = new System.Windows.Forms.Button();
            this.Editbutton = new System.Windows.Forms.Button();
            this.Start_deposit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.futuresTableAdapter = new Finance.DBFinanceDataSetTableAdapters.FuturesTableAdapter();
            this.CloseEditDepositButton = new System.Windows.Forms.Button();
            this.CloseEditFuturesButton = new System.Windows.Forms.Button();
            this.Addutton = new System.Windows.Forms.Button();
            this.AddFuturesTextBox = new System.Windows.Forms.TextBox();
            this.DelButton = new System.Windows.Forms.Button();
            this.buttonEdidFutures = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonEditStartDeposit = new System.Windows.Forms.Button();
            this.textBoxEditStartDeposit = new System.Windows.Forms.TextBox();
            this.buttonShowFilter = new System.Windows.Forms.Button();
            this.buttonCloseFinter = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.comboBoxFuturesFilter = new System.Windows.Forms.ComboBox();
            this.checkBoxDateFilter = new System.Windows.Forms.CheckBox();
            this.checkBoxFuturesFilter = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.futuresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBFinanceDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(69, 140);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(66, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Заработок";
            // 
            // profitBox
            // 
            this.profitBox.Location = new System.Drawing.Point(69, 204);
            this.profitBox.Name = "profitBox";
            this.profitBox.Size = new System.Drawing.Size(100, 20);
            this.profitBox.TabIndex = 2;
            this.profitBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.profitBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(66, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата";
            // 
            // FuturesComboBox
            // 
            this.FuturesComboBox.DataSource = this.futuresBindingSource;
            this.FuturesComboBox.DisplayMember = "Name";
            this.FuturesComboBox.FormattingEnabled = true;
            this.FuturesComboBox.Location = new System.Drawing.Point(69, 272);
            this.FuturesComboBox.Name = "FuturesComboBox";
            this.FuturesComboBox.Size = new System.Drawing.Size(121, 21);
            this.FuturesComboBox.TabIndex = 3;
            this.FuturesComboBox.ValueMember = "id";
            // 
            // futuresBindingSource
            // 
            this.futuresBindingSource.DataMember = "Futures";
            this.futuresBindingSource.DataSource = this.dBFinanceDataSet;
            // 
            // dBFinanceDataSet
            // 
            this.dBFinanceDataSet.DataSetName = "DBFinanceDataSet";
            this.dBFinanceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(66, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Фьючерс";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(488, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Начальный депозит";
            // 
            // depositNow
            // 
            this.depositNow.AutoSize = true;
            this.depositNow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.depositNow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.depositNow.Location = new System.Drawing.Point(488, 211);
            this.depositNow.Name = "depositNow";
            this.depositNow.Size = new System.Drawing.Size(35, 13);
            this.depositNow.TabIndex = 1;
            this.depositNow.Text = "label1";
            // 
            // persentDeposite
            // 
            this.persentDeposite.AutoSize = true;
            this.persentDeposite.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.persentDeposite.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.persentDeposite.Location = new System.Drawing.Point(488, 241);
            this.persentDeposite.Name = "persentDeposite";
            this.persentDeposite.Size = new System.Drawing.Size(35, 13);
            this.persentDeposite.TabIndex = 1;
            this.persentDeposite.Text = "label1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(488, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "Что имеем";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(66, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 25);
            this.label8.TabIndex = 1;
            this.label8.Text = "Ввод данных ";
            // 
            // AddProfitBtn
            // 
            this.AddProfitBtn.Location = new System.Drawing.Point(69, 318);
            this.AddProfitBtn.Name = "AddProfitBtn";
            this.AddProfitBtn.Size = new System.Drawing.Size(121, 23);
            this.AddProfitBtn.TabIndex = 4;
            this.AddProfitBtn.Text = "Ввести данные";
            this.AddProfitBtn.UseVisualStyleBackColor = true;
            this.AddProfitBtn.Click += new System.EventHandler(this.AddProfitBtn_Click);
            // 
            // startDepositeBtn
            // 
            this.startDepositeBtn.Location = new System.Drawing.Point(637, 156);
            this.startDepositeBtn.Name = "startDepositeBtn";
            this.startDepositeBtn.Size = new System.Drawing.Size(75, 23);
            this.startDepositeBtn.TabIndex = 5;
            this.startDepositeBtn.Text = "Изменить";
            this.startDepositeBtn.UseVisualStyleBackColor = true;
            this.startDepositeBtn.Click += new System.EventHandler(this.startDepositeBtn_Click);
            // 
            // Editbutton
            // 
            this.Editbutton.Location = new System.Drawing.Point(316, 268);
            this.Editbutton.Name = "Editbutton";
            this.Editbutton.Size = new System.Drawing.Size(75, 23);
            this.Editbutton.TabIndex = 5;
            this.Editbutton.Text = "Изменить";
            this.Editbutton.UseVisualStyleBackColor = true;
            this.Editbutton.Click += new System.EventHandler(this.Editbutton_Click);
            // 
            // Start_deposit
            // 
            this.Start_deposit.AutoSize = true;
            this.Start_deposit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Start_deposit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Start_deposit.Location = new System.Drawing.Point(488, 140);
            this.Start_deposit.Name = "Start_deposit";
            this.Start_deposit.Size = new System.Drawing.Size(108, 13);
            this.Start_deposit.TabIndex = 1;
            this.Start_deposit.Text = "Начальный депозит";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(488, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Финанcы сейчс";
            // 
            // futuresTableAdapter
            // 
            this.futuresTableAdapter.ClearBeforeFill = true;
            // 
            // CloseEditDepositButton
            // 
            this.CloseEditDepositButton.Location = new System.Drawing.Point(601, 135);
            this.CloseEditDepositButton.Name = "CloseEditDepositButton";
            this.CloseEditDepositButton.Size = new System.Drawing.Size(19, 23);
            this.CloseEditDepositButton.TabIndex = 7;
            this.CloseEditDepositButton.Text = "<";
            this.CloseEditDepositButton.UseVisualStyleBackColor = true;
            this.CloseEditDepositButton.Click += new System.EventHandler(this.CloseEditDepositButton_Click);
            // 
            // CloseEditFuturesButton
            // 
            this.CloseEditFuturesButton.Location = new System.Drawing.Point(196, 271);
            this.CloseEditFuturesButton.Name = "CloseEditFuturesButton";
            this.CloseEditFuturesButton.Size = new System.Drawing.Size(19, 23);
            this.CloseEditFuturesButton.TabIndex = 7;
            this.CloseEditFuturesButton.Text = "<";
            this.CloseEditFuturesButton.UseVisualStyleBackColor = true;
            this.CloseEditFuturesButton.Click += new System.EventHandler(this.CloseEditFuturesButton_Click);
            // 
            // Addutton
            // 
            this.Addutton.Location = new System.Drawing.Point(316, 302);
            this.Addutton.Name = "Addutton";
            this.Addutton.Size = new System.Drawing.Size(75, 23);
            this.Addutton.TabIndex = 10;
            this.Addutton.Text = "Добавить";
            this.Addutton.UseVisualStyleBackColor = true;
            this.Addutton.Click += new System.EventHandler(this.Addutton_Click);
            // 
            // AddFuturesTextBox
            // 
            this.AddFuturesTextBox.Location = new System.Drawing.Point(221, 271);
            this.AddFuturesTextBox.Name = "AddFuturesTextBox";
            this.AddFuturesTextBox.Size = new System.Drawing.Size(75, 20);
            this.AddFuturesTextBox.TabIndex = 11;
            // 
            // DelButton
            // 
            this.DelButton.Location = new System.Drawing.Point(217, 302);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(79, 23);
            this.DelButton.TabIndex = 12;
            this.DelButton.Text = "Удалить";
            this.DelButton.UseVisualStyleBackColor = true;
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // buttonEdidFutures
            // 
            this.buttonEdidFutures.Location = new System.Drawing.Point(196, 271);
            this.buttonEdidFutures.Name = "buttonEdidFutures";
            this.buttonEdidFutures.Size = new System.Drawing.Size(19, 23);
            this.buttonEdidFutures.TabIndex = 7;
            this.buttonEdidFutures.Text = ">";
            this.buttonEdidFutures.UseVisualStyleBackColor = true;
            this.buttonEdidFutures.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(667, 12);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(71, 23);
            this.buttonUpdate.TabIndex = 7;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonEditStartDeposit
            // 
            this.buttonEditStartDeposit.Location = new System.Drawing.Point(601, 135);
            this.buttonEditStartDeposit.Name = "buttonEditStartDeposit";
            this.buttonEditStartDeposit.Size = new System.Drawing.Size(19, 23);
            this.buttonEditStartDeposit.TabIndex = 7;
            this.buttonEditStartDeposit.Text = ">";
            this.buttonEditStartDeposit.UseVisualStyleBackColor = true;
            this.buttonEditStartDeposit.Click += new System.EventHandler(this.buttonEditStartDeposit_Click);
            // 
            // textBoxEditStartDeposit
            // 
            this.textBoxEditStartDeposit.Location = new System.Drawing.Point(626, 123);
            this.textBoxEditStartDeposit.Name = "textBoxEditStartDeposit";
            this.textBoxEditStartDeposit.Size = new System.Drawing.Size(100, 20);
            this.textBoxEditStartDeposit.TabIndex = 13;
            // 
            // buttonShowFilter
            // 
            this.buttonShowFilter.Location = new System.Drawing.Point(582, 183);
            this.buttonShowFilter.Name = "buttonShowFilter";
            this.buttonShowFilter.Size = new System.Drawing.Size(19, 23);
            this.buttonShowFilter.TabIndex = 7;
            this.buttonShowFilter.Text = ">";
            this.buttonShowFilter.UseVisualStyleBackColor = true;
            this.buttonShowFilter.Click += new System.EventHandler(this.buttonShowFilter_Click);
            // 
            // buttonCloseFinter
            // 
            this.buttonCloseFinter.Location = new System.Drawing.Point(582, 183);
            this.buttonCloseFinter.Name = "buttonCloseFinter";
            this.buttonCloseFinter.Size = new System.Drawing.Size(19, 23);
            this.buttonCloseFinter.TabIndex = 7;
            this.buttonCloseFinter.Text = "<";
            this.buttonCloseFinter.UseVisualStyleBackColor = true;
            this.buttonCloseFinter.Click += new System.EventHandler(this.buttonCloseFinter_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(637, 185);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(138, 20);
            this.dateTimePicker2.TabIndex = 0;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(637, 211);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(138, 20);
            this.dateTimePicker3.TabIndex = 0;
            this.dateTimePicker3.ValueChanged += new System.EventHandler(this.dateTimePicker3_ValueChanged);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(658, 272);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(89, 23);
            this.buttonFilter.TabIndex = 14;
            this.buttonFilter.Text = "Фильтровать";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // comboBoxFuturesFilter
            // 
            this.comboBoxFuturesFilter.DataSource = this.futuresBindingSource;
            this.comboBoxFuturesFilter.DisplayMember = "Name";
            this.comboBoxFuturesFilter.FormattingEnabled = true;
            this.comboBoxFuturesFilter.Location = new System.Drawing.Point(637, 241);
            this.comboBoxFuturesFilter.Name = "comboBoxFuturesFilter";
            this.comboBoxFuturesFilter.Size = new System.Drawing.Size(138, 21);
            this.comboBoxFuturesFilter.TabIndex = 3;
            this.comboBoxFuturesFilter.ValueMember = "id";
            // 
            // checkBoxDateFilter
            // 
            this.checkBoxDateFilter.AutoSize = true;
            this.checkBoxDateFilter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBoxDateFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxDateFilter.Location = new System.Drawing.Point(607, 188);
            this.checkBoxDateFilter.Name = "checkBoxDateFilter";
            this.checkBoxDateFilter.Size = new System.Drawing.Size(25, 13);
            this.checkBoxDateFilter.TabIndex = 15;
            this.checkBoxDateFilter.UseVisualStyleBackColor = false;
            // 
            // checkBoxFuturesFilter
            // 
            this.checkBoxFuturesFilter.AutoSize = true;
            this.checkBoxFuturesFilter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBoxFuturesFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxFuturesFilter.Location = new System.Drawing.Point(607, 245);
            this.checkBoxFuturesFilter.Name = "checkBoxFuturesFilter";
            this.checkBoxFuturesFilter.Size = new System.Drawing.Size(25, 13);
            this.checkBoxFuturesFilter.TabIndex = 15;
            this.checkBoxFuturesFilter.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxFuturesFilter);
            this.Controls.Add(this.checkBoxDateFilter);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.textBoxEditStartDeposit);
            this.Controls.Add(this.DelButton);
            this.Controls.Add(this.AddFuturesTextBox);
            this.Controls.Add(this.Addutton);
            this.Controls.Add(this.buttonCloseFinter);
            this.Controls.Add(this.buttonShowFilter);
            this.Controls.Add(this.buttonEditStartDeposit);
            this.Controls.Add(this.buttonEdidFutures);
            this.Controls.Add(this.CloseEditFuturesButton);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.CloseEditDepositButton);
            this.Controls.Add(this.Editbutton);
            this.Controls.Add(this.startDepositeBtn);
            this.Controls.Add(this.AddProfitBtn);
            this.Controls.Add(this.comboBoxFuturesFilter);
            this.Controls.Add(this.FuturesComboBox);
            this.Controls.Add(this.profitBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.persentDeposite);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.depositNow);
            this.Controls.Add(this.Start_deposit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Финансы";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.futuresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBFinanceDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox profitBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FuturesComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label depositNow;
        private System.Windows.Forms.Label persentDeposite;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button AddProfitBtn;
        private System.Windows.Forms.Button startDepositeBtn;
        private System.Windows.Forms.Button Editbutton;
        private System.Windows.Forms.Label Start_deposit;
        private System.Windows.Forms.Label label5;
        private DBFinanceDataSet dBFinanceDataSet;
        private System.Windows.Forms.BindingSource futuresBindingSource;
        private DBFinanceDataSetTableAdapters.FuturesTableAdapter futuresTableAdapter;
        private System.Windows.Forms.Button CloseEditDepositButton;
        private System.Windows.Forms.Button CloseEditFuturesButton;
        private System.Windows.Forms.Button Addutton;
        private System.Windows.Forms.TextBox AddFuturesTextBox;
        private System.Windows.Forms.Button DelButton;
        private System.Windows.Forms.Button buttonEdidFutures;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonEditStartDeposit;
        private System.Windows.Forms.TextBox textBoxEditStartDeposit;
        private System.Windows.Forms.Button buttonShowFilter;
        private System.Windows.Forms.Button buttonCloseFinter;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.ComboBox comboBoxFuturesFilter;
        private System.Windows.Forms.CheckBox checkBoxDateFilter;
        private System.Windows.Forms.CheckBox checkBoxFuturesFilter;
    }
}

