using AutoMapper;
using CommandLineStore.Entities;
using CommandLineStoreDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandLineStoreWeb.Profiles
{
    public class CommandProfile : Profile
    {
        public CommandProfile()
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
