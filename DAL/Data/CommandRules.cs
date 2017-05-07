using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    //<summary>This class contains rules for each command if any.</summary>
    public class CommandRules
    {
        public CommandRules()
        {

        }
        public CommandRules(int Command,Enums.TemperatureType TempType,List<int> PreCommands,bool IsApplicable)
        {
            this.Command = Command;
            this.TempType = TempType;
            this.PreRequisites = PreCommands;
            this.IsApplicable = IsApplicable;
        }
        public int Command { get; set; }
        public Enums.TemperatureType TempType { get; set; }
        public List<int> PreRequisites { get; set; }
        public bool IsApplicable { get; set; }

    }
}
