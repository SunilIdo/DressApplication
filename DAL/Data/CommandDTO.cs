using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    //<summary>This class is a DTO model for Command. It contains Command, Description, Responses(Hot and Cold) for each command.</summary>
    public class CommandDTO
    {
        public CommandDTO()
        {

        }
        public CommandDTO(int Command, string Description, string HotResponse, string ColdResponse, bool InitialCommand, bool LastCommand)
        {
            this.Command = Command;
            this.Description = Description;
            this.HotResponse = HotResponse;
            this.ColdResponse = ColdResponse;
            this.InitialCommand = InitialCommand;
            this.LastCommand = LastCommand;
        }
        public int Command { get; set; }
        public string Description { get; set; }
        public string HotResponse { get; set; }
        public string ColdResponse { get; set; }
        public bool InitialCommand { get; set; }
        public bool LastCommand { get; set; }
    }
}
