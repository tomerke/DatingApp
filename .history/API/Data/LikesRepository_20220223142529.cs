using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class LikesRepository : ILikesRepository
    {
        private readonly DataContext _contect;
        public LikesRepository(DataContext contect)
        {
           _contect = contect;
        }

        public async Task<UserLike> GetUserLike(int sourceUserId, int likedUserId)
        {
            return await _contect.Likes.FindAsync(sourceUserId, likedUserId);
        }

        public async Task<Page<LikeDto>> GetUserLikes(string predicate, int userId)
        {
           var users =  _contect.Users.OrderBy(u => u.UserName).AsQueryable();
           var likes = _contect.Likes.AsQueryable();

           if(predicate == "liked")
           {
               likes = likes.Where(like => like.SourceUserId == userId);
               users = likes.Select(like => like.LikedUser);
           }

           if (predicate == "likedBy")
           {
            likes = likes.Where(like => like.LikedUserId == userId);
               users = likes.Select(like => like.SourceUser);
           }

           return await users.Select(user => new LikeDto
           {
               Username = user.UserName,
               KnownAs = user.KnownAs,
               Age = user.DateOfBirth.CalculateAge(),
               PhotoUrl = user.Photos.FirstOrDefault(p => p.IsMain).Url,
               Id = user.Id
           }).ToListAsync();
        }

        public async Task<AppUser> getUserWithLikes(int userId)
        {
         return await _contect.Users
            .Include(x=> x.LikedUsers)
            .FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}