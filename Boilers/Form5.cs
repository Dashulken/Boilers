using Boilers.Models.Tverd;
using Boilers.Services.Tverd;
using System;
using System.Windows.Forms;

namespace Boilers
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Unit.SelectedIndex = 0;
            KindGor.SelectedIndex = 0;

        }

        private void Clear()
        {
            label33.Text = "-";
            label9.Text = "-";
            label12.Text = "-";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
            if (double.TryParse(Rashod.Text, out double rashod)
                && double.TryParse(Zola.Text, out double zola)
                && double.TryParse(DolZola.Text, out double dolZola)
                && double.TryParse(DolTv.Text, out double dolTv))
            {
                var tverdRasch = new TverdRasch();
                var service = new TverdRaschService();
                double M;
                double M1;
                double M2;
                tverdRasch.Rashod = rashod;
                tverdRasch.Zola = zola;
                tverdRasch.DolZola = dolZola;
                tverdRasch.DolTv = dolTv;
                if (KindGor.SelectedIndex == 0)
                {
                    if (double.TryParse(Gor.Text, out double gor))
                    {
                        tverdRasch.Gor = gor;
                        M = service.CalcM(tverdRasch, KindGor.SelectedIndex);
                        M1 = service.CalcM1(tverdRasch);
                        M2 = M - M1;
                        label33.Text = Math.Round(M, 4).ToString();
                        label9.Text = Math.Round(M1, 4).ToString();
                        label12.Text = Math.Round(M2, 4).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Введите верное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (double.TryParse(Poteri.Text, out double poteri)
                        && double.TryParse(TeplSgor.Text, out double teplSgor))
                    {
                        tverdRasch.Poteri = poteri;
                        tverdRasch.TeplSgor = teplSgor;
                        M = service.CalcM(tverdRasch, KindGor.SelectedIndex);
                        M1 = service.CalcM1(tverdRasch);
                        M2 = M - M1;
                        label33.Text = Math.Round(M, 4).ToString() + ' ' + Unit.SelectedItem; 
                        label9.Text = Math.Round(M1, 4).ToString() + ' ' + Unit.SelectedItem; 
                        label12.Text = Math.Round(M2, 4).ToString() + ' ' + Unit.SelectedItem; 
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
        }

        private void KindGor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KindGor.SelectedIndex == 0)
            {
                Gor.Enabled = true;
                Poteri.Enabled = false;
                TeplSgor.Enabled = false;
            }
            else
            {
                Gor.Enabled = false;
                Poteri.Enabled = true;
                TeplSgor.Enabled = true;
            }
        }

        private void Unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Unit.SelectedIndex == 1)
                label35.Text = "т/год";
            else label35.Text = "г/с";
        }
    }
}
