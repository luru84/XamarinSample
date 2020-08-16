using System;
namespace XMEMO
{

    /// <summary>
    /// メモクラス、メモ1枚のデータ
    /// </summary>
    public class Memo
    {
        public Memo()
        {
        }

        /// <summary>
        /// メモ時間
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// メモタイトル
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// メモ内容
        /// </summary>
        public string Text { get; set; }

    }
}
