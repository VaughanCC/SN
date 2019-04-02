using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vcc.SocialNet.UserService.Data.Entities;

namespace Vcc.SocialNet.UserService.Data.Repository
{
    /// <summary>
    /// Interface for Member repositories
    /// </summary>
    public interface IMemberRepository
    {
        #region Synchronous methods
        IEnumerable<MemberEntity> GetMembers();
        MemberEntity GetMemberById(int memberId);
        MemberEntity GetMemberByEmail(string email);
        MemberEntity CreateMember(MemberEntity member);
        void DeleteMember(int memberId);
        void UpdateMember(MemberEntity member);
        void Save();
        #endregion

        #region Asynchronous methods
        Task<IEnumerable<MemberEntity>> GetMembersAsync();
        Task<MemberEntity> GetMemberByIdAsync(int memberId);
        Task<MemberEntity> GetMemberByEmailAsync(string email);
        Task<MemberEntity> CreateMemberAsync(MemberEntity member);
        Task DeleteMemberAsync(int memberId);
        Task UpdateMemberAsync(MemberEntity member);
        Task SaveAsync();
        #endregion


    }
}
