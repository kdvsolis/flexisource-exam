
using System;
using System.Collections.Generic;
using flexisource_exam.Interfaces;
using flexisource_exam.Models;

namespace flexisource_exam.Repositories
{
    public class InMemoryRainfallRepository : IRainfallRepository
    {
        private readonly List<RainfallReading> _readings = new List<RainfallReading>();

        public IEnumerable<RainfallReading> GetReadings(string stationId, int count)
        {
            // Implement logic to retrieve readings from the in-memory collection
            // based on stationId and count.
            // For example:
            return _readings
                .Where(r => r.StationId == stationId)
                .OrderByDescending(r => r.DateMeasured)
                .Take(count);
        }

        public RainfallReading AddReading(string stationId, RainfallReadingInputModel inputModel)
        {
            var newReading = new RainfallReading
            {
                StationId = stationId,
                DateMeasured = inputModel.DateMeasured,
                AmountMeasured = inputModel.AmountMeasured
            };

            _readings.Add(newReading);
            return newReading;
        }
    }
}
