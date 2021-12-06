using HFS.Domain.SeedOfWork;
using System;
using System.Collections.Generic;

namespace HF.Domain.Models
{
    public class UsersFile : BaseEntity
    {
        private UsersFile() { }
        public UsersFile(
            byte[] content,
            int userid         
            )

        {
            Content = content;
            UserId = userid;       

        }

        public byte[] Content { get; private set; }
        public int UserId { get; private set; }

        public Users Users { get; private set; }

    }

 
}