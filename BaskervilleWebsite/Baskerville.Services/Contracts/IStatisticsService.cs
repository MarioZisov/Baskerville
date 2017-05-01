namespace Baskerville.Services.Contracts
{
    using Models.ViewModels;
    using System.Collections.Generic;

    public interface IStatisticsService
    {
        IEnumerable<BarChartViewModel> GetBarChartData(int year);

        StatisticsViewModel GetStatistics();
    }
}
