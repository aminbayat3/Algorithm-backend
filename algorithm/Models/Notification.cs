namespace algorithm.Models
{
    public class Notification
    {
        public string NotificationToUser {  get; set; }
        public string CommandToWB { get; set; }

        public Notification(string commandToWb, string notificationToUser)
        {
            NotificationToUser = notificationToUser;
            CommandToWB = commandToWb;
        }
    }
}
