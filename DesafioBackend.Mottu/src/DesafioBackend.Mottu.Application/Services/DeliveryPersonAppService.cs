using DesafioBackend.Mottu.DTO.DeliveryPersons;
using DesafioBackend.Mottu.Entities.DeliveryPersons;
using DesafioBackend.Mottu.Interface;
using DesafioBackend.Mottu.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace DesafioBackend.Mottu.Services
{
    public class DeliveryPersonAppService : CrudAppService<DeliveryPerson, DeliveryPersonDto, Guid, PagedAndSortedResultRequestDto, 
                                            CreateUpdateDeliveryPersonDto, CreateUpdateDeliveryPersonDto>, IDeliveryPersonAppService
    {
        private readonly ILocalFileStorageService _fileStorageService;

        public DeliveryPersonAppService(IRepository<DeliveryPerson, Guid> repository,
                                        ILocalFileStorageService fileStorageService) : base(repository)
        {
            _fileStorageService = fileStorageService;

            GetPolicyName = MottuPermissions.DeliveryPerson.Default;
            GetListPolicyName = MottuPermissions.DeliveryPerson.Default;
            CreatePolicyName = MottuPermissions.DeliveryPerson.Create;
            UpdatePolicyName = MottuPermissions.DeliveryPerson.Update;
            DeletePolicyName = MottuPermissions.DeliveryPerson.Delete;
        }

        [Authorize(MottuPermissions.DeliveryPerson.UpdateCnhImage)]
        public async Task<DeliveryPersonDto> UpdateCnhImageAsync(Guid id, byte[] cnhImage)
        {
            var deliveryPerson = await Repository.GetAsync(id);

            // replace special characters in the CNH number to avoid conflicts in the file system
            var safeCnhNumber = deliveryPerson.CnhNumber.Replace("/", "_").Replace("\\", "_");

            // filename generated with a GUID to avoid conflicts.
            var fileName = $"{id}_{safeCnhNumber}_{Guid.NewGuid()}.png";

            // store the image in the file system
            var filePath = await _fileStorageService.SaveCnhImageAsync(cnhImage, fileName);

            // update path in the database
            // only the file name is stored in the database to simplify the implementation
            deliveryPerson.UpdateCnhImageType(Path.GetFileName(filePath));

            await Repository.UpdateAsync(deliveryPerson);

            return ObjectMapper.Map<DeliveryPerson, DeliveryPersonDto>(deliveryPerson);
        }
    }
}