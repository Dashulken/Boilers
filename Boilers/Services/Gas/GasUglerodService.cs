using Boilers.Models.GasRasch;

namespace Boilers.Services.Tverd
{
    public class GasUglerodService
    {
        public double CalcUglerod(GasUglerodRasch gasUglerodRasch, int kindToplivo)
        {
            double R;

            switch (kindToplivo)
            {
                case 0:
                    R = ConstantsGU.TvToplivo;
                    break;
                case 1:
                    R = ConstantsGU.Mazut;
                    break;
                default:
                    R = ConstantsGU.Gas;
                    break;
            }

            var cCO = gasUglerodRasch.Q3 * R * gasUglerodRasch.TeplSgor;

            return 0.001 * gasUglerodRasch.Rashod * cCO * (1 - gasUglerodRasch.Q4 / 100);
        }
    }
}
