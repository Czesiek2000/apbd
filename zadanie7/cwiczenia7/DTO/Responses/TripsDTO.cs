using cwiczenia7.Models;
using cwiczenia7.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace cwiczenia7.DTO.Responses
{
    public class TripsDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }
        public HashSet<ClientsDTO> Clients { get; set; }
        public HashSet<CountriesDTO> Countries { get; set; }
    }
}
