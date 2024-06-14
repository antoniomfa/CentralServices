using CentralService.DataAccess.Data;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class CommunityRepo : ICommunityRepo
    {
        private readonly AppDbContext _context;

        public CommunityRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCommunity(int platformId, Community community)
        {
            if (community == null) throw new ArgumentNullException(nameof(community));

            community.PlatformId = platformId;

            _context.Add(community);
        }

        public Community GetCommunity(int platformId, int communityId)
        {
            return _context.Communities
                .Where(c => c.PlatformId == platformId && c.Id == communityId)
                .FirstOrDefault();
        }

        public IEnumerable<Community> GetCommuntiesForPlatform(int platformId)
        {
            return _context.Communities
                .Where(c => c.PlatformId == platformId)
                .OrderBy(x => x.Name);
        }
    }
}
