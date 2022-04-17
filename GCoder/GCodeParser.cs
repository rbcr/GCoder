using System;
using System.IO;
using System.Linq;
using GCoder.Model;

namespace GCoder
{
    public class GCodeParser
    {
        public static PrintData Parse(string ruta)
        {
            PrintData printData = new PrintData();

            if (File.Exists(ruta) && Path.GetExtension(ruta) == ".gcode")
            {
                string gcodeData = File.ReadAllText(ruta);
                if (gcodeData.Contains("; PRINT_INFO"))
                {
                    Double filamentAmount = 0, filamentWeight = 0, filamentCost = 0;
                    string materialName = null, materialBrand = null, fileName = null, printTime = null;
                    Double lineWeight = 0, lineHeight = 0, infill = 0;
                    string[] rows = gcodeData.Split(new char[] { '\n' }).ToArray();
                    foreach (string row in rows)
                    {
                        if(row.Contains("PRINT_INFO"))
                        {
                            string[] printSettings = row.Split('|').ToArray();
                            foreach(string printSetting in printSettings)
                            {
                                if (printSetting.Contains("jobname"))
                                {
                                    string[] printAttributes = printSetting.Trim().Split('-');
                                    fileName = printAttributes[0].Replace("jobname: ", "");
                                    string[] settings = printAttributes[1].Split('[');
                                    foreach (string setting in settings)
                                    {
                                        string parsedSetting = setting.Trim(new Char[] { ' ', 'm', '[', ']', '_' });
                                        if (parsedSetting.Contains("LW"))
                                            lineWeight = Double.Parse(parsedSetting.Replace("LW", ""));
                                        if (parsedSetting.Contains("LH"))
                                            lineHeight = Double.Parse(parsedSetting.Replace("LH", ""));
                                        if (parsedSetting.Contains("IF"))
                                            infill = Double.Parse(parsedSetting.Replace("IF", ""));
                                    }
                                }

                                if (printSetting.Contains("material_name"))
                                    materialName = printSetting.Replace("material_name:", "").Trim();

                                if (printSetting.Contains("brand"))
                                    materialBrand = printSetting.Replace("brand:", "").Trim();

                                if (printSetting.Contains("filament_amount"))
                                    filamentAmount = GCodeParser.StringToDouble(printSetting.Replace("filament_amount:", ""));

                                if (printSetting.Contains("filament_weight"))
                                    filamentWeight = GCodeParser.StringToDouble(printSetting.Replace("filament_weight:", ""));

                                if (printSetting.Contains("filament_cost"))
                                    filamentCost = GCodeParser.StringToDouble(printSetting.Replace("filament_cost:", ""));

                                if (printSetting.Contains("print_time"))
                                    printTime = printSetting.Replace("print_time:", "").Trim();
                            }
                        }
                    }
                    
                    return new PrintData()
                    {
                        Status = true,
                        FileName = fileName,
                        PrintTime = printTime,
                        Material = materialBrand + ' ' + materialName,
                        LineWeight = lineWeight,
                        LineHeight = lineHeight,
                        Infill = infill,
                        Cost = filamentCost,
                        Weight = filamentWeight,
                        Amount = filamentAmount
                    };
                }
                else
                    return printData;
            } else
                return printData;
        }

        public static double StringToDouble(string amount)
        {
            return Double.Parse(amount.Replace(']', ' ').Trim(new Char[] { ' ', 'm', '[', ']', '_' }));
        }
    }
}
