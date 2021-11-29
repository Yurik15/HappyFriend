using HFS.Domain.SeedOfWork;
using System;

namespace HF.Domain.Models
{
    public class Users : BaseEntity
    {
        private Users() { }
        public Users(
            string firstname,
            string lastname,
            string email,
            string phonenumber,
            DateTime datebirthday,
            int userfileId,
            int roleid
            )
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            PhoneNumber = phonenumber;
            DateBirthday = datebirthday;
            UserFileId = userfileId;
            RoleId = roleid;

        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime DateBirthday { get; private set; }
        public int UserFileId { get; private set; }
        public int RoleId { get; private set; }

    }
}
