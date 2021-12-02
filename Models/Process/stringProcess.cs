using System;
using System.Text.RegularExpressions;

namespace MvcMovie.Models.Process
{
     
    public class stringProcess
    {
        // Phương thức sinh nã tự động dựa trên tham số đầu vào
        // mã đầu vào cho sản phẩm PRD001,...
        //Khai báo 1 phương thức nhận tham số đầu vào là kiểu string
        // public string GenerateKey (string id){
        //     string newKey="";
        //     //id = "PRD009"
        //     // từ tham số đầu vào tách riêng phần số và phần chữ ra
        //     //su dung Regex de tach rieng phan so va phan chu
        //     string pattern = @"\d";
        //     RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled;
        //     string text = "PRO001";
        //     MatchCollection matches;
        //     Regex optionRegex = new Regex(pattern, options);
        //     Console.WriteLine("Parsing '{0}' with options {1}:", text, options.ToString());
        //     // Get matches of pattern in text
        //     matches = optionRegex.Matches(text);
        //     // Iterate matches
        //     string number = "";
        //     for (int ctr = 0; ctr < matches.Count; ctr++){ 
        //         // Console.WriteLine("{0}. {1}", ctr, matches[ctr].Value);
        //         number += matches[ctr].Value;
        //         Console.Write(number);
        //         }
           
        //     // chuyển phần số sang kiểu int và tăng lên 1 đơn vị
        //     // bổ sung phần ký tự số 0 còn thiết để đảm bảo độ dài của mã bằng nhau
        //     //ghép phần số và chữ để sinh mã mới
        //     return newKey;
        // }

        public string GenerateKey(string id){
            string strKey = "";
            string numPart= "", strPart = "";
            numPart = Regex.Match(id, @"\d+").Value;
            strPart = Regex.Match(id, @"\D+").Value;

            int intPart = (Convert.ToInt32(numPart) +1);
            for(int i = 0; i<numPart.Length - intPart.ToString().Length; i++){
                strPart += "0";
            }
            strKey = strPart + intPart;
            return strKey;
        }
    }
}