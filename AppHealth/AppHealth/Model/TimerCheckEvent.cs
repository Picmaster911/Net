using Contracts;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppHealth.Model
{
    internal class TimerCheckEvent
    {
        protected readonly SynchronizationContext syncContext = SynchronizationContext.Current;
        private Timer _timer;
        private List<Person> _allPersson;
        private readonly IServiceProvider _serviceProvider;

        public TimerCheckEvent(IServiceProvider serviceProvider )
        {
            _serviceProvider = serviceProvider;
            StartHourlyTask();
        }
        private void StartHourlyTask()
        {
           
            _timer = new Timer(TimerCallback, null, GetInitialDelay(), TimeSpan.FromMinutes(1));
        }
        private void TimerCallback(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
                var allPersons = dbContext.Persons
                                       .Include(p => p.Curses)
                                       .ThenInclude(c => c.Message)
                                       .ToList();
                allPersons
                    .ForEach(person => person.Curses
                    .ForEach(curs => curs.Message
                    .ForEach(message => 
                    { 
                        CheckDate(message,person);
                    })));
            }
        }
        private void CheckDate (Notification notification,Person person)
        {
            DateTime now = DateTime.Now;
            DateTime nextHowHour = now.Date.AddHours(now.Hour).AddMinutes(now.Minute + 55);
            DateTime PrevHowHour = now.Date.AddHours(now.Hour).AddMinutes(now.Minute - 55);
            if (notification.DateTimeShowMassege > PrevHowHour && notification.DateTimeShowMassege < nextHowHour)
            {
                ShowMessage(notification, person);
            }
        }

        private void ShowMessage (Notification notification, Person person)
        {
            syncContext.Post(new SendOrPostCallback(o =>
            {
                MessageBox.Show($"Уведомление: Клиент {person.Name} {person.SurName} {notification.Message}");
            }), null);

        }

        private TimeSpan GetInitialDelay()
        {
            DateTime now = DateTime.Now;
            DateTime nextHour = now.Date.AddHours(now.Hour).AddMinutes(now.Minute +2);
            var t = nextHour - now;
            return nextHour - now;
        }
    }
}
