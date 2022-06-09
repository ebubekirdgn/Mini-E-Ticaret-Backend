﻿using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private  IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name="Urun 1",Price=1000,CreatedDate=DateTime.UtcNow,Stock=10},
                new() { Id = Guid.NewGuid(), Name="Urun 2",Price=2000,CreatedDate=DateTime.UtcNow,Stock=20},
                new() { Id = Guid.NewGuid(), Name="Urun 3",Price=3000,CreatedDate=DateTime.UtcNow,Stock=30},
            });
            await _productWriteRepository.SaveAsync();
        }
    }
}