namespace SD_330_F22SD_Labs.Models
{
    public class Room
    {
        public int RoomNumber { get; set; }

        public int Capacity { get; set; }

        public Section Section { get; set; }
    }

    public enum Section
    {
        First,
        Second,
        Third
    }
}
