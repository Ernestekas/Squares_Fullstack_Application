﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SquaresWebApi.Dtos.PointsCollectionDtos;
using SquaresWebApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SquaresWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsCollectionController : ControllerBase
    {
        private readonly PointsCollectionsService _pointsCollectionService;

        public PointsCollectionController(PointsCollectionsService pointsCollectionService)
        {
            _pointsCollectionService = pointsCollectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<PointsCollectionGetDto> collectionsDto = await _pointsCollectionService.GetAllAsync();

            return Ok(collectionsDto);
        }
    }
}
