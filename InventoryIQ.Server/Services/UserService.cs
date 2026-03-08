using System;
using InventoryIQ.Server.Data;
using InventoryIQ.Server.Dtos;
using InventoryIQ.Server.Entities;
using Microsoft.AspNetCore.Identity;

namespace InventoryIQ.Server.Services;

public class UserService(InventoryIqContext context)
{
    private readonly InventoryIqContext _context = context;
    private static readonly UserEntities user = new();

    public async Task<UserEntities> AddUser(UserDto userDto)
    {
        if (userDto.Password != userDto.ConfirmPassword)
            throw new ArgumentException("Password does not match ConfirmPassword");
        
        var hashPassword = new PasswordHasher<UserEntities>().HashPassword(user,userDto.Password!);
        var hashConfirmPassword = new PasswordHasher<UserEntities>().HashPassword(user,userDto.ConfirmPassword!);
        var users = new UserEntities
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            Password = hashPassword,
            ConfirmPassword = hashConfirmPassword,
            Role = userDto.Role,
            CreatedAt = DateTime.UtcNow
        };
        
        _context.Add(users);
        await _context.SaveChangesAsync();
        return users;
    }
}
