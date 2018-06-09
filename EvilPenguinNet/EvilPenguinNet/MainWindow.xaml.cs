using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoreTweet;
using EvilPenguinNet.Data;

namespace EvilPenguinNet
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        Settings Settings { get; set; }

        /// <summary>
        /// ここからTwitterを操作する
        /// </summary>
        Tokens Tokens { get; set; }

        /// <summary>
        /// ツイートのデータ
        /// リストにバインディングする
        /// </summary>
        ObservableCollection<Tweet> TweetList = new ObservableCollection<Tweet>();

        public MainWindow()
        {
            Settings = new Settings();
            Tokens = Tokens.Create(Settings.ConsumerKey, Settings.ConsumerSecret, Settings.AccessToken, Settings.AccessSecret);

            InitializeComponent();

            Load();

            // リストにデータを流し込む
            TweetListView.DataContext = TweetList;
        }

        // GetTopTweet
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UserName.Text == "UserName")
            {
                Console.WriteLine("UserNameを入れてくれないとどうしようもない");
            }
            else
            {
                long? maxTweetIdParse = null;
                if (long.TryParse(MaxTweetId.Text, out long maxTweetIdValue))
                {
                    maxTweetIdParse = maxTweetIdValue;
                }
                Console.WriteLine($"ID:{maxTweetIdValue}から過去を取得");

                int? getCountParse = null;
                if (int.TryParse(Count.Text, out int getCountValue))
                {
                    getCountParse = Math.Min(200, getCountValue);
                }
                else
                {
                    getCountParse = 10;
                }
                Console.WriteLine($"{getCountParse}件取得");
                try
                {
                    var tl = Tokens.Statuses.UserTimelineAsync(UserName.Text, getCountParse, null, maxTweetIdParse);
                    var tlList = tl.Result.ToList();
                    if ((bool)RetweetOnly.IsChecked)
                    {
                        // RTのみにする
                        tlList = tlList.Where(item => item.Text.StartsWith("RT @")).ToList();
                    }
                    Console.WriteLine($"取得件数:{tlList.Count}");
                    TweetList.Clear();
                    int count = 0;
                    foreach (var item in tlList)
                    {
                            string text = item.Text;
                            if (IsUnicode(item.Text))
                            {
                                text = GetTranslateUnicode(text);
                            }
                            var tweet = new Tweet
                            {
                                Id = item.Id,
                                Text = text
                            };
                            TweetList.Add(tweet);

                            count++;
                            Console.WriteLine($"{count}--------------------{item.Id}--------------------");
                            Console.WriteLine($"投稿時間：{item.CreatedAt}");  // 投稿時間
                            Console.WriteLine($"{item.FavoriteCount}いいね\t{item.RetweetCount}RT");  // いいね,RT数
                            Console.WriteLine($"{item.User.Name}({item.User.ScreenName})");
                            Console.WriteLine(item.Text);

                            maxTweetIdParse = item.Id;
                    }
                    MaxTweetId.Text = maxTweetIdParse.ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"TLの取得に失敗した\nUserNameが合ってるか確かめて欲しい");
                    Console.WriteLine($"{ex.ToString()}");
                }
            }
        }


        const string filename = "save.txt";
        // save
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // StreamWriter でファイルを初期化
            System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, false);

            // hogehoge.txtに書き込まれていても、上書きで書き出す
            sw.Write($"{UserName.Text}\r\n");
            sw.Write($"{MaxTweetId.Text}\r\n");

            // 閉じる (オブジェクトの破棄)
            sw.Close();

            Console.WriteLine("Saveしました");
        }

        private void Load()
        {
            // ファイルの存在チェック
            if (System.IO.File.Exists(filename))
            {
                Console.WriteLine("ファイルが見つかったのでLoadします");
                // StreamReaderでファイルを読み込む
                System.IO.StreamReader reader = (new System.IO.StreamReader(filename));

                // ファイルの最後まで読み込む
                UserName.Text = reader.ReadLine();
                MaxTweetId.Text = reader.ReadLine();

                // 閉じる (オブジェクトの破棄)
                reader.Close();
            }
        }

        /// <summary>
        /// Unicode 固有文字が存在するかをチェックして、その結果を返す。
        /// マネージドコード版
        /// </summary>
        /// <param name="checkString">チェック対象の文字列</param>
        /// <returns>Unicode固有文字が含まれているとき true、含まれないとき false を返す</returns>
        private bool IsUnicode(string checkString)
        {
            byte[] translateBuffer = Encoding.GetEncoding("shift_jis").GetBytes(checkString);
            string translateString = Encoding.GetEncoding("shift_jis").GetString(translateBuffer);
            return (checkString != translateString.ToString());
        }
        private string GetTranslateUnicode(string checkString)
        {
            byte[] translateBuffer = Encoding.GetEncoding("shift_jis").GetBytes(checkString);
            string translateString = Encoding.GetEncoding("shift_jis").GetString(translateBuffer);
            return translateString.ToString();
        }

        // DELボタン
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (var item in TweetListView.SelectedItems)
            {
                var tweet = (Tweet)item;

                if (tweet.Text.StartsWith("RT @"))
                {
                    Tokens.Statuses.Unretweet(id => tweet.Id);
                    //Tokens.Statuses.Destroy(id => tweet.Id);
                }
                else
                {
                    Tokens.Statuses.Destroy(id => tweet.Id);
                }

            }
        }
    }
}
