using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    //<summary>This class is for data. It stores and provides basic data required for processing commands and giving response accordingly.</summary>
    public class Db : Disposable
    {
        public List<CommandDTO> commands;
        public List<CommandRules> commandRules;
        public Db()
        {
            commands = new List<CommandDTO>();
            commandRules = new List<CommandRules>();
        }

        //<summary>This method sets initial data.</summary>        
        public void Initialize()
        {
            commands.Add(new CommandDTO(1, "Put on footwear", "sandals", "boots", false, false));
            commands.Add(new CommandDTO(2, "Put on headwear", "sun visor", "hat", false, false));
            commands.Add(new CommandDTO(3, "Put on socks", "fail", "socks", false, false));
            commands.Add(new CommandDTO(4, "Put on shirt", "t-shirt", "shirt", false, false));
            commands.Add(new CommandDTO(5, "Put on jacket", "fail", "jacket", false, false));
            commands.Add(new CommandDTO(6, "Put on pants", "shorts", "pants", false, false));
            commands.Add(new CommandDTO(7, "Leave house", "leaving house", "leaving house", false, true));
            commands.Add(new CommandDTO(8, "Take off pajamas", "Removing PJs", "Removing PJs", true, false));
            commandRules.Add(new CommandRules(1, Enums.TemperatureType.HOT, new int[] { 6 }.ToList(), true));
            commandRules.Add(new CommandRules(1, Enums.TemperatureType.COLD, new int[] { 3, 6 }.ToList(), true));
            commandRules.Add(new CommandRules(2, Enums.TemperatureType.HOT, new int[] { 4 }.ToList(), true));
            commandRules.Add(new CommandRules(2, Enums.TemperatureType.COLD, new int[] { 4 }.ToList(), true));
            commandRules.Add(new CommandRules(5, Enums.TemperatureType.COLD, new int[] { 4 }.ToList(), true));
            commandRules.Add(new CommandRules(5, Enums.TemperatureType.HOT, null, false));
            commandRules.Add(new CommandRules(3, Enums.TemperatureType.HOT, null, false));
        }
        protected override void DisposeCore()
        {

        }
    }
}
