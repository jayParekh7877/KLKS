namespace RihnoMockDemo
{
    public class PlugInType2 : IPlugInType
    {
        public string GetPlugInName()
        {
            return "This is First PlugInType2";
        }

        public int Id { get { return 2; } set { } }
    }
}