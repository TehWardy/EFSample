namespace B2B.Objects
{
    public class B2BConfiguration
    {
        public string RootPath { get; set; }
        public int MaxDbConnections { get; set; } = 5000;
        public bool LogSQL { get; set; }
    }
}