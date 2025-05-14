using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            var songs = new List<Song>();

            Console.WriteLine("***** 曲の登録 *****");
            while (true) {

                //曲名を入力
                Console.Write("曲名:");

                //入力された曲名を取得
                string title = Console.ReadLine();

                //endが入力されたら登録終了
                if (title.Equals("end", StringComparison.OrdinalIgnoreCase)) {
                    break;
                }
                //アーティスト名を出力
                Console.Write("アーティスト名:");

                //入力されたアーティスト名を取得
                string artistname = Console.ReadLine();

                //演奏時間を出力
                Console.Write("演奏時間（秒）");

                //入力された演奏時間を取得
                int length = int.Parse(Console.ReadLine());

                //songインスタンス生成
                //Song song = new Song(title, artistname, length);
                Song song = new Song() {
                    Title = title,
                    ArtistName = artistname,
                    Length = length
                };

                //歌データを入れるリストオブジェクトへ登録
                songs.Add(song);

                Console.WriteLine();//改行


            }
            printSongs(songs);

        }



        //            //2.1.3
        //var songs = new Song[] {
        //                new Song("Let it be", "The Beatles", 243),
        //                    new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
        //                    new Song("Close To You", "Carpenters", 276),
        //                    new Song("Honesty", "Billy Joel", 231),
        //                    new Song("I Will Always Love You", "Whitney Houston", 273),
        //                };
        //    printSongs(songs);
        //}

        //        //2.1.4
        private static void printSongs(IEnumerable<Song> songs) {
#if false
                Console.WriteLine();
                Console.WriteLine("***** 登録曲一覧 *****");
                    foreach (var song in songs) {
                        var minutes = song.Length / 60;
                        var seconds = song.Length % 60;
                        Console.WriteLine($"{song.Title},{song.ArtistName} {seconds:00}");
                    }
#else
            //            //TimeSpan構造体を使った場合
            foreach (var song in songs) {
                var timespan = TimeSpan.FromSeconds(song.Length);
                Console.WriteLine($"{song.Title}");
                Console.WriteLine($"{song.ArtistName}");
                Console.WriteLine($"{timespan.Minutes}:{timespan.Seconds:00}");
                Console.WriteLine();
                //            }
                //            //また、以下でも可
                //            foreach (var song in songs) {
                //                Console.WriteLine(@"{0},{1} {2:m\:ss}",
                //                    song.Title, song.ArtistName, TimeSpan.FromSeconds(song.Length));
                //            }
#endif
                //Console.WriteLine();
            }
        }
    }
}

