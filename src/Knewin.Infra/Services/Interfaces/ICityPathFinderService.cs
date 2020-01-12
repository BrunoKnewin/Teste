using System.Collections.Generic;

namespace Knewin.Infra.Services.Interfaces
{
    public interface ICityPathFinderService
    {
        long[] GetOnePath(long from, long to);
    }
}
