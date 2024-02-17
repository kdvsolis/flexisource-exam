using System;
using System.Collections.Generic;
using flexisource_exam.Exceptions;
using flexisource_exam.Interfaces;
using flexisource_exam.Models;
using flexisource_exam.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace flexisource_exam.Controllers
{
    public class RainfallController : Controller
    {
        private readonly IRainfallRepository _rainfallService;

        public RainfallController(IRainfallRepository rainfallService)
        {
            _rainfallService = rainfallService;
        }

        [HttpGet("id/{stationId}/readings")]
        public ActionResult<IEnumerable<RainfallReading>> GetRainfallReadings(string stationId, int count = 10)
        {
            try
            {
                var readings = _rainfallService.GetReadings(stationId, count);
                return Ok(readings);
            }
            catch (RainfallNotFoundException)
            {
                return NotFound(new ErrorResponse { Message = "No readings found for the specified stationId" });
            }
            catch (InvalidRequestException)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid request" });
            }
            catch (Exception)
            {
                return StatusCode(500, new ErrorResponse { Message = "Internal server error" });
            }
        }

        [HttpPost("id/{stationId}/readings")]
        public ActionResult AddRainfallReading(string stationId, [FromBody] RainfallReadingInputModel inputModel)
        {
            try
            {
                var newReading = _rainfallService.AddReading(stationId, inputModel);
                return CreatedAtAction(nameof(GetRainfallReadings), new { stationId }, newReading);
            }
            catch (InvalidRequestException)
            {
                return BadRequest(new ErrorResponse { Message = "Invalid request" });
            }
            catch (Exception)
            {
                return StatusCode(500, new ErrorResponse { Message = "Internal server error" });
            }
        }

    }
}
