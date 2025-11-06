using Employee.shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await checkEmployeesAsync();
            await CheckCountriesFullAsync();
        }
        private async Task CheckCountriesFullAsync()
        {
            if (!_context.Countries.Any())
            {
                var countriesSQLScript = File.ReadAllText("Data\\CountriesStatesCities.sql");
                await _context.Database.ExecuteSqlRawAsync(countriesSQLScript);
            }
        }

        private async Task checkEmployeesAsync()
        {
            if (!_context.Employees.Any())
            {
                _context.Employees.Add(new EmployeeBD { FirstName = "Adriana", LastName = "Rincon", IsActive = true, HireDate = new DateTime(2019, 8, 11), Salary = 2950000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Adriana", LastName = "Vega", IsActive = true, HireDate = new DateTime(2020, 6, 4), Salary = 3100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Adriana", LastName = "Cifuentes", IsActive = true, HireDate = new DateTime(2021, 7, 21), Salary = 3250000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Alejandro", LastName = "Cruz", IsActive = true, HireDate = new DateTime(2022, 1, 25), Salary = 3300000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Alejandro", LastName = "Rueda", IsActive = true, HireDate = new DateTime(2020, 10, 19), Salary = 3500000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Alejandro", LastName = "Gonzalez", IsActive = true, HireDate = new DateTime(2018, 12, 12), Salary = 3600000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Beatriz", LastName = "Santos", IsActive = true, HireDate = new DateTime(2019, 7, 16), Salary = 4200000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Beatriz", LastName = "Ramirez", IsActive = true, HireDate = new DateTime(2022, 5, 18), Salary = 3900000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Beatriz", LastName = "Suarez", IsActive = true, HireDate = new DateTime(2021, 9, 23), Salary = 4050000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Camila", LastName = "Mendoza", IsActive = true, HireDate = new DateTime(2023, 1, 10), Salary = 3200000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Camila", LastName = "Rios", IsActive = true, HireDate = new DateTime(2020, 2, 5), Salary = 3400000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Camila", LastName = "Garzon", IsActive = true, HireDate = new DateTime(2021, 10, 28), Salary = 3650000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Daniela", LastName = "Jimenez", IsActive = true, HireDate = new DateTime(2021, 9, 27), Salary = 3600000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Daniela", LastName = "Vallejo", IsActive = true, HireDate = new DateTime(2021, 8, 9), Salary = 3400000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Daniela", LastName = "Forero", IsActive = true, HireDate = new DateTime(2020, 4, 12), Salary = 3550000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Edgar", LastName = "Pardo", IsActive = true, HireDate = new DateTime(2023, 9, 5), Salary = 2800000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Edgar", LastName = "Mora", IsActive = true, HireDate = new DateTime(2020, 3, 18), Salary = 3100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Edgar", LastName = "Navarro", IsActive = true, HireDate = new DateTime(2022, 6, 14), Salary = 3350000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Fernando", LastName = "Giraldo", IsActive = true, HireDate = new DateTime(2021, 3, 30), Salary = 3150000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Fernando", LastName = "Sierra", IsActive = true, HireDate = new DateTime(2020, 8, 5), Salary = 3450000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Fernando", LastName = "Velasquez", IsActive = true, HireDate = new DateTime(2022, 12, 11), Salary = 3600000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Gabriela", LastName = "Nieto", IsActive = true, HireDate = new DateTime(2021, 10, 15), Salary = 3700000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Gabriela", LastName = "Cuellar", IsActive = true, HireDate = new DateTime(2023, 2, 22), Salary = 3950000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Gabriela", LastName = "Cano", IsActive = true, HireDate = new DateTime(2020, 4, 8), Salary = 4100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Hector", LastName = "Trujillo", IsActive = true, HireDate = new DateTime(2019, 10, 9), Salary = 4450000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Hector", LastName = "Ramos", IsActive = true, HireDate = new DateTime(2021, 11, 10), Salary = 4300000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Hector", LastName = "Gomez", IsActive = true, HireDate = new DateTime(2022, 9, 9), Salary = 4500000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Isabella", LastName = "Patino", IsActive = true, HireDate = new DateTime(2020, 10, 19), Salary = 3100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Isabella", LastName = "Vargas", IsActive = true, HireDate = new DateTime(2021, 3, 5), Salary = 3250000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Isabella", LastName = "Ochoa", IsActive = true, HireDate = new DateTime(2022, 7, 18), Salary = 3400000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Juan", LastName = "Perez", IsActive = true, HireDate = new DateTime(2021, 5, 10), Salary = 3500000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Juan", LastName = "Gomez", IsActive = true, HireDate = new DateTime(2020, 8, 22), Salary = 4200000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Juan", LastName = "Rodriguez", IsActive = true, HireDate = new DateTime(2022, 2, 14), Salary = 3100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Kevin", LastName = "Villalba", IsActive = true, HireDate = new DateTime(2020, 1, 16), Salary = 4100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Kevin", LastName = "Gomez", IsActive = true, HireDate = new DateTime(2022, 3, 20), Salary = 3750000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Kevin", LastName = "Santos", IsActive = true, HireDate = new DateTime(2021, 11, 6), Salary = 3850000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Laura", LastName = "Martinez", IsActive = true, HireDate = new DateTime(2019, 11, 30), Salary = 5000000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Laura", LastName = "Herrera", IsActive = true, HireDate = new DateTime(2023, 6, 19), Salary = 3700000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Laura", LastName = "Salinas", IsActive = true, HireDate = new DateTime(2020, 4, 7), Salary = 4100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Maria", LastName = "Gomez", IsActive = true, HireDate = new DateTime(2020, 8, 22), Salary = 4200000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Maria", LastName = "Lopez", IsActive = true, HireDate = new DateTime(2019, 5, 19), Salary = 3900000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Maria", LastName = "Torres", IsActive = true, HireDate = new DateTime(2021, 7, 2), Salary = 4100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Natalia", LastName = "Torres", IsActive = true, HireDate = new DateTime(2022, 9, 8), Salary = 2950000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Natalia", LastName = "Jimenez", IsActive = true, HireDate = new DateTime(2020, 10, 10), Salary = 3200000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Natalia", LastName = "Perez", IsActive = true, HireDate = new DateTime(2021, 2, 20), Salary = 3400000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Oscar", LastName = "Beltran", IsActive = true, HireDate = new DateTime(2021, 6, 9), Salary = 4500000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Oscar", LastName = "Ruiz", IsActive = true, HireDate = new DateTime(2020, 9, 9), Salary = 3750000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Oscar", LastName = "Reyes", IsActive = true, HireDate = new DateTime(2022, 3, 12), Salary = 3950000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Paula", LastName = "Ortiz", IsActive = true, HireDate = new DateTime(2019, 2, 8), Salary = 4800000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Paula", LastName = "Diaz", IsActive = true, HireDate = new DateTime(2020, 4, 5), Salary = 4300000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Paula", LastName = "Gaitan", IsActive = true, HireDate = new DateTime(2023, 1, 11), Salary = 4000000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Quique", LastName = "Morales", IsActive = true, HireDate = new DateTime(2020, 10, 15), Salary = 3200000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Quique", LastName = "Ortiz", IsActive = true, HireDate = new DateTime(2021, 8, 7), Salary = 3350000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Quique", LastName = "Cortes", IsActive = true, HireDate = new DateTime(2022, 11, 19), Salary = 3450000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Ricardo", LastName = "Garcia", IsActive = true, HireDate = new DateTime(2018, 12, 12), Salary = 5500000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Ricardo", LastName = "Londoño", IsActive = true, HireDate = new DateTime(2020, 2, 9), Salary = 3800000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Ricardo", LastName = "Perez", IsActive = true, HireDate = new DateTime(2022, 6, 15), Salary = 4100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Sara", LastName = "Velasquez", IsActive = true, HireDate = new DateTime(2021, 12, 2), Salary = 4300000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Sara", LastName = "Moreno", IsActive = true, HireDate = new DateTime(2020, 4, 20), Salary = 4200000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Sara", LastName = "Paredes", IsActive = true, HireDate = new DateTime(2023, 3, 7), Salary = 4100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Tatiana", LastName = "Correa", IsActive = true, HireDate = new DateTime(2020, 3, 18), Salary = 4000000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Tatiana", LastName = "Linares", IsActive = true, HireDate = new DateTime(2022, 9, 27), Salary = 3700000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Tatiana", LastName = "Serrano", IsActive = true, HireDate = new DateTime(2021, 7, 9), Salary = 3850000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Ursula", LastName = "Escobar", IsActive = true, HireDate = new DateTime(2022, 5, 30), Salary = 3550000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Ursula", LastName = "Diaz", IsActive = true, HireDate = new DateTime(2020, 6, 10), Salary = 3700000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Ursula", LastName = "Ramirez", IsActive = true, HireDate = new DateTime(2023, 2, 14), Salary = 3900000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Valentina", LastName = "Rojas", IsActive = true, HireDate = new DateTime(2020, 9, 16), Salary = 4100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Valentina", LastName = "Mejia", IsActive = true, HireDate = new DateTime(2021, 3, 15), Salary = 3950000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Valentina", LastName = "Zapata", IsActive = true, HireDate = new DateTime(2022, 11, 23), Salary = 3850000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Walter", LastName = "Londono", IsActive = true, HireDate = new DateTime(2023, 2, 20), Salary = 3900000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Walter", LastName = "Castaño", IsActive = true, HireDate = new DateTime(2021, 10, 10), Salary = 4000000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Walter", LastName = "Pineda", IsActive = true, HireDate = new DateTime(2020, 5, 3), Salary = 4200000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Ximena", LastName = "Medina", IsActive = true, HireDate = new DateTime(2021, 7, 14), Salary = 3250000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Ximena", LastName = "Gomez", IsActive = true, HireDate = new DateTime(2022, 3, 20), Salary = 3400000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Ximena", LastName = "Ospina", IsActive = true, HireDate = new DateTime(2020, 12, 12), Salary = 3500000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Yulieth", LastName = "Nieto", IsActive = true, HireDate = new DateTime(2020, 6, 5), Salary = 3450000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Yulieth", LastName = "Barrera", IsActive = true, HireDate = new DateTime(2021, 8, 8), Salary = 3600000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Yulieth", LastName = "Cardona", IsActive = true, HireDate = new DateTime(2023, 9, 5), Salary = 3800000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Zulma", LastName = "Ospina", IsActive = true, HireDate = new DateTime(2022, 10, 17), Salary = 4150000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Abel", LastName = "Acosta", IsActive = true, HireDate = new DateTime(2021, 3, 12), Salary = 3100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Beatriz", LastName = "Bermudez", IsActive = true, HireDate = new DateTime(2020, 5, 8), Salary = 4000000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Camilo", LastName = "Castellanos", IsActive = true, HireDate = new DateTime(2022, 9, 15), Salary = 3600000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Dora", LastName = "Diaz", IsActive = true, HireDate = new DateTime(2019, 11, 2), Salary = 3500000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Eduardo", LastName = "Escamilla", IsActive = true, HireDate = new DateTime(2023, 4, 10), Salary = 3700000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Fernanda", LastName = "Florez", IsActive = true, HireDate = new DateTime(2021, 7, 18), Salary = 4200000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Gustavo", LastName = "Gaitan", IsActive = true, HireDate = new DateTime(2020, 10, 25), Salary = 3950000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Helena", LastName = "Hernandez", IsActive = true, HireDate = new DateTime(2022, 1, 5), Salary = 3450000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Ismael", LastName = "Ibarra", IsActive = true, HireDate = new DateTime(2023, 3, 8), Salary = 3800000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Juliana", LastName = "Jaramillo", IsActive = true, HireDate = new DateTime(2019, 9, 27), Salary = 4000000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Kevin", LastName = "Klinger", IsActive = true, HireDate = new DateTime(2020, 12, 30), Salary = 3550000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Lucia", LastName = "Luna", IsActive = true, HireDate = new DateTime(2021, 6, 14), Salary = 3750000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Manuel", LastName = "Mendoza", IsActive = true, HireDate = new DateTime(2022, 8, 23), Salary = 4100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Natalia", LastName = "Nieves", IsActive = true, HireDate = new DateTime(2018, 4, 12), Salary = 3900000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Oscar", LastName = "Ocampo", IsActive = true, HireDate = new DateTime(2020, 11, 5), Salary = 4300000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Paola", LastName = "Pineda", IsActive = true, HireDate = new DateTime(2023, 2, 19), Salary = 3200000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Quintin", LastName = "Quiroga", IsActive = true, HireDate = new DateTime(2021, 8, 7), Salary = 3400000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Rosa", LastName = "Rios", IsActive = true, HireDate = new DateTime(2019, 3, 29), Salary = 3700000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Samuel", LastName = "Santos", IsActive = true, HireDate = new DateTime(2020, 7, 10), Salary = 4000000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Tatiana", LastName = "Tobon", IsActive = true, HireDate = new DateTime(2022, 12, 3), Salary = 3100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Uriel", LastName = "Uribe", IsActive = true, HireDate = new DateTime(2021, 5, 9), Salary = 3500000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Valeria", LastName = "Vargas", IsActive = true, HireDate = new DateTime(2023, 9, 15), Salary = 4300000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Walter", LastName = "Wiesner", IsActive = true, HireDate = new DateTime(2020, 1, 17), Salary = 3900000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Ximena", LastName = "Xiques", IsActive = true, HireDate = new DateTime(2019, 10, 1), Salary = 3600000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Yuliana", LastName = "Yepes", IsActive = true, HireDate = new DateTime(2022, 6, 20), Salary = 3750000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Zoraida", LastName = "Zapata", IsActive = true, HireDate = new DateTime(2023, 4, 5), Salary = 3850000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Amelia", LastName = "Ariza", IsActive = true, HireDate = new DateTime(2019, 6, 8), Salary = 3400000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Benito", LastName = "Baron", IsActive = true, HireDate = new DateTime(2020, 8, 14), Salary = 3600000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Carmen", LastName = "Caicedo", IsActive = true, HireDate = new DateTime(2021, 2, 2), Salary = 3700000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Diego", LastName = "Delgado", IsActive = true, HireDate = new DateTime(2022, 9, 22), Salary = 4200000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Esteban", LastName = "Espitia", IsActive = true, HireDate = new DateTime(2018, 11, 3), Salary = 3800000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Flor", LastName = "Fajardo", IsActive = true, HireDate = new DateTime(2020, 12, 7), Salary = 3550000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Gerardo", LastName = "Guzman", IsActive = true, HireDate = new DateTime(2023, 1, 12), Salary = 4000000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Hugo", LastName = "Hernandez", IsActive = true, HireDate = new DateTime(2019, 8, 27), Salary = 3700000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Ines", LastName = "Iglesias", IsActive = true, HireDate = new DateTime(2021, 9, 9), Salary = 3950000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Jairo", LastName = "Jimenez", IsActive = true, HireDate = new DateTime(2022, 3, 13), Salary = 4100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Karina", LastName = "Kempis", IsActive = true, HireDate = new DateTime(2020, 4, 19), Salary = 3900000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Leandro", LastName = "Lopez", IsActive = true, HireDate = new DateTime(2021, 10, 25), Salary = 4300000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Marta", LastName = "Molina", IsActive = true, HireDate = new DateTime(2019, 1, 7), Salary = 3450000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Nestor", LastName = "Navarro", IsActive = true, HireDate = new DateTime(2023, 7, 18), Salary = 3900000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Olga", LastName = "Olarte", IsActive = true, HireDate = new DateTime(2020, 6, 4), Salary = 4100000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Pablo", LastName = "Palacios", IsActive = true, HireDate = new DateTime(2022, 11, 8), Salary = 3700000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Ramon", LastName = "Ruiz", IsActive = true, HireDate = new DateTime(2021, 3, 30), Salary = 4200000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Sofia", LastName = "Sierra", IsActive = true, HireDate = new DateTime(2019, 12, 22), Salary = 3900000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Tomas", LastName = "Torres", IsActive = true, HireDate = new DateTime(2020, 9, 9), Salary = 3500000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Ulises", LastName = "Urrea", IsActive = true, HireDate = new DateTime(2023, 5, 1), Salary = 3600000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Viviana", LastName = "Villarreal", IsActive = true, HireDate = new DateTime(2021, 8, 5), Salary = 3750000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Wilson", LastName = "Wong", IsActive = true, HireDate = new DateTime(2018, 10, 15), Salary = 4300000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Xavier", LastName = "Ximenez", IsActive = true, HireDate = new DateTime(2020, 2, 26), Salary = 3850000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Yair", LastName = "Yañez", IsActive = true, HireDate = new DateTime(2023, 6, 14), Salary = 4050000 });
                _context.Employees.Add(new EmployeeBD { FirstName = "Zully", LastName = "Zamora", IsActive = true, HireDate = new DateTime(2021, 4, 18), Salary = 3950000 });

                await _context.SaveChangesAsync();
            }
        }
    }
}