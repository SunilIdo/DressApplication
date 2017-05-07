using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IHelper
    {
        Dictionary<int, string> ProcessCommands(string tempType, int[] commands);
        bool CheckPrerequisites(Dictionary<int, string> processedCommands, int command, Db db, Enums.TemperatureType tempType);
        bool IsInitialCommand(CommandDTO cmd);
        bool IsDoublePiece(Dictionary<int, string> processedList, int cmd);
        bool isLastCommand(CommandDTO cmd);
        bool IsAllItemsPutOn(Dictionary<int, string> processedList, Enums.TemperatureType tempType);
        bool DictionaryComparer(Dictionary<int, string> dic1, Dictionary<int, string> dic2);
        bool IsDressApplicable(Db db, int command, Enums.TemperatureType tempType);

    }
}
