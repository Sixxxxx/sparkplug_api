using Microsoft.AspNetCore.Mvc;
using SparkPlug.Api.Controllers;
using SparkPlug.Models.Dtos;
using SparkPlug.Services.Interfaces;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FormController : BaseController
{
    private readonly IFormService _formService;

    public FormController(IFormService formService)
    {
        _formService = formService;
    }
   
    [HttpGet]
    public async Task<IActionResult> GetForms()
    {
        var forms =  await _formService.GetForms();
        return Ok(forms);
    }
        

    [HttpGet("{formId:length(24)}")]
    public async Task<IActionResult> GetForm(string formId)
    {
        var form = await _formService.GetForm(formId);
        return Ok(form);
    }

    [HttpPost]
    public async Task<IActionResult> CreateForm([FromForm]CreateCustomerFormDto newForm)
    {
        await _formService.CreateForm(newForm);
        return Ok();
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateForm([FromForm]UpdateCustomerFormDto updatedForm)
    {
        await _formService.UpdateForm(updatedForm);
        return Ok();
    }

    [HttpDelete("{formId:length(24)}")]
    public async Task<IActionResult> DeleteForm(string formId)
    {
        await _formService.DeleteForm(formId);
        return Ok();
    }
}