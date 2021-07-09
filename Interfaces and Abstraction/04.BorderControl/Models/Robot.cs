using _04.BorderControl.Interfaces;

namespace _04.BorderControl.Models
{
    public class Robot : IRobot
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
        public string Id { get; }
        public string Model { get; set; }
    }
}
