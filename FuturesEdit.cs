using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finance {
    public partial class FuturesEdit : UserControl {

        DbConnector db;
        public FuturesEdit() {
            InitializeComponent();
            db = new DbConnector();
        }

        

        private void AddButton_Click(object sender, EventArgs e) {
            db.AddFutures(textBox1.Text);
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, EventArgs e) {
            db.DeleteFutures(comboBox1.Text);
            InitializeComponent();
        }
    }
}
