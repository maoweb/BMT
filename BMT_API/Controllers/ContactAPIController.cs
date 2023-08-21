using AutoMapper;
using BMT_API.Data;
using BMT_API.Models;
using BMT_API.Models.Dto;
using BMT_API.Repository.IRepostiory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BMT_API.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/ContactAPI")]
    [ApiController]
    public class ContactAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IContactRepository _dbContact;
        private readonly IMapper _mapper;
        public ContactAPIController(IContactRepository dbContact, IMapper mapper)
        {
            _dbContact = dbContact;
            _mapper = mapper;
            this._response = new();
        }


        [HttpGet]
        
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetContacts([FromQuery] string? search)
        {
            try
            {

                IEnumerable<Contact> contactList = await _dbContact.GetAllAsync();

				if (!string.IsNullOrEmpty(search))
				{
					contactList = contactList.Where(u => 
                        u.Firstname.ToLower().Contains(search) ||
						u.Lastname.ToLower().Contains(search) ||
						u.CompanyName.ToLower().Contains(search) ||
						u.Mobile.ToLower().Contains(search) ||
						u.Email.ToLower().Contains(search)
					);
				}

				_response.Result = _mapper.Map<List<ContactDTO>>(contactList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;

        }
        
        [HttpGet("{id:int}", Name = "GetContact")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type =typeof(ContactDTO))]
        public async Task<ActionResult<APIResponse>> GetContact(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var contact = await _dbContact.GetAsync(u => u.Id == id);
                if (contact == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<ContactDTO>(contact);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateContact([FromBody] ContactCreateDTO createDTO)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}
                //if (await _dbContact.GetAsync(u => u.Firstname.ToLower() == createDTO.Firstname.ToLower()) != null)
                //{
                //    ModelState.AddModelError("ErrorMessages", "Contact already Exists!");
                //    return BadRequest(ModelState);
                //}

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                //if (contactDTO.Id > 0)
                //{
                //    return StatusCode(StatusCodes.Status500InternalServerError);
                //}
                Contact contact = _mapper.Map<Contact>(createDTO);

                //Contact model = new()
                //{
                //    Amenity = createDTO.Amenity,
                //    Details = createDTO.Details,
                //    ImageUrl = createDTO.ImageUrl,
                //    Name = createDTO.Name,
                //    Occupancy = createDTO.Occupancy,
                //    Rate = createDTO.Rate,
                //    Sqft = createDTO.Sqft
                //};
                await _dbContact.CreateAsync(contact);
                _response.Result = _mapper.Map<ContactDTO>(contact);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetContact", new { id = contact.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteContact")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<APIResponse>> DeleteContact(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var contact = await _dbContact.GetAsync(u => u.Id == id);
                if (contact == null)
                {
                    return NotFound();
                }
                await _dbContact.RemoveAsync(contact);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id:int}", Name = "UpdateContact")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateContact(int id, [FromBody] ContactUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                Contact model = _mapper.Map<Contact>(updateDTO);

                await _dbContact.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialContact")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialContact(int id, JsonPatchDocument<ContactUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var contact = await _dbContact.GetAsync(u => u.Id == id, tracked: false);

            ContactUpdateDTO contactDTO = _mapper.Map<ContactUpdateDTO>(contact);


            if (contact == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(contactDTO, ModelState);
            Contact model = _mapper.Map<Contact>(contactDTO);

            await _dbContact.UpdateAsync(model);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }


    }
}
