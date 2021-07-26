using Date;
using Models;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReservationService
    {
        private readonly SpeechCenterDbContext context;
        public ReservationService(SpeechCenterDbContext reservation)
        {
            context = reservation;
        }

        // Add a new reservation for services
        public async Task AddReservation(ReservationViewModel reservation)
        {
            var reservationDb = new Reservation();
            reservationDb.Id = Guid.NewGuid().ToString();
            reservationDb.FirstName = reservation.FirstName;
            reservationDb.LastName = reservation.LastName;
            reservationDb.Email = reservation.Email;
            reservationDb.City = reservation.City;
            reservationDb.KidName = reservation.KidName;
            reservationDb.KidYear = reservation.KidYear;
            reservationDb.ServiceName = reservation.ServiceName;
            reservationDb.Number = reservation.Number;
            reservationDb.Gender = reservation.Gender;
            reservationDb.Date = reservation.Date;
            reservationDb.Time = reservation.Time;

            if (reservation.FirstName != null)
            {
                context.Add(reservationDb);
                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Eror!");
            }
        }
    }
}
