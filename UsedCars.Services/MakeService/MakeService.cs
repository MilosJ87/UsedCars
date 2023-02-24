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
    public class MakeService : IMakeService
    {
        private readonly IMakeRepo _makeRepo;

        private readonly IMapper _mapper;

        public MakeService(IMakeRepo makeRepo, IMapper mapper)
        {
            _makeRepo = makeRepo ?? throw new ArgumentNullException(nameof(makeRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<MakeDto>> GetMakes()
        {
            var makes = await _makeRepo.GetAllAsync();
            var makesToReturn = _mapper.Map<IEnumerable<MakeDto>>(makes);
            return makesToReturn;
        }

        public async Task<MakeDto> GetMake(Guid makeId)
        {
            var make = await _makeRepo.GetById(makeId);
            var makesToReturn = _mapper.Map<MakeDto>(make);
            return makesToReturn;
        }

        public async Task<MakeDto> CreateMake(MakeDto makeDto)
        {
            var makeToCreate = _mapper.Map<Make>(makeDto);
            _makeRepo.Insert(makeToCreate);
            _makeRepo.Save();
            var makeToReturn = _mapper.Map<MakeDto>(makeToCreate);
            return makeToReturn;

        }

        public async Task DeleteMake(Guid makeId)
        {
            var makeToDelete = _makeRepo.GetById(makeId);
            var deleteModel = _makeRepo.Delete(makeToDelete);
            _makeRepo.Save();

        }
    }
}

