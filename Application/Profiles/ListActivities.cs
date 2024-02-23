using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
    public class ListActivities
    {
        public class Query : IRequest<Result<List<UserActivityDto>>>
        {
            public string Username { get; set; }
            public string Predicate { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<UserActivityDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<UserActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.ActivityAttendees //query activityattendees table OR you can query the user that has the activities
                    .Where(u => u.AppUser.UserName == request.Username) //get activities where there's a match
                    .OrderBy(a => a.Activity.Date) //order by date
                    .ProjectTo<UserActivityDto>(_mapper.ConfigurationProvider) //use projection to go from activityattendee to useractivitydto to get activitydtos
                    .AsQueryable(); //not executing anything to the db

                query = request.Predicate switch //do action depending on the cases below
                {
                    "past" => query.Where(a => a.Date <= DateTime.Now),
                    "hosting" => query.Where(a => a.HostUsername == request.Username),
                    _ => query.Where(a => a.Date >= DateTime.Now)
                };

                var activities = await query.ToListAsync(); //get activities and sent them via listasync

                return Result<List<UserActivityDto>>.Success(activities);
            }
        }
    }
}