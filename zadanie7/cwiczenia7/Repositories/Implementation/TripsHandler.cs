using cwiczenia7.DTO.Requests;
using cwiczenia7.DTO.Responses;
using cwiczenia7.Models;
using cwiczenia7.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace cwiczenia7.Repositories.Implementation
{
    public class TripsHandler : ITripsHandler
    {
        private readonly _2019SBDContext _context;

        public TripsHandler ( _2019SBDContext context )
        {
            _context = context;
        }

        public async Task<ICollection<TripsDTO>> GetTripsAsync ()
        {
            var result = await _context.Trips.Include( x => x.ClientTrips ).ThenInclude( y => y.IdClientNavigation)
                .Include(x => x.CountryTrips).ThenInclude(y => y.IdCountryNavigation)
                .Select(x => new TripsDTO
                { 
                    Name = x.Name,
                    Description = x.Description,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo,
                    MaxPeople = x.MaxPeople,
                    Clients = x.ClientTrips.Select(y => new ClientsDTO { FirstName = y.IdClientNavigation.FirstName } ).ToHashSet(),
                    Countries = x.CountryTrips.Select(y => new CountriesDTO { Name = y.IdCountryNavigation.Name } ).ToHashSet(),
                } )
                .OrderByDescending(x => x.DateFrom)
                .ToListAsync();

            return result;
        }

        public async Task<bool> UpdateClients (ClientDTO clients)
        {
            var isInDb = await _context.Clients.SingleOrDefaultAsync( x => x.Pesel == clients.Pesel );
            var isTrip = await _context.Trips.AnyAsync( x => x.IdTrip == clients.IdTrip );
            var isClientInTrip = await _context.ClientTrips.AnyAsync( x => x.IdTrip == clients.IdTrip );

            if ( isInDb != null )
            {
                return false;
            }

            if ( isTrip )
            {
                return false;
            }

            if ( isClientInTrip )
            {
                return false;
            }

            var client = _context.Clients.Max( x => x.IdClient);
            var newClient = await _context.AddAsync( new Client
            {
                IdClient = client + 1,
                FirstName = clients.FirstName,
                LastName = clients.LastName,
                Email = clients.Email,
                Telephone = clients.Telephone,
                Pesel = clients.Pesel,

            } );

            var clientTrip = await _context.AddAsync( new ClientTrip
            {
                IdClient = client + 1,
                IdTrip = clients.IdTrip,
                //PaymentDate = DateTime.Parse( clients.PaymentDate, System.Globalization.CultureInfo.Inaria),
                PaymentDate = DateTime.ParseExact( clients.PaymentDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture ),
                RegisteredAt = DateTime.Now
            } );

            
            var trip = await _context.AddAsync( new Trip
            {
                IdTrip = clients.IdTrip,
                Name = clients.TripName,
            } );

            return await _context.SaveChangesAsync() > 0;


        }

    }
}
