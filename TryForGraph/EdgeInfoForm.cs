using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryForGraph
{
    public partial class EdgeInfoForm : Form
    {
        public int EdgeLevel { get; private set; }
        public bool IsDirected { get; private set; }

        public EdgeInfoForm()
        {
            InitializeComponent();
        }
        private void btnOK_Click_1(object sender, EventArgs e)
        {
            if (int.TryParse(txtLevel.Text, out int level))
            {
                EdgeLevel = level;
                IsDirected = chkDirected.Checked;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Введите корректное число для уровня ребра.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
