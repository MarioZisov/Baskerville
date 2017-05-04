namespace Baskerville.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts.Repository;
    using Models.DataModels;
    using Models.ViewModels;
    using AutoMapper;
    using System.Net;
    using Contracts;

    public class NewsService : Service, INewsService
    {
        public NewsService(IDbContext context)
            : base(context)
        {
        }

        public IEnumerable<NewsViewModel> GetAllNews()
        {
            var model = this.News
                .Find(n => !n.IsRemoved)
                .Select(Mapper.Map<News, NewsViewModel>)
                .ToList();

            return model;
        }

        public NewsViewModel GetNewsById(int id)
        {
            var newsFromDb = this.News.GetById(id);
            if (newsFromDb == null)
                return null;

            var model = Mapper.Map<News, NewsViewModel>(newsFromDb);
            return model;
        }

        public HttpStatusCode DeleteNewsById(int id)
        {
            var _news = this.News.GetById(id);

            if (_news == null)
                return HttpStatusCode.NotFound;

            _news.IsRemoved = true;
            this.News.Update(_news);

            return HttpStatusCode.OK;
        }

        public void UpdateNews(NewsViewModel model)
        {
            var newsFromDb = this.News.GetById(model.Id);

            Mapper.Map(model, newsFromDb);
            this.News.Update(newsFromDb);
        }

        public void CreateNews(NewsViewModel model)
        {
            News _news = Mapper.Map<NewsViewModel, News>(model);
            this.News.Insert(_news);
        }

        public HttpStatusCode UpdatePublicity(int id)
        {
            var _news = this.News.GetById(id);
            if (_news == null)
                return HttpStatusCode.NotFound;

            _news.IsPublic = !_news.IsPublic;
            this.News.Update(_news);

            return HttpStatusCode.OK;
        }
    }
}
