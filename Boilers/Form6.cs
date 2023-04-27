using Boilers.Models.GasRasch;
using Boilers.Services.Gas;
using System;
using System.Windows.Forms;

namespace Boilers
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            Serovodorod.SelectedIndex = 0;
            Unit1.SelectedIndex = 0;
            KindToplivo.SelectedIndex = 0;
            Alkali.SelectedIndex = 0;
        }

        private void Clear()
        {
            label33.Text = "-";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
            var sulfurOxide = new SulfurOxide();
            var service = new GasSeraService();

            if (double.TryParse(Rashod.Text, out double rashod)
                && double.TryParse(Sera.Text, out double sera)
                && double.TryParse(TeplSgor.Text, out double teplSgor))
            {
                sulfurOxide.Rashod = rashod;
                sulfurOxide.Sera= sera;
                sulfurOxide.TeplSgor = teplSgor;
                if (Serovodorod.SelectedIndex==0)
                {
                    if (double.TryParse(SoderzhSerVod.Text,out double soderzhSerVod))
                    {
                        sulfurOxide.SoderzhSerVod = soderzhSerVod;
                    }
                    else
                    {
                        MessageBox.Show("Введите верное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            else
            {
                MessageBox.Show("Введите верное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = service.CalulateSulfureOxide(sulfurOxide,KindToplivo.SelectedIndex, Serovodorod.SelectedIndex, Alkali.SelectedIndex);
            label33.Text = Math.Round(result,4).ToString() + ' ' + Unit1.SelectedItem; 
        }

        private void Serovodorod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Serovodorod.SelectedIndex == 0)
            {
                SoderzhSerVod.Enabled = true;
            }
            else
            {
                SoderzhSerVod.Enabled = false;
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
