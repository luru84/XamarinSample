using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Media;
using System;
using System.Threading;

namespace KitchenTimer
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        // フィールド変数
        private int _remainingMilliSec = 0; // 秒数管理用
        private bool _isStart = false;
        private Button _startButton;
        private Timer _timer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // 10分追加用のボタンを宣言、List形式からIDを元にボタンを探す。
            // ボタンにイベントを紐付け、VB.Netと同様の処理を行う。
            var add10MinButton = FindViewById<Button>(Resource.Id.Add10MinButton);         
            add10MinButton.Click += Add10MinButton_Click;

            // 1分追加用のボタンを宣言、ラムダ式
            var add1MinButton = FindViewById<Button>(Resource.Id.Add1MinButton);
            add1MinButton.Click += (s, e) =>
            {
                _remainingMilliSec += 60 * 1000;
                ShowRemainingTime();
            };

            // 10秒追加用のボタン宣言
            var add10SecButton = FindViewById<Button>(Resource.Id.Add10SecButton);
            add10SecButton.Click += Add10SecButton_Click;

            // 1秒追加用のボタン宣言
            var add1SecButton = FindViewById<Button>(Resource.Id.Add1SecButton);
            add1SecButton.Click += Add1SecButton_Click;

            // クリア用ボタンの宣言、ラムダ式
            var clearButton = FindViewById<Button>(Resource.Id.ClearButton);
            clearButton.Click += (s, e) =>
            {
                _remainingMilliSec = 0;
                ShowRemainingTime();
            };

            // スタートボタンの情報格納
            _startButton = FindViewById<Button>(Resource.Id.StartButton);
            _startButton.Click += StartButton_Click;

            // タイマー処理の追加
            _timer = new Timer(Timer_OnTick, null, 0, 100);

        }

        /// <summary>
        /// 指定時間ごとに呼び出されるメソッド、
        /// </summary>
        /// <param name="state"></param>
        private void Timer_OnTick(object state)
        {
            if (!_isStart)
            {
                return;
            }

            // UI操作の場合にはのメインスレッドに切り替えて操作、ラムダ式
            RunOnUiThread(() =>
            {
                _remainingMilliSec -= 100;
                if (_remainingMilliSec <= 0)
                {
                    // 0ミリ秒になった
                    _isStart = false;
                    _remainingMilliSec = 0;
                    _startButton.Text = "スタート";
                    // アラームを鳴らす
                    var toneGenerator = new ToneGenerator(Stream.System, 50);
                    toneGenerator.StartTone(Tone.PropBeep);
                }
                ShowRemainingTime();
            });
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            _isStart = !_isStart;
            if (_isStart)
            {
                _startButton.Text = "ストップ";
            }
            else
            {
                _startButton.Text = "スタート";
            }

        }

        private void Add1SecButton_Click(object sender, EventArgs e)
        {
            _remainingMilliSec += 1 * 1000;
            ShowRemainingTime();
        }

        private void Add10SecButton_Click(object sender, EventArgs e)
        {
            _remainingMilliSec += 10 * 1000;
            ShowRemainingTime();
        }

        /// <summary>
        /// 10分ボタンのイベントメソッド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add10MinButton_Click(object sender, System.EventArgs e)
        {
            _remainingMilliSec += 600 * 1000;
            ShowRemainingTime();
        }

        private void ShowRemainingTime()
        {
            var sec = _remainingMilliSec / 1000;
            FindViewById<TextView>(Resource.Id.RemainingTimeTextView).Text
                = string.Format("{0:f0}:{1:d2}", sec / 60, sec % 60);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}