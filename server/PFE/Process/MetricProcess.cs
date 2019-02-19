using Microsoft.EntityFrameworkCore;
using MVC5App.Models;
using PFE.Data;
using PFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Process
{
    public class MetricProcess : IMetricProcess
    {
        private readonly ApplicationDbContext _context;

        public MetricProcess(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task UpdateSummaryFeature()
        {
            //Get last Summary Feature Update
            var lastFeatureUpdate = await _context.SummaryFeature.OrderByDescending(x => x.LastFeatureSeenDate).FirstOrDefaultAsync();
            var lastFeatureUpdateDate = new DateTime();

            //Get last Summary Feature Update Date
            if (lastFeatureUpdate != null)
            {
                lastFeatureUpdateDate = lastFeatureUpdate.LastFeatureSeenDate;
            }

            //Get all Metric Feature after last Summary Feature Update
            var listMetricsFeature = await _context.MetricFeature.Where(x => x.Date > lastFeatureUpdateDate).Include(x => x.Feature).Include(x => x.User).ToListAsync();

            //For each new MetricsFeature
            foreach (var feature in listMetricsFeature)
            {

                //Find if the user had de same feature already in SummaryFeature
                var summaryfeatureForUser = await _context.SummaryFeature.Where(x => x.User == feature.User && x.FeatureId == feature.FeatureId)
                    .FirstOrDefaultAsync();

                //If not create one
                if (summaryfeatureForUser == null)
                {
                    var newSummaryFeature = new SummaryFeature
                    {
                        User = feature.User,
                        FeatureId = feature.FeatureId,
                        Feature = feature.Feature,
                        AverageDuration = feature.Duration,
                        LastFeatureSeenDate = feature.Date,
                        SumOfFeatureSeen = 1
                    };

                    await _context.SummaryFeature.AddAsync(newSummaryFeature);
                    await _context.SaveChangesAsync();

                    //If yes update it
                }
                else
                {
                    summaryfeatureForUser.AverageDuration = ((summaryfeatureForUser.AverageDuration * summaryfeatureForUser.SumOfFeatureSeen) + feature.Duration) / (summaryfeatureForUser.SumOfFeatureSeen + 1);
                    summaryfeatureForUser.SumOfFeatureSeen++;

                    if (feature.Date > summaryfeatureForUser.LastFeatureSeenDate)
                        summaryfeatureForUser.LastFeatureSeenDate = feature.Date;

                    _context.SummaryFeature.Update(summaryfeatureForUser);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateSummaryAquisition()
        {
            //Get last Summary Aquisition Update
            var lastAcquisitionUpdate = await _context.SummaryAcquisitions.OrderByDescending(x => x.LastPurchaseDate).FirstOrDefaultAsync();
            var lastAcquisitionUpdateDate = new DateTime();

            //Get last Summary Aquisition Update Date
            if (lastAcquisitionUpdate != null)
            {
                lastAcquisitionUpdateDate = lastAcquisitionUpdate.LastPurchaseDate;
            }

            //Get all Metric Feature after last Summary Aquisition Update
            var listMetricsAquisition = await _context.PdfAcquisition.Where(x => x.AcquisitionDate > lastAcquisitionUpdateDate).Include(x => x.User).ToListAsync();

            //For each new MetricsFeature
            foreach (var aquisition in listMetricsAquisition)
            {

                //Find if the user had de same feature already in SummaryFeature
                var summaryAquisitionForUser = await _context.SummaryAcquisitions.Where(x => x.User == aquisition.User)
                    .FirstOrDefaultAsync();

                //If not create one
                if (summaryAquisitionForUser == null)
                {
                    var newSummaryAquisition = new SummaryAcquisition
                    {
                        User = aquisition.User,
                        FirstPurchaseDate = aquisition.AcquisitionDate,
                        LastPurchaseDate = aquisition.AcquisitionDate,
                        MoneterySpend = (float)aquisition.Price,
                        FrequencyPurchase = 1, 
                        SumAquisition = 1
                    };

                    await _context.SummaryAcquisitions.AddAsync(newSummaryAquisition);
                    await _context.SaveChangesAsync();

                    //If yes update it
                }
                else
                {
                    summaryAquisitionForUser.MoneterySpend += (float)aquisition.Price;
                    summaryAquisitionForUser.SumAquisition += 1;

                    if (aquisition.AcquisitionDate > summaryAquisitionForUser.LastPurchaseDate)
                            summaryAquisitionForUser.LastPurchaseDate = aquisition.AcquisitionDate;

                    
                    summaryAquisitionForUser.FrequencyPurchase = (float)summaryAquisitionForUser.SumAquisition / (float)(((summaryAquisitionForUser.LastPurchaseDate.Year - summaryAquisitionForUser.FirstPurchaseDate.Year) * 12) + summaryAquisitionForUser.LastPurchaseDate.Month - summaryAquisitionForUser.FirstPurchaseDate.Month + 1);
                    


                    _context.SummaryAcquisitions.Update(summaryAquisitionForUser);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task RFD()
        {
            const int NUMBERINTERVAL = 5;

            var validIfExist = _context.SummaryFeature.Any();
            //Get last Summary Feature Update Date
            if (validIfExist)
            {
                //Get first and last Date, SumOfFeatureSeen and AverageDuration
                var lastDate = _context.SummaryFeature.OrderByDescending(x => x.LastFeatureSeenDate).FirstOrDefault().LastFeatureSeenDate;
                var firstDate = _context.SummaryFeature.OrderByDescending(x => x.LastFeatureSeenDate).LastOrDefault().LastFeatureSeenDate;

                var sumOfFeatureSeenMax = _context.SummaryFeature.OrderByDescending(x => x.SumOfFeatureSeen).FirstOrDefault().SumOfFeatureSeen;
                var sumOfFeatureSeenMin = _context.SummaryFeature.OrderByDescending(x => x.SumOfFeatureSeen).LastOrDefault().SumOfFeatureSeen;

                var averageDurationMax = _context.SummaryFeature.OrderByDescending(x => x.AverageDuration).FirstOrDefault().AverageDuration;
                var averageDurationMin = _context.SummaryFeature.OrderByDescending(x => x.AverageDuration).LastOrDefault().AverageDuration;



                //Get interval for each dimensions
                var dateInterval = DateInterval(firstDate, lastDate, NUMBERINTERVAL);
                var sumOfFeatureSeenInterval = FloatInterval(sumOfFeatureSeenMin, sumOfFeatureSeenMax, NUMBERINTERVAL);
                var averageDurationInterval = FloatInterval(averageDurationMin, averageDurationMax, NUMBERINTERVAL);


                var allSummaryFeature = _context.SummaryFeature.ToList();

                //Update Dimension for each 3 dimensions
                foreach (var summaryFeature in allSummaryFeature)
                {
                    for (int i = 0; i < NUMBERINTERVAL; i++)
                    {
                        if (summaryFeature.AverageDuration >= averageDurationInterval[i] && summaryFeature.AverageDuration <= averageDurationInterval[i + 1])
                            summaryFeature.Duration = i + 1;

                        if (summaryFeature.LastFeatureSeenDate >= dateInterval[i] && summaryFeature.LastFeatureSeenDate <= dateInterval[i + 1])
                            summaryFeature.Recency = i + 1;

                        if (summaryFeature.SumOfFeatureSeen >= sumOfFeatureSeenInterval[i] && summaryFeature.SumOfFeatureSeen <= sumOfFeatureSeenInterval[i + 1])
                            summaryFeature.Frequency = i + 1;
                    }

                    _context.SummaryFeature.Update(summaryFeature);
                }

                await _context.SaveChangesAsync();
            }
        }

        public async Task RFM()
        {
            const int NUMBERINTERVAL = 5;

            var validIfExist = _context.SummaryAcquisitions.Any();
            //Get last Summary Feature Update Date
            if (validIfExist)
            {
                //Get first and last Date, SumOfFeatureSeen and AverageDuration
                var lastDate = _context.SummaryAcquisitions.OrderByDescending(x => x.LastPurchaseDate).FirstOrDefault().LastPurchaseDate;
                var firstDate = _context.SummaryAcquisitions.OrderByDescending(x => x.LastPurchaseDate).LastOrDefault().LastPurchaseDate;

                var frequencyPurchaseMax = _context.SummaryAcquisitions.OrderByDescending(x => x.FrequencyPurchase).FirstOrDefault().FrequencyPurchase;
                var frequencyPurchaseMin = _context.SummaryAcquisitions.OrderByDescending(x => x.FrequencyPurchase).LastOrDefault().FrequencyPurchase;

                var moneterySpendMax = _context.SummaryAcquisitions.OrderByDescending(x => x.MoneterySpend).FirstOrDefault().MoneterySpend;
                var moneterySpendMin = _context.SummaryAcquisitions.OrderByDescending(x => x.MoneterySpend).LastOrDefault().MoneterySpend;


                //Get interval for each dimensions
                var dateInterval = DateInterval(firstDate, lastDate, NUMBERINTERVAL);
                var frequencyPurchaseInterval = FloatInterval(frequencyPurchaseMin, frequencyPurchaseMax, NUMBERINTERVAL);
                var moneterySpendInterval = FloatInterval(moneterySpendMin, moneterySpendMax, NUMBERINTERVAL);

                var allSummaryAcquisitions = _context.SummaryAcquisitions.Include(x=>x.User).ToList();


                //Update Dimension for each 3 dimensions
                foreach (var summaryAcquisition in allSummaryAcquisitions)
                {
                    for (int i = 0; i < NUMBERINTERVAL; i++)
                    {
                        if (summaryAcquisition.MoneterySpend >= moneterySpendInterval[i] && summaryAcquisition.MoneterySpend <= moneterySpendInterval[i + 1])
                            summaryAcquisition.MoneteryValue = i + 1;

                        if (summaryAcquisition.LastPurchaseDate >= dateInterval[i] && summaryAcquisition.LastPurchaseDate <= dateInterval[i + 1])
                            summaryAcquisition.Recency = i + 1;

                        if (summaryAcquisition.FrequencyPurchase >= frequencyPurchaseInterval[i] && summaryAcquisition.FrequencyPurchase <= frequencyPurchaseInterval[i + 1])
                            summaryAcquisition.Frequency = i + 1;
                    }
                    summaryAcquisition.RFD = _context.SummaryFeature.Where(x => x.User == summaryAcquisition.User).ToList();
                    _context.SummaryAcquisitions.Update(summaryAcquisition);
                }

                await _context.SaveChangesAsync();

            }


            }

        private List<DateTime> DateInterval(DateTime firstDate, DateTime lastDate, int nbInterval)
        {
            TimeSpan diff = lastDate.Subtract(firstDate);
            TimeSpan intervalTime = diff / nbInterval;

            List<DateTime> listInterval = new List<DateTime>();

            for (int i = 0; i < nbInterval; i++)
            {
                listInterval.Add(firstDate + (i * intervalTime));
            }

            listInterval.Add(lastDate);
            return listInterval;
        }

        private List<float> FloatInterval(float min, float max, int nbInterval)
        {
            float diff = max - min;
            float intervalFloat = diff / nbInterval;

            List<float> listInterval = new List<float>();

            for (int i = 0; i < nbInterval; i++)
            {
                listInterval.Add(min + (i * intervalFloat));
            }

            listInterval.Add(max);
            return listInterval;
        }
    }
}
