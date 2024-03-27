using DesafioBackend.Mottu.DTO.MotorcylesRental;
using DesafioBackend.Mottu.Entities.DeliveryPersons;
using DesafioBackend.Mottu.Entities.MotorcyclesRental;
using DesafioBackend.Mottu.Interface;
using DesafioBackend.Mottu.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace DesafioBackend.Mottu.Services
{
    public class MotorcycleRentalAppService : CrudAppService<MotorcycleRental, MotorcycleRentalDto, Guid, 
                                              PagedAndSortedResultRequestDto, CreateUpdateMotorcycleRentalDto, MotorcycleRentalDto>, IMotorcycleRentalAppService
    {
        private readonly IRepository<DeliveryPerson, Guid> _deliveryPersonRepository;

        public MotorcycleRentalAppService(IRepository<MotorcycleRental, Guid> repository,
                                          IRepository<DeliveryPerson, Guid> deliveryPersonRepository) : base(repository)
        {
            GetPolicyName = MottuPermissions.MotorcycleRental.Default;
            GetListPolicyName = MottuPermissions.MotorcycleRental.Default;
            CreatePolicyName = MottuPermissions.MotorcycleRental.Create;
            UpdatePolicyName = MottuPermissions.MotorcycleRental.Update;
            DeletePolicyName = MottuPermissions.MotorcycleRental.Delete;

            _deliveryPersonRepository = deliveryPersonRepository;
        }

        [Authorize(MottuPermissions.MotorcycleRental.CompleteRental)]
        public async Task<MotorcycleRentalDto> CompleteRentalAsync(Guid id, DateTime returnDate)
        {
            var rental = await Repository.GetAsync(id);

            var deliveryPerson = await _deliveryPersonRepository.GetAsync(rental.DeliveryPersonId);

            if (deliveryPerson.CnhType != "A")
            {
                throw new BusinessException(L["Error:MotorcycleRentalCNHType"]);
            }

            rental.CompleteRental(returnDate);

            await Repository.UpdateAsync(rental);

            return ObjectMapper.Map<MotorcycleRental, MotorcycleRentalDto>(rental);
        }
    }
}