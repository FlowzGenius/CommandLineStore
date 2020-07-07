using AutoMapper;
using CommandLineStore.Entities;
using CommandLineStoreDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandLineStore.Api.Profiles
{
    public class CommandProfiles : Profile
    {
        public CommandProfiles()
        {
            CreateMap<CommandLine, CommandLineViewDto>();
            CreateMap<CommandLineViewDto, CommandLine>();

            CreateMap<CommandLineCreateDto, CommandLine>();
            CreateMap<CommandLineCreateDto, CommandLine>();

            CreateMap<CommandLine, CommandLineOperationDto>();
            CreateMap<CommandLineOperationDto, CommandLine>();
        }
    }
}
