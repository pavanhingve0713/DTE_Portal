using System;
using System.Collections.Generic;
using HRMS.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace TechnicalEducationPortal.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<MstState> MstStates { get; set; }
    public virtual DbSet<MstDivision> MstDivisions { get; set; }
    public virtual DbSet<MstDistrict> MstDistricts { get; set; }   
    public virtual DbSet<MstBlock> MstBlocks { get; set; }   
    public virtual DbSet<UserDetail> UserDetails { get; set; }
    public virtual DbSet<MstReligion> MstReligions { get; set; }
    public virtual DbSet<MstCaste> MstCastes { get; set; }
    public virtual DbSet<MstPostType> MstPostTypes { get; set; }
    public virtual DbSet<MstBloodGroup> MstBloodGroups { get; set; }
    public virtual DbSet<MstDesignationType> MstDesignationTypes { get; set; }
    public virtual DbSet<MstBoard> MstBoards { get; set; }
    public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }
    public virtual DbSet<MstParliamentary> MstParliamentaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
