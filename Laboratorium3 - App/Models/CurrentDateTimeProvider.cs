namespace Laboratorium3___App.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
