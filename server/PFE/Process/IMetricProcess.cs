using Microsoft.EntityFrameworkCore;
using PFE.Data;
using PFE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Process
{
    public interface IMetricProcess
    {
        Task UpdateSummaryFeature();

        Task UpdateSummaryAquisition();


        Task RFD();

        Task RFM();
    }
}
