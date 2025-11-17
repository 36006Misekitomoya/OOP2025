using System;
using System.Collections.Generic;

namespace TextFileProcessorDI {
    // P362 問題15.1
    public class LineToHalfNumberService : ITextFileService {      
        private List<string> _lines = new List<string>();
        public void Initialize(string fname) {            
            _lines.Clear();
        }

        public void Execute(string line) {           
            string converted = ConvertToHalfNumbers(line);           
            _lines.Add(converted);
        }

        public void Terminate() {           
            foreach (var line in _lines) {
                Console.WriteLine(line);
            }
        }

        // 全角数字を半角数字に変換するメソッド
        private string ConvertToHalfNumbers(string text) {          
            char ConvertChar(char c) {
                if (c >= '０' && c <= '９') {
                    return (char)(c - 0xFEE0);
                }
                return c;
            }

            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++) {
                chars[i] = ConvertChar(chars[i]);
            }
            return new string(chars);
        }
    }
}
