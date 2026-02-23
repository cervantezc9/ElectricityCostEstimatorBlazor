using Microsoft.EntityFrameworkCore;

namespace ElectricityCostEstimatorBlazor.Data
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            try
            {
                var dbContext = serviceProvider.GetRequiredService<ElectricityDbContext>();
                bool dbCreated = await dbContext.Database.EnsureCreatedAsync();

                // Call your custom seeding method
                if (dbCreated)
                {
                    await dbContext.Estimates.AddAsync(new()
                    {
                        IsActive = true,
                        ElectricityPlan = new()
                        {
                            Name = "TXU - Energy Saver",
                            BaseCharge = 9.99,
                            Credit = 30,
                            CreditMinimumUsage = 1200,
                            IsActive = true,
                            ElectricityPlanRates = [new() {
                            kWhMinimumUsage = 0,
                            kWhMaximumUsage = 1200,
                            Rate = 9.99,
                            IsActive = true
                        },
                        new (){
                            kWhMinimumUsage = 1201,
                            kWhMaximumUsage = 2000,
                            Rate = 6.99,
                            IsActive = true
                        },
                        new (){
                            kWhMinimumUsage = 2001,
                            Rate = 9.99,
                            IsActive = true
                        }]
                        },
                        Delivery = new()
                        {
                            ProviderName = "Centerpoint Energy",
                            MonthlyCharge = 4.99,
                            KWhCharge = 3.4589,
                            IsActive = true
                        },
                        MonthlyUsages = [new() {
                        Month = Models.Month.January,
                        Usage = 900
                    },
                    new() {
                        Month = Models.Month.February,
                        Usage = 900
                    },
                    new() {
                        Month = Models.Month.March,
                        Usage = 1000
                    },
                    new() {
                        Month = Models.Month.April,
                        Usage = 1100
                    },
                    new() {
                        Month = Models.Month.May,
                        Usage = 1200
                    },
                    new() {
                        Month = Models.Month.June,
                        Usage = 1400
                    },
                    new() {
                        Month = Models.Month.July,
                        Usage = 1800
                    },
                    new() {
                        Month = Models.Month.August,
                        Usage = 1800
                    },
                    new() {
                        Month = Models.Month.September,
                        Usage = 1700
                    },
                    new() {
                        Month = Models.Month.October,
                        Usage = 1600
                    },
                    new() {
                        Month = Models.Month.November,
                        Usage = 1200
                    },
                    new() {
                        Month = Models.Month.December,
                        Usage = 900
                    }]
                    });

                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Handle errors
                var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }
    }
}
