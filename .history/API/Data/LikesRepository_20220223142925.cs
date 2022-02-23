using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
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

        public async Task<PageList<LikeDto>> GetUserLikes(LikesParams likesParams)
        {
           var users =  _contect.Users.OrderBy(u => u.UserName).AsQueryable();
           var likes = _contect.Likes.AsQueryable();

           if(likesParams.Predicate == "liked")
           {
               likes = likes.Where(like => like.SourceUserId == likesParams.UserId);
               users = likes.Select(like => like.LikedUser);
           }

           if (likesParams.Predicate == "likedBy")
           {
            likes = likes.Where(like => like.LikedUserId == likesParams.UserId);
               users = likes.Select(like => like.SourceUser);
           }

         var likesUsers =  users.Select(user => new LikeDto
           {
               Username = user.UserName,
               KnownAs = user.KnownAs,
               Age = user.DateOfBirth.CalculateAge(),
               PhotoUrl = user.Photos.FirstOrDefault(p => p.IsMain).Url,
               Id = user.Id
           });
           return await PageList<LikeDto>.CreateAsync(likesUsers, likesParams.PageNumber, )
        }

        public async Task<AppUser> getUserWithLikes(int userId)
        {
         return await _contect.Users
            .Include(x=> x.LikedUsers)
            .FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}