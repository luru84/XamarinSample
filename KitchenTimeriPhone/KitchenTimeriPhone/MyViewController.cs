using Foundation;
using System;
using System.Threading;
using UIKit;

namespace KitchenTimeriPhone
{
    public partial class MyViewController : UIViewController
    {
        public MyViewController (IntPtr handle) : base (handle)
        {
        }

        #region グローバル定義

        /// <summary>
        /// タイマー
        /// </summary>
        private Timer _timer;

        /// <summary>
        /// スタートフラグ(True = 開始, False = 停止)
        /// </summary>
        private bool _isStart = false;

        /// <summary>
        /// タイマー時間管理
        /// </summary>
        private TimeSpan _remainingTime = new TimeSpan(0);

        #endregion


        /// <summary>
        /// ロードメソッド
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //ボタンを一部修正
            SetButtonBorder(StartButton);

            //イベントボタンの紐付け
            Add10MinButton.TouchUpInside += Add10MinButton_TouchUpInside;
            Add1MinButton.TouchUpInside += Add1MinButton_TouchUpInside;
            Add10SecButton.TouchUpInside += Add10SecButton_TouchUpInside;
            Add1SecButton.TouchUpInside += Add1SecButton_TouchUpInside;
            ClearButton.TouchUpInside += ClearButton_TouchUpInside;

            //スタートボタン
            StartButton.TouchUpInside += StartButton_TouchUpInside;

            //タイマー初期化
            _timer = new Timer(Timer_OnTick, null, 0, 100);

        }

        /// <summary>
        /// 10分追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Add10MinButton_TouchUpInside(object sender, EventArgs e)
        {
            _remainingTime = _remainingTime.Add(TimeSpan.FromMinutes(10));
            ShowRemainingTime();
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 1分追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Add1MinButton_TouchUpInside(object sender, EventArgs e)
        {
            _remainingTime = _remainingTime.Add(TimeSpan.FromMinutes(1));
            ShowRemainingTime();
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 10秒追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Add10SecButton_TouchUpInside(object sender, EventArgs e)
        {
            _remainingTime = _remainingTime.Add(TimeSpan.FromSeconds(10));
            ShowRemainingTime();
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 1分追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Add1SecButton_TouchUpInside(object sender, EventArgs e)
        {
            _remainingTime = _remainingTime.Add(TimeSpan.FromSeconds(1));
            ShowRemainingTime();
            //throw new NotImplementedException();
        }

        /// <summary>
        /// クリア
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClearButton_TouchUpInside(object sender, EventArgs e)
        {
            _remainingTime = new TimeSpan(0);
            ShowRemainingTime();
            //throw new NotImplementedException();
        }

        /// <summary>
        /// スタートボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StartButton_TouchUpInside(object sender, EventArgs e)
        {
            _isStart = !_isStart;

            if (_isStart)
            {
                StartButton.SetTitle("ストップ", UIControlState.Normal);
            }
            else
            {
                StartButton.SetTitle("スタート", UIControlState.Normal);
            }

            //throw new NotImplementedException();
        }

        //タイマーイベント
        private void Timer_OnTick(object state)
        {
            if (!_isStart)
            {
                return;
            }

            InvokeOnMainThread(() =>
            {
                _remainingTime = _remainingTime.Add(TimeSpan.FromMilliseconds(-100));
                if(_remainingTime.TotalSeconds <= 0)
                {
                    //0秒になった
                    _isStart = false;
                    _remainingTime = new TimeSpan(0);
                    StartButton.SetTitle("スタート", UIControlState.Normal);

                    //アラームを鳴らす
                    var sound = new AudioToolbox.SystemSound(1005);
                    sound.PlayAlertSound();
                }
                ShowRemainingTime();
            });

        }


        /// <summary>
        /// 時間表示メソッド
        /// </summary>
        private void ShowRemainingTime()
        {
            RemainingTimeLabel.Text = string.Format("{0:f0}:{1:d2}",
                _remainingTime.Minutes,
                _remainingTime.Seconds);
        }

        /// <summary>
        /// ボタン枠追加メソッド
        /// </summary>
        /// <param name="button"></param>
        public void SetButtonBorder(UIButton button)
        {
            button.Layer.CornerRadius = 3;
            button.Layer.BorderColor = UIColor.LightGray.CGColor;
            button.Layer.BorderWidth = 1f;
        }
    }
}