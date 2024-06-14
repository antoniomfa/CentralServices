using DataAccess.Models;

namespace DataAccess.Data
{
    public interface ICommunityRepo
    {
        IEnumerable<Community> GetCommuntiesForPlatform(int platformId);
        Community GetCommunity(int platformId, int communityId);
        void CreateCommunity(int platformI, Community community);
    }
}
