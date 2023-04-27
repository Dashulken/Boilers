using Boilers.Models.GasRasch;
using System;

namespace Boilers.Services.Gas
{
    public class GasAzotService
    {
        public double PrirodGas(GasAzotRasch gas, int Unit1, int KindKot1, int KindGor1, int Rezhim1)
        {
            if (KindKot1 == 0)
            {
                gas.UdVibros = 0.01 * Math.Sqrt(gas.FactPar) + 0.03;
            }
            else
            {
                gas.UdVibros = 0.0113 * Math.Sqrt(gas.Rashod * gas.TeplSgor) + 0.03;
            }

            gas.BetaT = 1 + 0.002 * (gas.TempAir - 30);
            gas.BetaR = 0.16 * Math.Sqrt(gas.RecGas);
            gas.BetaD = 0.022 * gas.DolAir;

            double unit;
            double kindGor;
            double rezhim;

            if (Unit1 == 0)
                unit = ConstantsGA.KPereschGr;
            else
                unit = ConstantsGA.KPereschTon;

            if (KindGor1 == 0)
                kindGor = ConstantsGA.BetaKNap1;
            else if (KindGor1 == 1)
                kindGor = ConstantsGA.BetaKInt1;
            else
                kindGor = ConstantsGA.BetaKDvu1;

            if (Rezhim1 == 1)
                rezhim = ConstantsGA.BetaAObsch1;
            else
                rezhim = ConstantsGA.BetaAKart1;

            return gas.Rashod * gas.TeplSgor * gas.UdVibros * kindGor * gas.BetaT * rezhim * (1 - gas.BetaR) * (1 - gas.BetaD) * unit;
        }

        public double Mazut(GasAzotRasch gas, int Unit2, int KindKot2, int Rezhim2)
        {
            if (KindKot2 == 0)
            {
                gas.UdVibros = 0.01 * Math.Sqrt(gas.FactPar) + 0.1;
            }
            else
            {
                gas.UdVibros = 0.0113 * Math.Sqrt(gas.Rashod * gas.TeplSgor) + 0.1;
            }

            gas.Rashod = gas.Rashod * (1 - gas.Poteri / 100);

            gas.BetaT = 1 + 0.002 * (gas.TempAir - 30);
            gas.BetaR = 0.17 * Math.Sqrt(gas.RecGas);
            gas.BetaD = 0.018 * gas.DolAir;

            double unit;
            double rezhim;

            if (Unit2 == 0)
                unit = ConstantsGA.KPereschGr;
            else
                unit = ConstantsGA.KPereschTon;


            if (Rezhim2 == 1)
                rezhim = ConstantsGA.BetaAObsch2;
            else
                rezhim = ConstantsGA.BetaAKart2;

            return gas.Rashod * gas.TeplSgor * gas.UdVibros * gas.BetaT * rezhim * (1 - gas.BetaR) * (1 - gas.BetaD) * unit;
        }

        public double TverdoeToplivo(GasAzotRasch gas, int Unit3)
        {
            gas.Rashod *= 1 - gas.Poteri / 100;

            var alfaT = 2.5;
            var Qr = gas.FactTep / gas.ZercGor;

            gas.UdVibros = 0.35 * Math.Pow(10, -3) * alfaT * (1 + 5.46 * (100 - gas.GranUg) / 100) * Math.Pow(gas.TeplSgor * Qr, 0.25);
            gas.BetaR = 1 - 0.075 * Math.Sqrt(gas.RecGas);

            double unit;
            if (Unit3 == 0)
                unit = ConstantsGA.KPereschGr;
            else
                unit = ConstantsGA.KPereschTon;

            return gas.Rashod * gas.TeplSgor * gas.UdVibros * gas.BetaR * unit;
        }
    }
}
