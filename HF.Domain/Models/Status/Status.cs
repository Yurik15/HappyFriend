using HFS.Domain.SeedOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace HF.Domain.Models
{
    public class Status : BaseEntity
    {
        private Status() { }
        public Status(
            int id,
            string name
            )

        {
            Id = id;
            Name = name;
            _status = new List<Status>();

        }
        public string Name { get; private set; }
        private List<Status> _status;
        public IReadOnlyList<Status> Statuses => _status;
        public Order Order { get; private set; }
    }
}
