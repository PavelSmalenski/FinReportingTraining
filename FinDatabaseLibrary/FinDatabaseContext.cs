using FinDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinDatabase;

public class FinDatabaseContext : DbContext
{
    string _connectionString;

    public DbSet<User> Users { get; set; }

    public DbSet<Company> Companies { get; set; } = null!;

    public DbSet<CompanyControl> CompanyControls { get; set; } = null!;

    public DbSet<Account> Accounts { get; set; } = null!;

    public DbSet<Center> Centers { get; set; } = null!;

    public DbSet<CenterControl> CenterControls { get; set; } = null!;

    public DbSet<CurrentYearEndingBalance> CurrentYearEndingBalances { get; set; } = null!;

    public DbSet<CurrentYearAggregate> CurrentYearAggregates { get; set; } = null!;

    public DbSet<WeekDailyActivity> WeekDailyActivities { get; set; } = null!;

    public DbSet<OpenPeriodEndingBalance> OpenPeriodEndingBalances { get; set; } = null!;

    public DbSet<OpenPeriodAggregte> OpenPeriodAggregtes { get; set; } = null!;

    public FinDatabaseContext(IConfiguration configuration, string connectionStringName = "Default", bool isForceCreate = false)
    {
        _connectionString = configuration.GetConnectionString(connectionStringName)
                            ?? throw new ArgumentException($"No connection string with name {connectionStringName} found in configuration");

        if (isForceCreate)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureCompanyEntities(modelBuilder);
        ConfigureControlEntities(modelBuilder);
        ConfigureAuthEntities(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    void ConfigureCompanyEntities(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
                    .Property((comp) => comp.Id)
                    .ValueGeneratedNever();

        modelBuilder.Entity<Account>()
                    .HasKey((acc) => new { acc.CompanyId, acc.Id });
        // modelBuilder.Entity<Account>()
        //             .HasOne(acc => acc.Company)
        //             .WithMany(comp => comp.Accounts)
        //             .HasForeignKey(acc => acc.CompanyId);

        modelBuilder.Entity<Center>()
                    .HasKey((cent) => new { cent.CompanyId, cent.AccountId, cent.Id });
        modelBuilder.Entity<Center>()
                    .HasOne(cent => cent.Account)
                    .WithMany(acc => acc.Centers)
                    .HasForeignKey(cent => new { cent.CompanyId, cent.AccountId });

        modelBuilder.Entity<CurrentYearEndingBalance>()
                    .HasKey((bal) => new { bal.CompanyId, bal.AccountId, bal.CenterId });
        modelBuilder.Entity<CurrentYearEndingBalance>()
                    .HasOne(bal => bal.Center)
                    .WithMany(cent => cent.CurrentYearEndingBalances)
                    .HasForeignKey(bal => new { bal.CompanyId, bal.AccountId, bal.CenterId });

        modelBuilder.Entity<CurrentYearAggregate>()
                    .HasKey((ag) => new { ag.CompanyId, ag.AccountId, ag.CenterId });
        modelBuilder.Entity<CurrentYearAggregate>()
                    .HasOne(ag => ag.Center)
                    .WithMany(cent => cent.CurrentYearAggregates)
                    .HasForeignKey(ag => new { ag.CompanyId, ag.AccountId, ag.CenterId });

        modelBuilder.Entity<WeekDailyActivity>()
                    .HasKey((wd) => new { wd.CompanyId, wd.AccountId, wd.CenterId, wd.WeekId });
        modelBuilder.Entity<WeekDailyActivity>()
                    .HasOne(wd => wd.Center)
                    .WithMany(cent => cent.WeekDailyActivities)
                    .HasForeignKey(wd => new { wd.CompanyId, wd.AccountId, wd.CenterId });

        modelBuilder.Entity<OpenPeriodEndingBalance>()
                    .HasKey((bal) => new { bal.CompanyId, bal.AccountId, bal.CenterId });
        modelBuilder.Entity<OpenPeriodEndingBalance>()
                    .HasOne(bal => bal.Center)
                    .WithMany(cent => cent.OpenPeriodEndingBalances)
                    .HasForeignKey(bal => new { bal.CompanyId, bal.AccountId, bal.CenterId });

        modelBuilder.Entity<OpenPeriodAggregte>()
                    .HasKey((ag) => new { ag.CompanyId, ag.AccountId, ag.CenterId });
        modelBuilder.Entity<OpenPeriodAggregte>()
                    .HasOne(ag => ag.Center)
                    .WithMany(cent => cent.OpenPeriodAggregtes)
                    .HasForeignKey(ag => new { ag.CompanyId, ag.AccountId, ag.CenterId });
    }

    void ConfigureControlEntities(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyControl>()
                    .HasKey(rec => rec.CompanyId);
        modelBuilder.Entity<CompanyControl>()
                    .Property(rec => rec.CompanyId)
                    .ValueGeneratedNever();

        modelBuilder.Entity<CenterControl>()
                    .HasKey(rec => rec.CenterId);
        modelBuilder.Entity<CenterControl>()
                    .Property(rec => rec.CenterId)
                    .ValueGeneratedNever();
    }

    void ConfigureAuthEntities(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
                    .HasKey(rec => rec.Name);
    }
}