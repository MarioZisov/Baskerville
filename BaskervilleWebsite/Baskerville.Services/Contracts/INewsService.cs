using Baskerville.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Services.Contracts
{
    public interface INewsService
    {
        IEnumerable<NewsViewModel> GetAllNews();

        NewsViewModel GetNewsById(int id);

        void UpdateNews(NewsViewModel model);

        void CreateNews(NewsViewModel model);

        HttpStatusCode DeleteNewsById(int id);

        HttpStatusCode UpdatePublicity(int id);
    }
}
