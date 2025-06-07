using BadmintonHub.Dtos.FieldDtos;
using BadmintonHub.Models;

namespace BadmintonHub.Services.Interfaces
{
    public interface IFieldService
    {
        public Task<List<FieldClosure>> GetCloseDates();
        public Task AddCloseDate(FieldClosure data);
        public Task UpdateClosedDate(FieldClosure data);
    }
}
