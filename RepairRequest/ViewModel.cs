using Microsoft.EntityFrameworkCore;
using RepairRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairRequest
{
    class ViewModel
    {
        public static List<Request> GetRequestsForView()
        {
            using DbAppContext ctx = new();
            return ctx.Requests
                .Include(p => p.Client)
                .Include(p => p.Status)
                .Include(p => p.ProblemType)
                .ToList();
        }

        public static TimeSpan AverageCompletionTime()
        {
            using DbAppContext ctx = new();
            List<Request> completedRequests = ctx.Requests.Where(r => r.DateClosed != null).ToList();

            if (completedRequests.Count == 0)
            {
                return TimeSpan.Zero;
            }

            TimeSpan totalTime = TimeSpan.Zero;
            foreach (Request request in completedRequests)
            {
                // у request.DateClosed мы достаём Value, потому что DateClosed может содержать null
                totalTime += request.DateClosed.Value - request.DateAdded;
            }

            long averageTicks = totalTime.Ticks / completedRequests.Count;
            return TimeSpan.FromTicks(averageTicks);
        }
    }
}
