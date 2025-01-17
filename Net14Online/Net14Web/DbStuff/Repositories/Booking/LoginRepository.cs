﻿using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.BookingWeb;

namespace Net14Web.DbStuff.Repositories.Booking
{
    public class LoginRepository: BaseRepository<LoginBooking>
    {
        public LoginRepository(WebDbContext context): base(context) { }

        public IEnumerable<LoginBooking> GetLogin(int maxCount = 10)
        {
            return _context.LoginsBooking
                .Take(maxCount)
                .ToList();
        }
        public void UpdateEmail(int loginId, string email)
        {
            var searches = _context.LoginsBooking.First(x => x.Id == loginId);
            searches.Email = email;
            _context.SaveChanges();
        }

        public LoginBooking? GetFirst()
        {
            return _context.LoginsBooking.FirstOrDefault();
        }
    }
}
 


        
