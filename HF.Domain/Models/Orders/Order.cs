using HFS.Domain.SeedOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace HF.Domain.Models
{
    public class Order : BaseEntity
    {
        private Order() { }
        public Order(
            int clientid,
            int friendid,
            int statusid
            )
        {
            ClientId = clientid;
            FriendId = friendid;
            StatusId = statusid;
        }
        public int ClientId { get; private set; }
        public int FriendId { get; private set; }
        public int StatusId { get; private set; }

        public Users Users { get; private set; }
    }
}
