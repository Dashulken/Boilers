using Boilers.Models.GasInstrumentals;
using Boilers.Services.Gas;
using System;
using System.Windows.Forms;

namespace Boilers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Unit.SelectedIndex = 1;
            ChoiceСoncentration.SelectedIndex = 0;
            ChooseGaz.SelectedIndex = 0;
            Toplivo.SelectedIndex = 0;
        }


        private void Unit_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (Unit.SelectedIndex == 1)
                label12.Text = "т/год";
            else label12.Text = "т/час";
        }

        private void ChoiceСoncentration_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ChoiceСoncentration.SelectedIndex == 0)
            {
                CIzmer.Enabled = true;
                IIzmer.Enabled = false;
                ChooseGaz.Enabled = false;
                UdMass.Enabled = false;
            }
            else
            {
                CIzmer.Enabled = false;
                IIzmer.Enabled = true;
                ChooseGaz.Enabled = true;
            }
        }

        private void ChooseGaz_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ChooseGaz.SelectedIndex == 3)
                UdMass.Enabled = true;
            else UdMass.Enabled = false;
        }

        private void Clear()
        {
            label13.Text = "-";
            label17.Text = "-";
            label21.Text = "-";
            label19.Text = "-";
        }

        private void button_Click(object sender, EventArgs e)
        {
            Clear();
            var service = new GasInstrumentalService();

            var concentration = new Concentration();

            var volume = new Volume();

            var expenditure = new Expenditure();

            service.GasInstrumental = new GasInstrumental();


            if (ChoiceСoncentration.SelectedIndex == 0)
            {
                if (double.TryParse(CIzmer.Text, out double cizmer) && double.TryParse(Air.Text, out double air))
                {
                    concentration.CIzmer = cizmer;
                    concentration.Air = air;
                }
                else
                {
                    MessageBox.Show("Введите верное значение", "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (double.TryParse(IIzmer.Text, out double izmer)
                && double.TryParse(Air.Text, out double air))
                {

                    concentration.IIzmer = izmer;
                    concentration.Air = air;
                    if (ChooseGaz.SelectedIndex == 0)
                    {
                        concentration.UdMass = ConstantsGI.UdMassAzot;
                    }
                    else if (ChooseGaz.SelectedIndex == 1)
                    {
                        concentration.UdMass = ConstantsGI.UdMassUglerod;
                    }
                    else if (ChooseGaz.SelectedIndex == 2)
                    {
                        concentration.UdMass = ConstantsGI.UdMassSera;
                    }
                    else
                    {
                        if (double.TryParse(UdMass.Text, out double udMass))
                        {
                            concentration.UdMass = udMass;
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
            var resultConcentration = service.CalcConcentration(concentration, ChoiceСoncentration.SelectedIndex);
            label13.Text = Math.Round(resultConcentration, 4).ToString() + " мг/нм³";


            if (double.TryParse(TeplSgor.Text, out double teplSgor))
            {
                volume.TeplSgor = teplSgor;
                var resultVolume = service.CalcVolume(volume, Toplivo.SelectedIndex);
                label17.Text = Math.Round(resultVolume, 4).ToString() + " нм³/кг";
            }
            else
            {
                MessageBox.Show("Введите верное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (double.TryParse(Poteri.Text, out double poteri) && double.TryParse(Rashod.Text, out double rashod))
            {
                expenditure.Poteri = poteri;
                expenditure.Rashod = rashod;
                var resultExpenditure = service.CalcExpenditure(expenditure);
                if (Unit.SelectedIndex == 0)
                    label19.Text = Math.Round(resultExpenditure, 4).ToString() + " т/ч";
                else
                    label19.Text = Math.Round(resultExpenditure, 4).ToString() + " т/год";
            }
            else
            {
                MessageBox.Show("Введите верное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = service.CalcMGasInstrumental(Unit.SelectedIndex);
            label21.Text = Math.Round(result, 4).ToString() + ' ' + Unit.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Unit.SelectedIndex = 1;
            ChoiceСoncentration.SelectedIndex = 1;
            ChooseGaz.SelectedIndex = 0;
            Toplivo.SelectedIndex = 2;
            IIzmer.Text = "25,5";
            Air.Text = "19,2";
            TeplSgor.Text = "29,33";
            Poteri.Text = "11";
            Rashod.Text = "67";
        }
    }
}
