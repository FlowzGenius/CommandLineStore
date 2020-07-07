using CommandLineStore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandLineStore.DataAccess.Contract
{
    public interface ICommandLineData
    {
        Task<bool> Add(CommandLine command);
        Task<bool> Delete(string id);
        Task<List<CommandLine>> GetAll();
        Task<CommandLine> GetById(string id);
        Task<bool> Update(CommandLine command);
    }
}