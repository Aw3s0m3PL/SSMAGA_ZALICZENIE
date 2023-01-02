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

        public CzarterManager addItem(OfertaModel ofertaModel)
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

        public OfertaModel getItem(int id)
        {
            using (var context = new CzarterContext())
            {
                var item = context.Oferta.SingleOrDefault(x => x.ID == id);
                return item;
            }
        }

        public CzarterManager updateItem(OfertaModel ofertaModel)
        {
            using (var context = new CzarterContext())
            {
                context.Update(ofertaModel);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    context.Update(ofertaModel);
                    context.SaveChanges();
                }
            }
            return this;
        }

        public CzarterManager removeItem(int id)
        {
            using (var context = new CzarterContext())
            {
                var auto = context.Oferta.SingleOrDefault(x => x.ID == id);
                context.Remove(auto);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    context.Remove(auto);
                    context.SaveChanges();
                }
            }
            return this;
        }
    }
}
