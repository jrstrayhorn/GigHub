﻿using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string userId, string artistId);
        IEnumerable<Following> GetFollowingsByFollowerId(string userId);
        void Add(Following following);
        void Remove(Following following);
    }
}