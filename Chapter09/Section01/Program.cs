using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //var today =  new DateTime(2025,7,12);
            //var now = DateTime.Now;

            //Console.WriteLine($"Now:{now}");
            //Console.WriteLine($"Today:{today}");

            //自分の生年月日は何曜日かをプログラムを書いて調べる          
            Console.WriteLine("日付を入力");
            Console.Write("西暦:");
            var a = int.Parse(Console.ReadLine());
            Console.Write("月:");
            var b = int.Parse(Console.ReadLine());
            Console.Write("日:");
            var c = int.Parse(Console.ReadLine());
            var birthday = new DateTime(a, b, c);

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = birthday.ToString("ggyy年M月d日dddd", culture);
            DayOfWeek dayOfWeek = birthday.DayOfWeek;
            Console.WriteLine(str);

            //生まれてから○○〇〇日目です
            //var now = DateTime.Now;
            //var diff = now.Date - birthday;
            //Console.WriteLine($"生まれてから{diff.Days}日目です");
            TimeSpan diff;
            while (true) {
                diff = DateTime.Now - birthday;
                Console.Write($"\r{diff.TotalSeconds}秒");
            }

            //あなたは〇〇歳です！
            static int GetAge(DateTime birthday, DateTime now) {
                var age = now.Year - birthday.Year;
                if (now < birthday.AddYears(age)) {
                    age--;
                }
                return age;
            }
            var today = DateTime.Today;
            int age = GetAge(birthday, today);
            Console.WriteLine($"{age}歳");

            //1月1日から何日目か
            var Today = DateTime.Today;
            int dayOfYear = Today.DayOfYear;
            Console.WriteLine($"{dayOfYear}日目");

            //うるう年の判定プログラムを作成する
            var isLeapYear = DateTime.IsLeapYear(a);
            if (isLeapYear) {
                Console.WriteLine("うるう年です");
            } else {
                Console.WriteLine("うるう年ではありません");
            }






        }
    }
}
