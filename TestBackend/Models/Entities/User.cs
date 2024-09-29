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
        public string Name { get; set; }

        /// <summary>
        /// メールアドレス
        /// </summary>
        /// [Required]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
