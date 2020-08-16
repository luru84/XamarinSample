using System;
namespace XMEMO
{
    /// <summary>
    /// メモホルダー、メモの集合体
    /// </summary>
    public class MemoHolder
    {
        public MemoHolder()
        {
        }

        /// <summary>
        /// 新インスタンスを取得するゲッター
        /// </summary>
        public static MemoHolder Current { get; } = new MemoHolder();

        /// <summary>
        /// メモインスタンスを保持
        /// </summary>
        public Memo Memo { get; set; }

    }
}
