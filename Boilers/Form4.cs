using Boilers.Models.Tverd;
using Boilers.Services.Tverd;
using System;
using System.Windows.Forms;

namespace Boilers
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            KindToplivo.SelectedIndex = 0;
            ChooseRealV.SelectedIndex = 0;
        }

        private void Clear()
        {
            label33.Text = "-";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
            if (double.TryParse(Concentration.Text, out double concentration))
            {
                if (ChooseRealV.SelectedIndex == 0)
                {
                    if (double.TryParse(RealV.Text, out double realV))
                    {
                        label33.Text = Math.Round(concentration * realV, 4).ToString();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Введите верное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                var tverdInstrumental = new TverdInstrumental();
                var service = new TverdInstrumentalService();

                if (double.TryParse(Rashod.Text, out double rashod)
                    && double.TryParse(CoeffAir.Text, out double coeffAir)
                    && double.TryParse(TempGas.Text, out double tempGas)
                    && double.TryParse(TeplSgor.Text, out double teplSgor))
                {
                    tverdInstrumental.Concentration = concentration;
                    tverdInstrumental.Rashod = rashod;
                    tverdInstrumental.CoeffAir = coeffAir;
                    tverdInstrumental.TempGas = tempGas;
                    tverdInstrumental.TeplSgor = teplSgor;

                    var result = service.CalcM(tverdInstrumental, KindToplivo.SelectedIndex);
                    label33.Text = Math.Round(result, 4).ToString() + " г/с";
                }
                else
                {
                    MessageBox.Show("Введите верное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Введите верное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ChooseRealV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChooseRealV.SelectedIndex==0)
            {
                RealV.Enabled = true;
                Rashod.Enabled = false;
                CoeffAir.Enabled = false;
                TempGas.Enabled = false;
                TeplSgor.Enabled = false;
                KindToplivo.Enabled=false;
            }
            else
            {
                RealV.Enabled = false;
                Rashod.Enabled = true;
                CoeffAir.Enabled = true;
                TempGas.Enabled = true;
                TeplSgor.Enabled = true;
                KindToplivo.Enabled = true;
            }
        }
    }
}
