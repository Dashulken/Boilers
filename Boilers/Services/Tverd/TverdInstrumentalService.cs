using Boilers.Models.Tverd;

namespace Boilers.Services.Tverd
{
    public class TverdInstrumentalService
    {
        public double CalcM(TverdInstrumental tverdInstrumental, int kindToplivo)
        {
            double k1;
            double k2;
            double k3;
            double k4;

            switch (kindToplivo)
            {
                case 0:
                    k1 = ConstantsTI.K1BurUg;
                    k2 = ConstantsTI.K2BurUg;
                    k3 = ConstantsTI.K3BurUg;
                    k4 = ConstantsTI.K4BurUg;
                    break;
                case 1:
                    k1 = ConstantsTI.K1KamUg;
                    k2 = ConstantsTI.K2KamUg;
                    k3 = ConstantsTI.K3KamUg;
                    k4 = ConstantsTI.K4KamUg;
                    break;
                case 2:
                    k1 = ConstantsTI.K1PrirUg;
                    k2 = ConstantsTI.K2PrirUg;
                    k3 = ConstantsTI.K3PrirUg;
                    k4 = ConstantsTI.K4PrirUg;
                    break;
                default:
                    k1 = ConstantsTI.K1Mazut;
                    k2 = ConstantsTI.K2Mazut;
                    k3 = ConstantsTI.K3Mazut;
                    k4 = ConstantsTI.K4Mazut;
                    break;
            }

            return tverdInstrumental.Rashod * (k1 + k2 * tverdInstrumental.TeplSgor +
                (tverdInstrumental.CoeffAir - 1) * (k3 + k4 * tverdInstrumental.TeplSgor))
                * (273 + tverdInstrumental.TempGas) / 273;
        }
    }
}
