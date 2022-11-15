using ApiSclad.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiSclad.Controllers
{
    [Route("Sclad/[controller]")]
    [ApiController]
    public class ScladApiController
    {
        private static readonly IList<sclad> scladapi = new List<sclad>();
        [HttpGet]
        public IEnumerable<sclad> Get()
        {
           
            return scladapi;
        }
        [HttpGet("statistic")]
        public ScaldStaticModel GetStatistic()
        {
            var result = new ScaldStaticModel()
            {
                Count = scladapi.Count,
                PriceWithNDS = Convert.ToDecimal(scladapi.Sum(x => x.fulprice + (x.fulprice * 0.2))),
                PriceWithoutNDS = Convert.ToDecimal(scladapi.Sum(x => x.fulprice)),
            };
            return result;
        }
        [HttpPost]
        public sclad Add(Scladd models)
        {
            var scl = new sclad
            {
              Id=Guid.NewGuid(),
             name = models.name,
            raz = models.raz,
            mater = models.mater,
            kol = models.kol,
            min = models.min,
            price = models.price,
            fulprice = models.kol * models.price
        };
            scladapi.Add(scl);
            return scl;
        }

        [HttpPut("{id:guid}")]
        public sclad Update([FromRoute] Guid id, [FromBody] Scladd models)
        {

            var Scld = scladapi.FirstOrDefault(x => x.Id == id);
            if (Scld != null)
            {
                Scld.name = models.name;
                Scld.raz = models.raz;
                Scld.mater = models.mater;
                Scld.kol = models.kol;
                Scld.min = models.min;
                Scld.price = models.price;
                Scld.fulprice = models.kol*models.price;
            }
            return Scld;
        }

        [HttpDelete("{id:guid}")]
        public bool Remove(Guid id)
        {
            var deletSclad = scladapi.FirstOrDefault(x => x.Id == id);
            if (deletSclad != null)
            {
                return scladapi.Remove(deletSclad);
            }
            return false;
        }
    }
}
