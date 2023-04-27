using Boilers.Models.GasInstrumentals;

namespace Boilers.Services.Gas
{
    internal class GasInstrumentalService
    {
        public GasInstrumental GasInstrumental { get; set; }
        public double CalcConcentration(Concentration concentration, int choiceСoncentration)
        {
            concentration.Alf = 21 / (21 - concentration.Air);
            if (choiceСoncentration == 0)
            {
                GasInstrumental.Concentration = concentration.CIzmer * concentration.Alf / concentration.AlfNull;
                return GasInstrumental.Concentration;
            }
            GasInstrumental.Concentration = concentration.IIzmer * concentration.UdMass * concentration.Alf / concentration.AlfNull;
            return GasInstrumental.Concentration;
        }

        public double CalcVolume(Volume volume, int toplivo)
        {
            if (toplivo == 0)
                volume.KToplivo = ConstantsGI.KGas;
            else if (toplivo == 1)
                volume.KToplivo = ConstantsGI.KMazut;
            else if (toplivo == 2)
                volume.KToplivo = ConstantsGI.KKamUgl;
            else if (toplivo == 3)
                volume.KToplivo = ConstantsGI.KBurUgl;
            GasInstrumental.Volume = volume.KToplivo * volume.TeplSgor;
            return GasInstrumental.Volume;
        }

        public double CalcExpenditure(Expenditure expenditure)
        {
            GasInstrumental.Expenditure = (1 - expenditure.Poteri / 100) * expenditure.Rashod;
            return GasInstrumental.Expenditure;
        }

        public double CalcMGasInstrumental(int unit)
        {
            if (unit == 0)
            {
                GasInstrumental.MGasInstrumental = GasInstrumental.Concentration * GasInstrumental.Volume * GasInstrumental.Expenditure * ConstantsGI.KPereschGr;
                return GasInstrumental.MGasInstrumental;
            }
            GasInstrumental.MGasInstrumental = GasInstrumental.Concentration * GasInstrumental.Volume * GasInstrumental.Expenditure * ConstantsGI.KPereschTon;
            return GasInstrumental.MGasInstrumental;
        }

    }

}
