using SparkPlug.Models.Dtos;
using SparkPlug.Models.Dtos.Response;
using SparkPlug.Models.Entities;

namespace SparkPlug.Services.Interfaces
{
    public interface IFormService
    {
        public Task<IEnumerable<CustomerFormResponseDto>> GetForms();
        public Task<CustomerFormResponseDto> GetForm(string FormId);
        public Task CreateForm(CreateCustomerFormDto newForm);
        public Task UpdateForm(UpdateCustomerFormDto updateDto);
        public Task DeleteForm(string FormId);
    }
}
