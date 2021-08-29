using AutoMapper;
using Core.Application.AppServices;
using Core.Domain.Interfaces.Repositories;
using Fruit.Application.Interfaces.AppServices;
using Fruit.Application.ViewModels;
using Fruit.Domain.Entities;
using Fruit.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Fruit.Application.AppServices
{
    internal class FruitAppService : AppServiceTransaction, IFruitAppService
    {
        private readonly IFruitService _fruitService;

        public FruitAppService(IUnitOfWorkTransaction coreUnitOfWorkTransaction, IMapper mapper, IFruitService fruitService, IHttpContextAccessor httpContextAccessor)
            : base(coreUnitOfWorkTransaction, mapper, httpContextAccessor)
        {
            _fruitService = fruitService;
        }

        public FruitListViewModel GetListViewModel()
        {
            var fruitList = _fruitService.GetFruitList();

            return new FruitListViewModel()
            {
                FruitList = this._mapper.Map<List<FruitTableItemViewModel>>(fruitList)
            };
        }

        public void Register(FruitViewModel fruitViewModel)
        {
            var entity = this._mapper.Map<FruitEntity>(fruitViewModel);
            _fruitService.Insert(entity);

            _coreUnitOfWorkTransaction.SaveChanges();
        }
    }
}