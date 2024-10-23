using System.Collections.Generic;
using System.IO;

namespace ExpressMs.HtmlConverter
{
    public class HtmlToImageConverter
    {
        public static Dictionary<string ,string> ConvertandSaveToFolder(Dictionary<string, string> ContentData
                                                                        ,string month)
        {
            var converter = new CoreHtmlToImage.HtmlConverter();
            Dictionary<string,string>urlNumberDicResult = new Dictionary<string, string>();

            foreach (var data in ContentData)
            {
                var html = data.Value;
                var bytes = converter.FromHtmlString(html);
                //To do update it with current directory 
                //create class to save file to folder 
                var FileName = $"D:\\{month}\\{data.Key}" + ".png";
                File.WriteAllBytes(FileName, bytes);
                urlNumberDicResult.Add(FileName, data.Key);
            }
            return urlNumberDicResult;

        }

    }
}