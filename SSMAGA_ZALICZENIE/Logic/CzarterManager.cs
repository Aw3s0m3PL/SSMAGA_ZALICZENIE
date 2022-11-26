using SSMAGA_ZALICZENIE.Models;
using SSMAGA_ZALICZENIE.Contexts;
namespace SSMAGA_ZALICZENIE.Logic
{
    public class CzarterManager
    {
        public List<OfertaModel> PobierzJednostki()
        {
            using (var context = new CzarterContext())
            {
                var jednostki = context.Oferta.ToList<OfertaModel>();
                return jednostki;
            }
        }

        public CzarterManager dodajJednostke(OfertaModel ofertaModel)
        {
            using (var context = new CzarterContext())
            {
                context.Add(ofertaModel);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    ofertaModel.ID = 0;
                    context.Add(ofertaModel);
                    context.SaveChanges();
                }
            }
            return this;
        }

    }
}
