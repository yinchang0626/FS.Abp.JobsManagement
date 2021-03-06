﻿using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;

namespace FS.Abp.JobsManagement.EntityFrameworkCore
{
    public class IdentityServerHostMigrationsDbContext : AbpDbContext<IdentityServerHostMigrationsDbContext>
    {
        public IdentityServerHostMigrationsDbContext(DbContextOptions<IdentityServerHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigurePermissionManagement();
            modelBuilder.ConfigureSettingManagement();
            modelBuilder.ConfigureAuditLogging();
            modelBuilder.ConfigureIdentity();
            modelBuilder.ConfigureIdentityServer();
            modelBuilder.ConfigureTenantManagement();
            modelBuilder.ConfigureBackgroundJobs();

            base.OnModelCreating(modelBuilder);
        }
    }
}
