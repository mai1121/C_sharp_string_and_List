using System;
//List使うために定義
using System.Collections.Generic;
//Anyメソッド使うために定義
using System.Linq;
//正規表現マッチ判定するために定義
using System.Text.RegularExpressions;

namespace practice_string_class
{
    class Program
    {
        static void Main(string[] args)
        {
            //文字列しか格納できない
            var name = new List<string> { };
            //数値しか格納できない
            var old = new List<int> { };

            Console.WriteLine("人数を入力してください");
            int num = int.Parse(Console.ReadLine());

            var i = 0;

            while (i<num)
            {
                Console.WriteLine("名前を入力してください");
                var a = Console.ReadLine();

                #region 名前の入力チェック
                if (String.IsNullOrEmpty(a))
                {
                    Console.WriteLine("必ず入力してください");
                }else if(a.Any(x=>Char.IsDigit(x)))
                {
                    Console.WriteLine("数字を含めることはできません");
                }
                else if (a.Length >= 5)
                {
                    Console.WriteLine("５文字以内で入力してください");
                }
                else 
                {
                    name.Add(a);
                    //変数展開で出力
                    Console.WriteLine($"{i+1}人目は{name[i]}さんです");
                    //プレースホルダーで埋め込み
                    Console.WriteLine(String.Format("{0}人目は{1}さんです",$"{i+1}",$"{name[i]}"));
                    i++;
                }
                #endregion
            }

            //取り消しの処理
            Console.WriteLine("確定の場合は1を、取り消す場合は2を押してください");
            var input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Console.WriteLine("生年月日入力に進みます");
                    break;

                case 2:
                    Console.WriteLine("取り消す人は誰ですか");
                    var delete_name = Console.ReadLine();
                    name.Remove(delete_name);
                    break;
            }

            var c = 0;
            while(c< name.Count)
            {
                Console.WriteLine($"{name[c]}さんの年齢を入力してください");
                var b = Console.ReadLine();



                //正規表現パターン作成
                var rgx = new Regex(@"^[0-9]{2}");
                Console.WriteLine(rgx.IsMatch(b));
                //年齢入力チェック
                if (rgx.IsMatch(b))
                {
                    old.Add(int.Parse(b));
                    c++;
                }
                else
                {
                    Console.WriteLine("１〜３桁の数字で入力してください");
                }
            }

        }
    }
}
