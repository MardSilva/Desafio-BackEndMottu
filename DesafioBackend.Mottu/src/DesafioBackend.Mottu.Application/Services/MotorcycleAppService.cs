using DesafioBackend.Mottu.DTO.Motorcycles;
using DesafioBackend.Mottu.Entities.Motorcycles;
using DesafioBackend.Mottu.Interface;
using DesafioBackend.Mottu.Permissions;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace DesafioBackend.Mottu.Services
{
    public class MotorcycleAppService : CrudAppService<Motorcycle, MotorcycleDto, Guid, 
                                        PagedAndSortedResultRequestDto, CreateUpdateMotorcycleDto>, IMotorcycleAppService
    {
        public MotorcycleAppService(IRepository<Motorcycle, Guid> repository) : base(repository)
        {
            GetPolicyName = MottuPermissions.Motorcycle.Default;
            GetListPolicyName = MottuPermissions.Motorcycle.Default;
            CreatePolicyName = MottuPermissions.Motorcycle.Create;
            UpdatePolicyName = MottuPermissions.Motorcycle.Update;
            DeletePolicyName = MottuPermissions.Motorcycle.Delete;
        }

        public async Task<MotorcycleDto> GetByLicensePlateAsync(string licensePlate)
        {
            var motorcylce = await Repository.FirstOrDefaultAsync(x => x.LicensePlate == licensePlate);

            return motorcylce == null ? 
                   throw new EntityNotFoundException(typeof(Motorcycle), licensePlate) : ObjectMapper.Map<Motorcycle, MotorcycleDto>(motorcylce);
        }

        public async Task<MotorcycleDto> UpdateLicensePlateAsync(Guid motorcycleId, string newLicensePlate)
        {
            //check policy
            await CheckPolicyAsync(MottuPermissions.Motorcycle.Update);

            // find the motorcycle
            var motorcycle = await Repository.GetAsync(motorcycleId);
            if (motorcycle == null)
            {
                throw new EntityNotFoundException(typeof(Motorcycle), motorcycleId);
            }

            // check if the new license plate is already in use
            var existingMotorcycle = await Repository.FirstOrDefaultAsync(m => m.LicensePlate == newLicensePlate);
            
            if (existingMotorcycle != null && existingMotorcycle.Id != motorcycleId)
            {
                throw new BusinessException(L["Error:LicensePlateAlreadyExists"]);
            }

            // update the license plate
            motorcycle.UpdateLicensePlate(newLicensePlate);

            // store the changes
            await Repository.UpdateAsync(motorcycle);

            return ObjectMapper.Map<Motorcycle, MotorcycleDto>(motorcycle);
        }
    }
}