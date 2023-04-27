using Boilers.Models.GasRasch;
using System;

namespace Boilers.Services.Gas
{
    public class GasSeraService
    {
        public double CalulateSulfureOxide(SulfurOxide sulfurOxide, int kindToplivo, int serovodorod, int alkali)
        {
            double nu1;
            double nu2;
            double dS;

            if (serovodorod == 0)
            {
                sulfurOxide.Sera += 0.94 * sulfurOxide.SoderzhSerVod;
            }

            var sPr = sulfurOxide.Sera / sulfurOxide.TeplSgor;

            switch (kindToplivo)
            {
                case 0:
                    nu1 = ConstansGS.Torf;
                    break;
                case 1:
                    nu1 = ConstansGS.SlancEst;
                    break;
                case 2:
                    nu1 = ConstansGS.SlancDr;
                    break;
                case 3:
                    nu1 = ConstansGS.EkiUgol;
                    break;
                case 4:
                    nu1 = ConstansGS.BerezTv;
                    break;
                case 5:
                    nu1 = ConstansGS.BerezZhid;
                    break;
                case 6:
                    nu1 = ConstansGS.DrTv;
                    break;
                case 7:
                    nu1 = ConstansGS.DrZhid;
                    break;
                case 8:
                    nu1 = ConstansGS.UgolDr;
                    break;
                case 9:
                    nu1 = ConstansGS.Mazut;
                    break;
                default:
                    nu1 = ConstansGS.Gas;
                    break;
            }

            switch (alkali)
            {
                case 0:
                    nu2 = 0.24 * Math.Pow(sPr, -1.063);
                    break;
                case 1:
                    nu2 = 0.27 * Math.Pow(sPr, -0.85);
                    break;
                default:
                    nu2 = 1.42 * Math.Pow(sPr, -0.17);
                    break;
            }

            if (sPr > 0.15)
            {
                nu2 = 0.15;
            }

            return 0.02 * sulfurOxide.Rashod * sulfurOxide.Sera * (1 - nu1) * (1 - nu2);
        }
    }
}
