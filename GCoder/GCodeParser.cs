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
                    string materialName = null, materialBrand = null, fileName = null, printTime = null, created_at = null;
                    Double lineWeight = 0, lineHeight = 0, infill = 0, scale = 0, maxx = 0, minx = 0, maxy = 0, miny = 0, maxz = 0, minz = 0;
                    bool SupportsEnabled = false;
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
                                    string[] printAttributes = printSetting.Trim().Split(new string[] { "-[" }, StringSplitOptions.None);
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
                                        if (parsedSetting.Contains("SC"))
                                            scale = Double.Parse(parsedSetting.Replace("SC", "").Trim());
                                        if (parsedSetting.Contains("CA"))
                                            created_at = parsedSetting.Replace("CA", "").Trim();
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

                                if (printSetting.Contains("support_enabled"))
                                    SupportsEnabled = Convert.ToBoolean(printSetting.Replace("support_enabled:", "").Trim());                                    
                            }
                        }

                        if (row.Contains("MAXX"))
                            maxx = Convert.ToDouble(row.Replace(";MAXX:", "").Trim());

                        if (row.Contains("MINX"))
                            minx = Convert.ToDouble(row.Replace(";MINX:", "").Trim());

                        if (row.Contains("MAXY"))
                            maxy = Convert.ToDouble(row.Replace(";MAXY:", "").Trim());

                        if (row.Contains("MINY"))
                            miny = Convert.ToDouble(row.Replace(";MINY:", "").Trim());

                        if (row.Contains("MAXZ"))
                            maxz = Convert.ToDouble(row.Replace(";MAXZ:", "").Trim());

                        if (row.Contains("MINZ"))
                            minz = Convert.ToDouble(row.Replace(";MINZ:", "").Trim());
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
                        Amount = filamentAmount,
                        Scale = scale,
                        SupportsEnabled = SupportsEnabled,
                        ObjectWidth = maxx - minx,
                        ObjectHeight = maxy - miny,
                        ObjectBackground = maxz - minz,
                        Created_at = Convert.ToDateTime(created_at)
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
