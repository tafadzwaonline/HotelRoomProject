namespace HiddenVilla_Server.Model
{
    public class BlazorRoom
    {
        public int ID { get; set; }

        public string RoomName { get; set; }

        public double Price { get; set; }

        public bool IsActive { get; set; }

        public List<BlazorRoomProp> RoomProps { get; set; }
    }
}
