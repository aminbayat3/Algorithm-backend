namespace algorithm.Models
{
    public class Notification
    {
        public string NotificationToUser {  get; set; }
        public string CommandToWB { get; set; }

        public Notification(string notificationToUser, string commandToWb) 
        {
            NotificationToUser = notificationToUser;
            CommandToWB = commandToWb;
        }
    }
}
