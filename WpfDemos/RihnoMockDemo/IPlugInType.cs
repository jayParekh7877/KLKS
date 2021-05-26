using System.Security.Cryptography.X509Certificates;

namespace RihnoMockDemo
{
    public interface IPlugInType
    {
        int Id { get; set; }
        string GetPlugInName();
    }
}