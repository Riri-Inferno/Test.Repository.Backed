using System.ComponentModel.DataAnnotations;

namespace TestBackend.Models.Entities
{
    /// <summary>
    /// ユーザ情報エンティティ
    /// </summary>
    public class User
    {
        /// <summary>
        /// ユーザーID
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// ユーザー名
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// メールアドレス
        /// </summary>
        /// [Required]
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
    }
}
