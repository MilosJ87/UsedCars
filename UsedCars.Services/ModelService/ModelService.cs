using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCars.Entities;
using UsedCars.Models;
using UsedCars.Repository;

namespace UsedCars.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepo _modelRepo;

        private readonly IMapper _mapper;

        public ModelService(IModelRepo modelRepo, IMapper mapper)
        {
            _modelRepo = modelRepo ?? throw new ArgumentNullException(nameof(modelRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<MakeDto>> GetModels()
        {
            var models = await _modelRepo.GetAllAsync();
            var modelsToReturn = _mapper.Map<IEnumerable<MakeDto>>(models);
            return modelsToReturn;
        }

        public async Task<MakeDto> GetModel(Guid modelId)
        {
            var model = await _modelRepo.GetById(modelId);
            var modelToReturn = _mapper.Map<MakeDto>(model);
            return modelToReturn;
        }

        public async Task<MakeDto> CreateModel(MakeDto modelDto)
        {
            var modelToCreate = _mapper.Map<Model>(modelDto);
            _modelRepo.Insert(modelToCreate);
            _modelRepo.Save();
            var modelToReturn = _mapper.Map<MakeDto>(modelToCreate);
            return modelToReturn;

        }

        public async Task DeleteModel(Guid modelId)
        {
            var modelToDelete = _modelRepo.GetById(modelId);
            var deleteModel = _modelRepo.Delete(modelToDelete);
            _modelRepo.Save();
                       
        }
    }
}
