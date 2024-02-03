﻿using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.Movies;
using Net14Web.Models.Movies;
using Net14Web.Services.Movies;

namespace Net14Web.DbStuff.Repositories.Movies
{
    public class UserRepository : BaseRepository<User>
    {
        public readonly UserEditHelper _userEditHelper;

        public UserRepository(WebDbContext context, UserEditHelper userEditHelper) : base(context)
        {
            _userEditHelper = userEditHelper;
        }

        public User? GetUserByLoginAndPassword(string login, string password)
        {
            return _entyties
                .FirstOrDefault(user => user.Login!.ToLower() == login.ToLower() && user.Password == password);
        }

        public User? GetUserWithComments(int userId)
        {
            return _entyties
                .Include(u => u.Comments)
                .FirstOrDefault(u => u.Id == userId);
        }

        public async Task<User?> GetUserByLoginAndPasswordAsync(string login, string password)
        {
            return await _entyties
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Login!.ToLower() == login.ToLower() && user.Password == password);
        }

        public async Task<User?> GetUserWithCommentsAsync(int userId)
        {
            return await _entyties
                .Include(u => u.Comments!)
                .ThenInclude(c => c.Movie)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public void UpdateUser(User oldUser, UserViewModel updateUser)
        {
            _userEditHelper.EditUser(oldUser, updateUser);
            _context.SaveChanges();
        }
    }
}
