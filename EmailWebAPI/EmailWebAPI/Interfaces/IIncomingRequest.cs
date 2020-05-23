using System.Collections.Generic;

namespace EmailWebAPI.Interfaces
{
    public interface IIncomingRequest
    {
        List<string> CreateList { get; }
    }
}


