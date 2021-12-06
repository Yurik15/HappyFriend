using HFS.Domain.SeedOfWork;
using System;

namespace HF.Domain.Models
{
    public class UsersRole : BaseEntity
    {
        private UsersRole() { }
        public UsersRole(
            string rolename,
            int usersid
            )
        {
            RoleName = rolename;
            UsersId = usersid;
        }
        public string RoleName { get; private set; }
        public int UsersId { get; private set; }
        public Users Users { get; private set; }
    }
}