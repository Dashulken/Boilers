using Boilers.Models.GasRasch;
using Boilers.Services.Gas;
using System;
using System.Windows.Forms;

namespace Boilers
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Unit1.SelectedIndex = 0;
            Unit2.SelectedIndex = 0;
            Unit3.SelectedIndex = 0;

            KindGor1.SelectedIndex = 0;
            KindKot1.SelectedIndex = 0;
            KindKot2.SelectedIndex = 0;

            Rezhim1.SelectedIndex = 0;
            Rezhim2.SelectedIndex = 0;

        }

        private void Clear1()
        {
            label33.Text = "-";
        }

        private void Clear2()
        {
            label5.Text = "-";
        }

        private void Clear3()
        {
            label18.Text = "-";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear1();
            var service = new GasAzotService();
            if (double.TryParse(Rashod1.Text, out double rashod1)
               && double.TryParse(TeplSgor1.Text, out double teplSgor1)
               && double.TryParse(TempAir1.Text, out double tempAir1)
               && double.TryParse(RecGas1.Text, out double recGas1)
               && double.TryParse(DolAir1.Text, out double dolAir1))
            {
                var gas = new GasAzotRasch
                {
                    Rashod = rashod1,
                    TeplSgor = teplSgor1,
                    TempAir = tempAir1,
                    RecGas = recGas1,
                    DolAir = dolAir1
                };
                if (KindKot1.SelectedIndex == 0)
                {
                    if (double.TryParse(FactPar1.Text, out double factPar1))
                    {
                        gas.FactPar = factPar1;
                    }
                }
                var result = service.PrirodGas(gas, Unit1.SelectedIndex, KindKot1.SelectedIndex, KindGor1.SelectedIndex,
                    Rezhim1.SelectedIndex);
                label33.Text = Math.Round(result, 4).ToString() + ' ' + Unit1.SelectedItem;
            }
            else
            {
                MessageBox.Show("Введите верное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void KindKot1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KindKot1.SelectedIndex == 1)
            {
                FactPar1.Enabled = false;
            }
            else
            {
                FactPar1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear2();
            var service = new GasAzotService();
            if (double.TryParse(Rashod2.Text, out double rashod2)
                && double.TryParse(TeplSgor2.Text, out double teplSgor2)
                && double.TryParse(TempAir2.Text, out double tempAir2)
                && double.TryParse(RecGas2.Text, out double recGas2)
                && double.TryParse(DolAir2.Text, out double dolAir2)
                && double.TryParse(Poteri2.Text, out double poteri2))
            {
                var gas = new GasAzotRasch
                {
                    Rashod = rashod2,
                    TeplSgor = teplSgor2,
                    TempAir = tempAir2,
                    RecGas = recGas2,
                    DolAir = dolAir2,
                    Poteri = poteri2
                };
                if (KindKot2.SelectedIndex == 0)
                {
                    if (double.TryParse(FactPar1.Text, out double factPar1))
                    {
                        gas.FactPar = factPar1;
                    }
                }

                var result = service.Mazut(gas, Unit2.SelectedIndex, KindKot2.SelectedIndex, Rezhim2.SelectedIndex);
                label5.Text = Math.Round(result, 4).ToString() + ' ' + Unit2.SelectedItem; ;
            }
            else
            {
                MessageBox.Show("Введите верное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void KindKot2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KindKot2.SelectedIndex == 1)
            {
                FactPar2.Enabled = false;
            }
            else
            {
                FactPar2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Clear3();
            var service = new GasAzotService();
            if (double.TryParse(Rashod3.Text, out double rashod3)
                && double.TryParse(TeplSgor3.Text, out double teplSgor3)
                && double.TryParse(GranUg3.Text, out double granUg3)
                && double.TryParse(ZercGor3.Text, out double zercGor3)
                && double.TryParse(Poteri3.Text, out double poteri3)
                && double.TryParse(RecGas3.Text, out double recGas3)
                && double.TryParse(FactTep3.Text, out double factTep3))
            {
                var gas = new GasAzotRasch
                {
                    Rashod = rashod3,
                    TeplSgor = teplSgor3,
                    GranUg = granUg3,
                    ZercGor = zercGor3,
                    FactTep = factTep3,
                    Poteri = poteri3,
                    RecGas = recGas3
                };
                var result = service.TverdoeToplivo(gas, Unit3.SelectedIndex);
                label18.Text = Math.Round(result, 4).ToString() + ' ' + Unit3.SelectedItem; 
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
                label35.Text = "тыс. нм³/год";
            else label35.Text = "нм³/с";
        }

        private void Unit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Unit2.SelectedIndex == 1)
                label41.Text = "т/год";
            else label41.Text = "кг/с";
        }

        private void Unit3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Unit3.SelectedIndex == 1)
                label49.Text = "т/год";
            else label49.Text = "кг/с";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Unit1.SelectedIndex = 1;
            Rashod1.Text = "40";
            TeplSgor1.Text = "34,6";
            KindKot1.SelectedIndex = 0;
            FactPar1.Text = "420";
            KindGor1.SelectedIndex = 0;
            TempAir1.Text = "420";
            Rezhim1.SelectedIndex = 1;
            RecGas1.Text = "0,25";
            DolAir1.Text = "0,67";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Unit2.SelectedIndex = 1;
            KindKot1.SelectedIndex = 0;
            Rezhim2.SelectedIndex = 1;
            Poteri2.Text = "11";
            Rashod2.Text = "40";
            TeplSgor2.Text = "42";
            FactPar2.Text = "420";
            TempAir2.Text = "420";
            RecGas2.Text = "0,25";
            DolAir2.Text = "0,67";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Unit3.SelectedIndex = 1;
            TeplSgor3.Text = "47";
            Poteri3.Text = "11";
            Rashod3.Text = "52";
            GranUg3.Text = "25";
            ZercGor3.Text = "1,16";
            FactTep3.Text = "100";
            RecGas3.Text = "0,25";
        }
    }
    
}
