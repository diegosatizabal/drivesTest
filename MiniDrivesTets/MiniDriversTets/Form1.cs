using DiskManager.DrivesCalculation;
using DiskManager.InputValidation;
using System;
using System.Windows.Forms;

namespace MiniDriversTets
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCompute_Click(object sender, EventArgs e)
        {
            IDataValidator DV = new DataValidator();
            IDiskSpace DS = new DiskSpace();

            if (!DV.validateInputData(txtUsed.Text, txtTotal.Text))
            {
                txtResult.Text = DV.errorDescription;
                return;
            }

            int minimal = DS.minDrives(DV.used, DV.total);

            if (minimal < 0)
            {
                txtResult.Text = "Invalid parameters to calculate minDrives";
                return;
            }

            txtResult.Text = $"Total drives: {DV.used.Length}{Environment.NewLine}";
            txtResult.Text += $"Total disk space: {DS.TotalAvailiableSpace}{Environment.NewLine}";
            txtResult.Text += $"Total used space: {DS.TotalUsedSpace}{Environment.NewLine}";
            txtResult.Text += $"== MINIMUM DRIVES REQUIRED: {minimal} ==";
        }
    }
}
