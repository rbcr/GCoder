using System;
using System.Drawing;
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
                    string materialName = null, materialBrand = null, fileName = null, printTime = null, created_at = null, stringBase64 = null;
                    Double lineWeight = 0, lineHeight = 0, infill = 0, scale = 0, maxx = 0, minx = 0, maxy = 0, miny = 0, maxz = 0, minz = 0;
                    bool SupportsEnabled = false;

                    string[] rangeBase64 = gcodeData.Split(new string[] { "; thumbnail begin", "; thumbnail end" }, StringSplitOptions.None);
                    if(rangeBase64.Count() > 1)
                        stringBase64 = string.Join("", rangeBase64[1].Replace("; ", "").Split(new char[] { '\n' }).Skip(1));

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
                        Thumbnail = GCodeParser.LoadBase64Image(stringBase64),
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

        public static Image LoadBase64Image(string base64 = "")
        {
            string defaultThumbnail = "iVBORw0KGgoAAAANSUhEUgAAAdQAAAHaCAYAAAC5LbgcAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAC83SURBVHhe7d3pb2TXnd7xX+1VLJK9US21ZVmWJY1ly/aMZGuciTFBJgECz4t5k38vr4IAMYIACTBAMmPYGS9Sa+2FbDbJXtn7RrG5177lPKfqdFdzJC6q02oW6/uBrmrhrWrWrcvz3N+599ybKFdqHQMAAPuSTCZ797oSa+ubBCoAAPuUSCSs3W77+wrXZ+MVAAB8IwQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIAEAGBCgBABAQqAAAREKgAAERAoAIA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IAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACAhUAAAiIFABAIiAQAUAIAICFQCACBLrG1ud3n0AALBHnU7nyZRKpSyxtr5JoAIA8A20221/m0wmLbG6tkGgAgCwT4lE4kmF6gOVLl8AAPZP3byqUJ8EaqlcJVABANin/kBVtZqo1ZsEKgAA+6SqVIGqyQdqvdEiUAEA2Kf+QJVEo9kmUAEA2CdVpa1W62mgUqECADAos/8PvzRbDGNx5/8AAAAASUVORK5CYII=";
            if (string.IsNullOrEmpty(base64) == true)
            {
                base64 = defaultThumbnail;
            }
            byte[] bytes = Convert.FromBase64String(base64);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            return (Image)(new Bitmap(image, new Size(64, 64))); ;
        }
    }
}
