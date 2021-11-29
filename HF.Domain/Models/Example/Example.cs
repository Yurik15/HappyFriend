using HFS.Domain.SeedOfWork;

namespace HF.Domain.Models
{
    public class Example : BaseEntity
    {
        // EF needs a private ctor for the rich model domain behavior acceptance
        private Example() {}
        public Example(
            string name
            )
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}
