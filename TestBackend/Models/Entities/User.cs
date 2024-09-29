namespace TestBackend.Models.Entities
{
    public class User
    {
        /// <summary>
        /// ユーザーID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ユーザー名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ユーザーメアド
        /// </summary>
        public string Email { get; set; }
    }
}
