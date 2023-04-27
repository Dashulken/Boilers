using Boilers.Models.Tverd;

namespace Boilers.Services.Tverd
{
    public class TverdRaschService
    {
        public double CalcM(TverdRasch tverdRasch, int kindGor)
        {
            if (kindGor == 0)
            {
                return tverdRasch.Rashod * tverdRasch.Zola / (100 - tverdRasch.Gor) * tverdRasch.DolZola
                    * (1 - tverdRasch.DolTv);
            }
            else
            {
                return 0.01 * tverdRasch.Rashod * (tverdRasch.DolZola * tverdRasch.Zola
                    + tverdRasch.Poteri * tverdRasch.TeplSgor / 32.68) * (1 - tverdRasch.DolTv);
            }
        }
        public double CalcM1(TverdRasch tverdRasch)
        {
            return 0.01 * tverdRasch.Rashod * tverdRasch.DolZola * tverdRasch.Zola * (1 - tverdRasch.DolTv);
        }
    }
}
