namespace MailAttachementsTest.Options
{
    /// <summary>
    /// Опции электронной почты
    /// </summary>
    public class EmailOptions
    {
        /// <summary>
        /// Хост
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Порт
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Почтовый адрес
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Кол-во последних сообщений для просмотра
        /// </summary>
        public int LastMessagesCount { get; set; }
    }
}
