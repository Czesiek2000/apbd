using System;
using System.Collections.Generic;

namespace MovieApp.Shared.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Picture { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<MoviesActors> MoviesActors { get; set; } = new List<MoviesActors>();
        public string Character { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Person p2)
            {
                return Id == p2.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
