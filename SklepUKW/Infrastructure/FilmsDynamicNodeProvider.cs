using MvcSiteMapProvider;
using SklepUKW.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepUKW.Infrastructure
{
    public class FilmsDynamicNodeProvider : DynamicNodeProviderBase
    {
        FilmsContext db = new FilmsContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var filmsDN = new List<DynamicNode>();

            foreach (var film in db.Films)
            {
                DynamicNode dn = new DynamicNode()
                {
                    Title = film.Title,
                    Key = "Film_" + film.FilmId,
                    ParentKey = "Category_" + film.CategoryId
                };
                dn.RouteValues.Add("id", film.FilmId);

                filmsDN.Add(dn);
            }

            return filmsDN;
        }
    }
}