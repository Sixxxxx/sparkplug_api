using AutoMapper;
using MongoDB.Driver;
using SparkPlug.Models.Dtos;
using SparkPlug.Models.Dtos.Response;
using SparkPlug.Models.Entities;
using SparkPlug.Services.Infrastructures;
using SparkPlug.Services.Interfaces;

namespace SparkPlug.Services.Implementation
{
    public class FormService : IFormService
    {
        private readonly IMongoCollection<CustomerForm> _formCollection;
        private readonly IMapper _mapper;
      
        private readonly DatabaseSettings _databaseSettings;

        public FormService(DatabaseSettings databaseSettings, IMongoClient mongoClient, IMapper mapper)
        {
            _databaseSettings = databaseSettings;
            var database = mongoClient.GetDatabase(_databaseSettings.DatabaseName);
            _formCollection = database.GetCollection<CustomerForm>(_databaseSettings.FormsCollectionName);
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerFormResponseDto>> GetForms()
        {
            var forms = await _formCollection.Find(_ => true).ToListAsync();
            var formData = _mapper.Map<IEnumerable<CustomerFormResponseDto>>(forms);
            return formData;
        }
                  

        public async Task<CustomerFormResponseDto> GetForm(string FormId)
        {
            var form = await _formCollection.Find(x => x.Id == FormId).FirstOrDefaultAsync();

            if (form == null)
            {
                throw new ArgumentException("Invalid FormId");
            }
            var formData = _mapper.Map<CustomerFormResponseDto>(form);
            return formData;
        }
            

        public async Task CreateForm(CreateCustomerFormDto newForm)
        {
            var form = _mapper.Map<CustomerForm>(newForm);
            await _formCollection.InsertOneAsync(form);
            return;
        } 
            

        public async Task UpdateForm(UpdateCustomerFormDto updateDto)
        {
            var form = await _formCollection.Find(x => x.Id == updateDto.Id).FirstOrDefaultAsync();
            if (form == null)
            {
                throw new ArgumentException("Invalid FormId");
            }
            var formToUpdate = _mapper.Map(updateDto, form);
            await _formCollection.ReplaceOneAsync(x => x.Id == updateDto.Id, formToUpdate);
            return;
        } 

        public async Task DeleteForm(string FormId)
        {
            var form = await _formCollection.Find(x => x.Id == FormId).FirstOrDefaultAsync();
            if (form == null)
            {
                throw new ArgumentException("Invalid FormId");
            }
            await _formCollection.DeleteOneAsync(x => x.Id == FormId);
            return;
        }
            
    }
}
