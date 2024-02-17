using flexisource_exam.Models;
using System.Collections.Generic;

namespace flexisource_exam.Interfaces
{
    public interface IRainfallRepository
    {
        IEnumerable<RainfallReading> GetReadings(string stationId, int count);
        RainfallReading AddReading(string stationId, RainfallReadingInputModel inputModel);
    }
}
