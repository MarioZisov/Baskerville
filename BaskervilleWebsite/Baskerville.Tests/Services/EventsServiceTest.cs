namespace Baskerville.Tests.Services
{
    using AutoMapper;
    using Data.Contracts.Repository;
    using Data.Mocks;
    using Models.DataModels;
    using Models.ViewModels;
    using Baskerville.Services;
    using Baskerville.Services.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Net;

    [TestClass]
    public class EventsServiceTest
    {
        #region Valid Event property values
        private const int ValidId = 1;
        private const string ValidDescriptionBg = "Valid Desc Bg";
        private const string ValidDescriptionEn = "Valid Desc En";
        private const string ValidNameBg = "Name Bg";
        private const string ValidNameEn = "Name En";
        private const string ValidUrl = "www.valid-url.com";
        private readonly DateTime ValidDate = new DateTime(2012, 12, 12);
        #endregion

        private IEventsService service;

        [TestInitialize]
        public void InitializeTest()
        {
            this.InitializeMapping();

            IDbContext context = new FakeDbContext();
            this.service = new EventsService(context);
        }  

        [TestMethod]
        public void GetAll_EmptySet_CountShoudBeZero()
        {
            const int ExpectedCount = 0;

            var events = this.service.GetAllEvents();

            Assert.IsNotNull(events);
            Assert.AreEqual(ExpectedCount, events.Count());
        }

        [TestMethod]
        public void CreateEvent_EmptySet_CountShoudBeOne()
        {
            const int ExpectedCount = 1;

            this.CreateEvent();
            int totalEvents = this.GetTotalEventsCount();

            Assert.AreEqual(ExpectedCount, totalEvents);
        }

        [TestMethod]
        public void GetEmptyEvent_IdShouldBeZero()
        {
            const int ExpectedId = 0;

            var evnt = this.service.GetEmptyEvent();

            Assert.IsNotNull(evnt);
            Assert.AreEqual(ExpectedId, evnt.Id);
        }

        [TestMethod]
        public void GetById_InvalidId_ShouldReturnNull()
        {
            const int Id = 1;

            var evnt = this.service.GetEvent(Id);

            Assert.IsNull(evnt);
        }

        [TestMethod]
        public void GetById_ValidId_ShouldNotBeNull()
        {
            this.CreateEvent();

            var evnt = this.service.GetEvent(ValidId);

            Assert.IsNotNull(evnt);
        }

        [TestMethod]
        public void RemoveEvent_ValidId_CountShouldBeZero()
        {
            const int ExpectedCount = 0;

            this.CreateEvent();
            this.service.RemoveEvent(ValidId);
            int totalEvents = this.GetTotalEventsCount();

            Assert.AreEqual(ExpectedCount, totalEvents);
        }

        [TestMethod]
        public void UpdatePublicity_ValidId_ShouldReturnOk()
        {
            const HttpStatusCode ExpectedStatusCode = HttpStatusCode.OK;

            this.CreateEvent();
            var status = this.service.UpdatePublicity(ValidId);

            Assert.AreEqual(ExpectedStatusCode, status);
        }

        [TestMethod]
        public void UpdatePublicity_InvalidId_ShouldReturnNotFound()
        {
            const HttpStatusCode ExpectedStatusCode = HttpStatusCode.NotFound;

            var status = this.service.UpdatePublicity(ValidId);

            Assert.AreEqual(ExpectedStatusCode, status);
        }

        private void CreateEvent()
        {
            EventViewModel model = new EventViewModel
            {
                Id = ValidId,
                NameBg = ValidNameBg,
                NameEn = ValidNameEn,
                DescriptionBg = ValidDescriptionBg,
                DescriptionEn = ValidDescriptionEn,
                ImageUrl = ValidUrl,
                StartDate = ValidDate,
                IsPublic = true
            };

            this.service.CreateEvent(model);
        }

        private int GetTotalEventsCount()
        {
            return this.service.GetAllEvents().Count();
        }

        private void InitializeMapping()
        {
            Mapper.Initialize(p =>
            {
                p.CreateMap<Event, EventViewModel>();
                p.CreateMap<EventViewModel, Event>();
            });
        }
    }
}
