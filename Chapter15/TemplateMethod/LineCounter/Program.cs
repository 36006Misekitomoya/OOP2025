using System;
using System.IO;
using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            // ファイルパスをユーザーに入力させる
            Console.Write("検索するファイルのパスを入力してください: ");
            string filePath = Console.ReadLine()?.Trim() ?? "";

            // ファイルが存在するか確認
            while (!File.Exists(filePath)) {
                Console.WriteLine("❌ ファイルが見つかりません。もう一度入力してください。");
                Console.Write("検索するファイルのパスを入力してください: ");
                filePath = Console.ReadLine()?.Trim() ?? "";
            }

            // 指定されたファイルで処理を実行
            TextProcessor.Run<LineCounterProcessor>(filePath);
        }
    }
}
