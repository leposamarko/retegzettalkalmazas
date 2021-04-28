// <copyright file="MapperFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace KutyaVerseny.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;

    /// <summary>
    /// mapper.
    /// </summary>
    public class MapperFactory
    {
        /// <summary>
        /// create mapper.
        /// </summary>
        /// <returns>mapped items.</returns>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<KutyaVerseny.Data.Models.Dog, KutyaVerseny.Web.Models.Dog>().
                ForMember(dest => (int)dest.ChipNum, map => map.MapFrom(src => (int)src.ChipNum)).
                ForMember(dest => dest.Breed, map => map.MapFrom(src => src.Breed)).
                ForMember(dest => dest.OwnerName, map => map.MapFrom(src => src.OwnerName)).
                ForMember(dest => dest.Gender, map => map.MapFrom(src => src.Gender)).
                ForMember(dest => dest.DogName, map => map.MapFrom(src => src.DogName));
            });
            return config.CreateMapper();
        }
    }
}
