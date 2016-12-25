namespace PangeaPracticum.lib.Domain
{
    public class Permissions
    {
        public int Id { get; set; }
        public bool admin { get; set; }
        public bool push { get; set; }
        public bool pull { get; set; }
    }
}
