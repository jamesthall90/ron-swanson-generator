using NodaTime;
using System;
using System.Reflection;

namespace Models.Domain
{
    public class RonSwansonQuote
    {
        public int Id { get; set; }

        public string Quote { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }
    }
}