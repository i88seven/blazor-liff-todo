using System;
namespace TodoBot.Shared
{
    public class Todo
    {
        /// <summary>
        /// レコードID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// ユーザーID。LIFFクライアントから取得したLINEに紐づくユーザーID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// ステータス
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// 期日
        /// </summary>
        public DateTime DueDate { get; set; }

        public Todo()
        {

        }

    }
}