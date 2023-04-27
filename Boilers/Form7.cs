using Boilers.Models.GasRasch;
using Boilers.Services.Tverd;
using System;
using System.Windows.Forms;

namespace Boilers
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            kindToplivo.SelectedIndex = 0;
            Unit1.SelectedIndex = 0;
        }

        private void Clear()
        {
            label33.Text = "-";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
            var gasUglerodRasch = new GasUglerodRasch();
            var service = new GasUglerodService();

            if (double.TryParse(Rashod.Text, out double rashod)
                && double.TryParse(TeplSgor.Text, out double teplSgor)
                && double.TryParse(Q3.Text, out double q3)
                && double.TryParse(Q4.Text, out double q4))
            {
                gasUglerodRasch.Rashod = rashod;
                gasUglerodRasch.TeplSgor = teplSgor;
                gasUglerodRasch.Q3 = q3;
                gasUglerodRasch.Q4 = q4;
                var result=service.CalcUglerod(gasUglerodRasch, kindToplivo.SelectedIndex);
                label33.Text = Math.Round(result, 4).ToString() + ' ' + Unit1.SelectedItem; 
            }
            else
            {
                MessageBox.Show("Введите верное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Unit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Unit1.SelectedIndex == 1)
                label35.Text = "т/год";
            else label35.Text = "г/с";
        }
    }
}
