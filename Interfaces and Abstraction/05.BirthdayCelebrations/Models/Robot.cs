using _05.BirthdayCelebrations.Interfaces;

namespace _05.BirthdayCelebrations.Models
{
    public class Robot : IRobot
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
        public string Id { get; }
        public string Model { get; }
    }
}
