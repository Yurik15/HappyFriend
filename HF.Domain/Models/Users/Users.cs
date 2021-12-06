using HFS.Domain.SeedOfWork;
using System;
using System.Collections.Generic;

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
            DateTime datebirthday
            )
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            PhoneNumber = phonenumber;
            DateBirthday = datebirthday;
            _usersFiles = new List<UsersFile>();
            _usersRoles = new List<UsersRole>();


        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime DateBirthday { get; private set; }
        private List<UsersFile> _usersFiles;
        private List<UsersRole> _usersRoles;
        public IReadOnlyList<UsersRole> UserRoles => _usersRoles;
        public IReadOnlyList<UsersFile> UserFiles => _usersFiles;
    }
}
