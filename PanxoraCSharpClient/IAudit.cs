using PanxoraCSharpClient.Models;

namespace PanxoraCSharpClient
{
    public interface IAudit
    {
        void Log(string auditMessage, object serialisableObject);
    }
}