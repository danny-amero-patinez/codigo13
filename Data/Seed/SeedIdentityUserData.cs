using backendnet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backendnet.Data.Seed;

public static class SeedIdentityUserData
{
    public static void SeedUserIdentityData(this ModelBuilder modelBuilder)
    {
        string AdministradorRoleId = Guid.NewGuid().ToString();
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = AdministradorRoleId,
                Name = "Administrador",
                NormalizedName = "Administrador".ToUpper()
            });

        string UsuarioRoleId = Guid.NewGuid().ToString();
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = UsuarioRoleId,
                Name = "Usuario",
                NormalizedName = "Usuario".ToUpper()
            });

        var UsuarioId = Guid.NewGuid().ToString();
        modelBuilder.Entity<CustomIdentityUser>().HasData(
            new CustomIdentityUser
            {
                Id = UsuarioId,
                UserName = "sirrobert1@gmail.com",
                Email = "sirrobert1@gmail.com",
                NormalizedEmail = "sirrobert1@gmail.com".ToUpper(),
                Nombre = "Roberto Viveros",
                NormalizedUserName = "sirrobert1@gmail.com".ToUpper(),
                PasswordHash = new PasswordHasher<CustomIdentityUser>().HashPassword(null!, "gatito123"),
                Protegido = true
            });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = AdministradorRoleId,
                UserId = UsuarioId
            });

        UsuarioId = Guid.NewGuid().ToString();
        modelBuilder.Entity<CustomIdentityUser>().HasData(
            new CustomIdentityUser
            {
                Id = UsuarioId,
                UserName = "gatito@uv.mx",
                Email = "gatito@uv.mx",
                NormalizedEmail = "gatito@uv.mx".ToUpper(),
                Nombre = "Gatito",
                NormalizedUserName = "gatito@uv.mx".ToUpper(),
                PasswordHash = new PasswordHasher<CustomIdentityUser>().HashPassword(null!, "gatito"),
            });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = UsuarioRoleId,
                UserId = UsuarioId
            });
    }

}