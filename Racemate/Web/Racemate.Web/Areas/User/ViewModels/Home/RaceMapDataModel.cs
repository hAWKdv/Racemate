﻿namespace Racemate.Web.Areas.User.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using Racemate.Web.Infrastructure.Mapping;
    using Racemate.Data.Models;
    using AutoMapper;

    public class RaceMapDataModel : RaceAbstractViewModel, IMapFrom<Race>, IHaveCustomMappings
    {
        public string Type { get; set; }

        public int FreeRacePositions { get; set; }

        public virtual ICollection<RaceRoutePoint> Routepoints { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Race, RaceMapDataModel>()
                .ForMember(dest => dest.Type,
                            opts => opts.MapFrom(src => src.Type.Name))
                .ForMember(dest => dest.FreeRacePositions,
                            opts => opts.MapFrom(src => src.AvailableRacePositions - src.Participants.Count));
        }
    }
}