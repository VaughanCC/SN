using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vcc.SocialNet.UserService.Data.Entities;

namespace Vcc.SocialNet.UserService.Data.Repository
{
    /// <summary>
    /// Represents the Member repository implemented using Entity Framework
    /// </summary>
    public class EFMemberRepository : IMemberRepository
    {
        private readonly UserContext _dbContext;
        public EFMemberRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Asynchronous methods
        public async Task<MemberEntity> CreateMemberAsync(MemberEntity member)
        {
            await _dbContext.Members.AddAsync(member);
            await SaveAsync();
            var newMember = await _dbContext.Members.FindAsync();
            return newMember;
        }

        public async Task DeleteMemberAsync(int memberId)
        {
            var member = await _dbContext.Members.FindAsync(memberId);
            if (member != null)
            { 
                _dbContext.Members.Remove(member);
                await SaveAsync();
            }
        }

        public async Task<MemberEntity> GetMemberByIdAsync(int memberId)
        {
            var member = await  _dbContext.Members.FindAsync(memberId);
            return member;
        }


        /// <summary>
        /// Returns a Member based on email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<MemberEntity> GetMemberByEmailAsync(string email)
        {
            MemberEntity member = null;
            if(email != null)
            {
                member = await _dbContext.Members.FirstOrDefaultAsync(m => string.Compare(m.Email, email, true) == 0);
            }
            return member;
        }

        /// <summary>
        ///  Returns the list of all members
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MemberEntity>> GetMembersAsync()
        {            
            var members = await _dbContext.Members.ToListAsync();
            return members;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMemberAsync(MemberEntity member)
        {
            _dbContext.Entry(member).State = EntityState.Modified;
            await SaveAsync();
        }
        #endregion

        #region Synchronous methods
        public MemberEntity CreateMember(MemberEntity member)
        {
            _dbContext.Members.Add(member);
            Save();
            var newMember = _dbContext.Members.Find();
            return newMember;
        }

        public void DeleteMember(int memberId)
        {
            var member = _dbContext.Members.Find(memberId);
            if (member != null)
            {
                _dbContext.Members.Remove(member);
                Save();
            }
        }

        public MemberEntity GetMemberById(int memberId)
        {
            var member = _dbContext.Members.Find(memberId);
            return member;
        }

        public MemberEntity GetMemberByEmail(string email)
        {
            var member = _dbContext.Members.FirstOrDefault(m => string.Compare(m.Email, email, true)==0);
            return member;
        }

        public IEnumerable<MemberEntity> GetMembers()
        {
            return _dbContext.Members.ToList();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateMember(MemberEntity member)
        {
            _dbContext.Entry(member).State = EntityState.Modified;
            Save();
        }
        #endregion
    }
}
