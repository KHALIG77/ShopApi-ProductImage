﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Services.DTOs.BrandDTOs;
using Shop.Core.Entities;
using Shop.Core.Repositories;
using Shop.Data;
using Shop.Services.Interfaces;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            
            
            _brandService = brandService;
        }
        [HttpPost("")]
        public ActionResult<BrandPostDTO> Create(BrandPostDTO brandPostDTO)
        {
           var data= _brandService.Create(brandPostDTO);

            return StatusCode(201,data.Id );
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id,BrandPutDTO brandPutDTO)
        {
           _brandService.Edit(id,brandPutDTO);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           _brandService.Delete(id);
            return NoContent();
        }
        [HttpGet("all")]
        public ActionResult<List<BrandGetAllItemDTO>> GetAll()
        {
            var data=_brandService.GetAll();
            return Ok(data);
        }

    }
}
