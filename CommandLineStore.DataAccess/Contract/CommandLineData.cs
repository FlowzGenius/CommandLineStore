using CommandLineStore.DataAccess.Contract;
using CommandLineStore.DataContext;
using CommandLineStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandLineStore.DataAccess
{
    public class CommandLineData : ICommandLineData
    {
        private readonly CommandContext _commandContext;

        public CommandLineData(CommandContext commandContext)
        {
            _commandContext = commandContext;
        }


        public async Task<List<CommandLine>> GetAll()
        {
            return await _commandContext.CommandLines.ToListAsync();
        }

        public async Task<CommandLine> GetById(string id)
        {
            var foundCommand = await _commandContext.CommandLines.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (foundCommand != null)
            {
                return foundCommand;
            }

            return null;
        }

        public async Task<bool> Update(CommandLine command)
        {
            _commandContext.Entry(command).State = EntityState.Modified;

            return await _commandContext.SaveChangesAsync() >= 0;
        }

        public async Task<bool> Add(CommandLine command)
        {
            command.Id = Guid.NewGuid().ToString();

            await _commandContext.AddAsync(command);

            return await _commandContext.SaveChangesAsync() >= 0;
        }

        public async Task<bool> Delete(string id)
        {
            var commandDelete = await _commandContext.CommandLines.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (commandDelete != null)
            {
                _commandContext.Remove(commandDelete);

                return await _commandContext.SaveChangesAsync() >= 0;
            }

            return false;
        }
    }
}
