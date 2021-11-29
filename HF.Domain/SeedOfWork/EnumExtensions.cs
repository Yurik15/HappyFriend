using System;
using System.Collections.Generic;
using System.Linq;

namespace HFS.Domain.SeedOfWork
{
    public static class EnumExtensios
    {
        public static T[] ToFlagArray<T>(this T flags)
            where T : Enum
        {
            var list = new List<T>();
            ulong flag = 1;
            foreach (var value in Enum.GetValues(flags.GetType()).Cast<T>())
            {
                ulong bits = Convert.ToUInt64(value);
                while (flag < bits)
                {
                    flag <<= 1;
                }

                if (flag == bits && flags.HasFlag(value as Enum))
                {
                    list.Add(value);
                }
            }
            return list.ToArray();
        }
    }
}
