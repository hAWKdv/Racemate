﻿namespace Racemate.Web.Areas.User.ViewModels.Race
{
    using Racemate.Data.Models;
    using Racemate.Web.Areas.User.ViewModels.Garage;
    using Racemate.Web.Areas.User.ViewModels.Home;
    using Racemate.Web.Infrastructure.Mapping;

    public class ParticipantViewModel : IMapFrom<RaceParticipant>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public UserThumbViewModel Participant { get; set; }

        public CarViewModel RaceCar { get; set; }

        public bool IsKicked { get; set; }

        public int FinishPosition { get; set; }

        public string FinishTime { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<RaceParticipant, ParticipantViewModel>()
                .ForMember(dest => dest.RaceCar,
                           opts => opts.MapFrom(src => src.Car))
                .ForMember(dest => dest.Participant,
                           opts => opts.MapFrom(src => src.User));
        }
    }
}