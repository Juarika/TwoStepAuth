using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserController
        (
            ILogger<UserController> logger,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<User>> Post([FromBody] RegisterDto userRegister)
    {
        var user = _mapper.Map<User>(userRegister);
        _unitOfWork.Users.Add(user);
        await _unitOfWork.SaveAsync();
        if (user == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new { id = user.Id }, user);
    }

    [HttpGet("GenerateSMS/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> SendSMS(int id)
    {
        try
        {
            User user = await _unitOfWork.Users.FindFirst(p => p.Id == id);
            TwilioHelper twilio = new TwilioHelper();
            twilio.SendSMSMessage(user.Phone, user.TwoSecret);
            return Ok("Message sent succesfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest("error, some error occurred");
        }
    }
    [HttpPost("ValidateSMS")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ValidateSMS([FromBody] ValidateDto validateDto)
    {
        try
        {
            User user = await _unitOfWork.Users.FindFirst(p => p.Id == validateDto.Id);
            if (user.TwoSecret == validateDto.Code)
            {
                string newTwoSecret = _unitOfWork.Users.GenerateRandomTwoSecret();
                user.TwoSecret = newTwoSecret;
                _unitOfWork.Users.Update(user);
                await _unitOfWork.SaveAsync();
                return Ok("Verified User.");
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest("error, some error occurred");
        }
    }
}