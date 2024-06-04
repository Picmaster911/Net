using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHealth.Model
{
    public class CreateCurs
    {
        private IApplicationDbContext _dbContext;
        public CreateCurs(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private List<Notification> _notifications = new();
        public List<Notification> CreatorCurs(DateTime StartDate, DateTime EndDate, int ItemsInDay, int InAday, string Message)
        {
            if (EndDate > StartDate)
            {
                var CountDay = EndDate - StartDate;
                int AllMinutes = (int)CountDay.TotalMinutes;
                var correctedTime = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 8, 0, 0);
                do
                {
                    for (int t = 0; t < ItemsInDay; t++)
                    {
                        var valIncrMinut = 16 * 60 / ItemsInDay; // 8.00 - 22.00

                        _notifications.Add(new Notification()
                        {
                            DateTimeShowMassege = correctedTime,
                            Message = Message,
                            Accept = false,
                        });
                        correctedTime = correctedTime.AddMinutes(valIncrMinut);
                    }

                    correctedTime = new DateTime(correctedTime.Year, correctedTime.Month, correctedTime.Day + InAday, 8, 0, 0);
                }
                while (correctedTime < EndDate);
            }
            return _notifications;
        }
    }
}
