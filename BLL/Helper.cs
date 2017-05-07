using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    //<summary>This class contains all the methods used for processing commands and checking business rules.</summary>
    public class Helper : IHelper
    {
        //<summary>This method processes commands given in the input according to temperature</summary>
        //<param name="tempType">Temperature type (Hot or Cold)</param>
        //<param name="commands">Array of commands.</param>
        //<returns>Dictionary list of processed commands</returns>
        public Dictionary<int, string> ProcessCommands(string tempType, int[] commands)
        {
            try
            {
                Dictionary<int, string> processedCommands = new Dictionary<int, string>();
                Enums.TemperatureType _tempType = (Enums.TemperatureType)Enum.Parse(typeof(Enums.TemperatureType), tempType);
                using (Db db = new Db())
                {
                    db.Initialize();
                    for (int i = 0; i < commands.Count(); i++)
                    {
                        CommandDTO item = db.commands.Where(x => x.Command == commands[i]).FirstOrDefault();
                        if ((i == 0 && !IsInitialCommand(item)) || IsDoublePiece(processedCommands, item.Command) || !CheckPrerequisites(processedCommands, item.Command, db, _tempType) || (isLastCommand(item) && !IsAllItemsPutOn(processedCommands, _tempType)) || !IsDressApplicable(db, item.Command, _tempType))
                        {
                            processedCommands.Add(0, "fail");
                            break;
                        }

                        else
                        {
                            if (_tempType == Enums.TemperatureType.HOT)
                            {                              
                                processedCommands.Add(item.Command, item.HotResponse);
                            }
                            else
                                processedCommands.Add(item.Command, item.ColdResponse);
                        }

                    }
                }
                return processedCommands;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //<summary>This method checks if prerequisite commands of processing command is processed or not.</summary>
        //<param name="processedCommands">List of processed commands</param>
        //<param name="command">Currently processing command (int).</param>
        //<param name="db">Object of Db class.</param>
        //<param name="tempType">Temperature type (Hot or Cold).</param>
        //<returns>Either true or false.</returns>
        public bool CheckPrerequisites(Dictionary<int, string> processedCommands, int command, Db db, Enums.TemperatureType tempType)
        {
            try
            {
                bool result = true;
                var ruleSet = db.commandRules.Where(x => x.TempType == tempType).ToList();
                foreach (var item in ruleSet)
                {
                    if (item.Command == command)
                    {
                        if (item.PreRequisites != null)
                        {
                            foreach (var c in item.PreRequisites)
                            {
                                if (!processedCommands.ContainsKey(c))
                                {
                                    result = false;
                                }
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //<summary>This method checks if current command is first command.</summary>
        //<param name="cmd">Currently processing command (object of CommandDTO).</param>        
        //<returns>true if first command else false.</returns>
        public bool IsInitialCommand(CommandDTO cmd)
        {
            try
            {
                if (!cmd.InitialCommand)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //<summary>Checks if same piece of dress is already put on.</summary>
        //<param name="processedList">List of processed commands.</param>
        //<param name="cmd">Currently processing command (int).</param>
        //<returns>true if same piece of dress is already put on else false.</returns>
        public bool IsDoublePiece(Dictionary<int, string> processedList, int cmd)
        {
            try
            {
                if (!processedList.ContainsKey(cmd))
                    return false;
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //<summary>Checks if currently processing command is last command.</summary>        
        //<param name="cmd">Currently processing command (object of CommandDTO).</param>     
        //<returns>true if current command is last else false.</returns>
        public bool isLastCommand(CommandDTO cmd)
        {
            try
            {
                if (!cmd.LastCommand)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //<summary>Checks if all dresses are put on before processing last command.</summary>
        //<param name="processedList">List of processed commands.</param>
        //<param name="tempType">Temperature type (Hot or Cold)</param>
        //<returns>true if all dresses are put on else false.</returns>
        public bool IsAllItemsPutOn(Dictionary<int, string> processedList, Enums.TemperatureType tempType)
        {
            bool result = true;
            try
            {
                switch (tempType)
                {
                    case Enums.TemperatureType.HOT:
                        if (processedList.Count() < (int)Enums.TotalItems.HOT - 1)
                            result = false;
                        break;
                    case Enums.TemperatureType.COLD:
                        if (processedList.Count() < (int)Enums.TotalItems.COLD - 1)
                            result = false;
                        break;
                    default:
                        result = true;
                        break;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //<summary>Checks if two dictionary lists are equal.</summary>
        //<param name="dic1">Dictionary list of results after processing commands.</param>
        //<param name="dic2">Another Dictionary list of results after processing commands.</param>
        //<returns>true if both dictionaries are equal else false.</returns>
        public bool DictionaryComparer(Dictionary<int, string> dic1, Dictionary<int, string> dic2)
        {
            if (dic1.Count() != dic2.Count)
                return false;
            return dic1.Keys.All(k => dic2.ContainsKey(k) && dic1[k] == dic2[k]);
        }

        //<summary>Checks if certain dress is applicable for given temperature.</summary>
        //<param name="db">Object of Db class.</param>
        //<param name="command">Currently processing command (int).</param>
        //<param name="tempType">Temperature type (Hot or Cold)</param>
        //<returns>true if dress of currently processing command is applicable in given temperature else false.</returns>
        public bool IsDressApplicable(Db db, int command, Enums.TemperatureType tempType)
        {
            var item = db.commandRules.Where(c => c.TempType == tempType && c.Command == command).FirstOrDefault();
            if (item != null)
            {
                return item.IsApplicable;
            }
            else
                return true;
        }

    }
}
