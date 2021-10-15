using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Models;

namespace U5CDCG_HFT_2021221.Data
{
    class CarsDbContext : DbContext
    {
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }

        public CarsDbContext()
        {
            this.Database.EnsureCreated();
        }

        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
               .UseLazyLoadingProxies()
               .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\U5CDCG_HFT_2021221_Database.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Cars car1 = new Cars() { Chassis_Number = 1, Type = "Astra", Produce_Year = 2009 };
            Cars car2 = new Cars() { Chassis_Number = 2, Type = "Multipla", Produce_Year = 1998 };
            Cars car3 = new Cars() { Chassis_Number = 3, Type = "6", Produce_Year = 2002 };
            Cars car4 = new Cars() { Chassis_Number = 4, Type = "Mondeo", Produce_Year = 2007 };
            Cars car5 = new Cars() { Chassis_Number = 5, Type = "Megane", Produce_Year = 2012 };
            Cars car6 = new Cars() { Chassis_Number = 6, Type = "Punto", Produce_Year = 2005 };
            Cars car7 = new Cars() { Chassis_Number = 7, Type = "RX-8", Produce_Year = 2006 };
            Cars car8 = new Cars() { Chassis_Number = 8, Type = "Vectra", Produce_Year = 2008 };
            Cars car9 = new Cars() { Chassis_Number = 9, Type = "Focus", Produce_Year = 2008 };
            Cars car10 = new Cars() { Chassis_Number = 10, Type = "Thalia", Produce_Year = 2001 };            

            Brands brand1 = new Brands() { Name = "Opel", Country = "Germany", Since = 1862 };
            Brands brand2 = new Brands() { Name = "Ford", Country = "USA", Since = 1903 };
            Brands brand3 = new Brands() { Name = "Fiat", Country = "Italy", Since = 1899 };
            Brands brand4 = new Brands() { Name = "Renault", Country = "France", Since = 1899 };
            Brands brand5 = new Brands() { Name = "Mazda", Country = "Japan", Since = 1920 };

            car1.Brand = brand1.Name;
            car2.Brand = brand3.Name;
            car3.Brand = brand5.Name;
            car4.Brand = brand2.Name;
            car5.Brand = brand4.Name;
            car6.Brand = brand3.Name;
            car7.Brand = brand5.Name;
            car8.Brand = brand1.Name;
            car9.Brand = brand2.Name;
            car10.Brand = brand4.Name;

            Owner owner1 = new Owner() { Name = "John Doe", HasInsurance = true, PhoneNumber = 5557689 };
            Owner owner2 = new Owner() { Name = "Stan Smith", HasInsurance = true, PhoneNumber = 5558653 };
            Owner owner3 = new Owner() { Name = "Woody Johnson", HasInsurance = false, PhoneNumber = 5559152 };
            Owner owner4 = new Owner() { Name = "Lois Griffin", HasInsurance = true, PhoneNumber = 5552314 };
            Owner owner5 = new Owner() { Name = "Nick Grabowski", HasInsurance = true, PhoneNumber = 5551402 };
            Owner owner6 = new Owner() { Name = "Kyle Broflovski", HasInsurance = false, PhoneNumber = 5556184 };
            Owner owner7 = new Owner() { Name = "Sterling Archer", HasInsurance = true, PhoneNumber = 5551323 };
            Owner owner8 = new Owner() { Name = "Homer Simpson", HasInsurance = true, PhoneNumber = 5553219 };
            Owner owner9 = new Owner() { Name = "Philip J. Fry", HasInsurance = false, PhoneNumber = 5551235 };
            Owner owner10 = new Owner() { Name = "Hank Hill", HasInsurance = true, PhoneNumber = 5555125 };

            owner1.Car_Identifier = car2.Chassis_Number;
            owner2.Car_Identifier = car4.Chassis_Number;
            owner3.Car_Identifier = car6.Chassis_Number;
            owner4.Car_Identifier = car8.Chassis_Number;
            owner5.Car_Identifier = car10.Chassis_Number;
            owner6.Car_Identifier = car1.Chassis_Number;
            owner7.Car_Identifier = car3.Chassis_Number;
            owner8.Car_Identifier = car5.Chassis_Number;
            owner9.Car_Identifier = car7.Chassis_Number;
            owner10.Car_Identifier = car9.Chassis_Number;

            modelBuilder.Entity<Cars>().HasData(car1, car2, car3, car4, car4, car5, car6, car7, car8, car9, car10);
            modelBuilder.Entity<Owner>().HasData(owner1, owner2, owner3, owner4, owner5, owner6, owner7, owner8, owner9, owner10);
            modelBuilder.Entity<Brands>().HasData(brand1, brand2, brand3, brand4, brand5);
        }
    }
}
