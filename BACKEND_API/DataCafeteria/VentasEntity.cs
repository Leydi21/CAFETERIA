using DataCafeteria.Context;
using DtosCafeteria;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCafeteria
{
    public class VentasEntity
    {
        private readonly ApplicationDbContext Context;
        public VentasEntity(string connectionString)
        {
            Context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>(), connectionString);
        }
        public async Task<Ventas> AgregarVenta(Ventas ventas)
        {
            var ventasNew = await this.Context.Ventas.AddAsync(ventas);
            await this.Context.SaveChangesAsync();
            return ventasNew.Entity;
        }
        public async Task<List<Ventas>> GetListaVentas()
        {
            return await Context.Ventas.ToListAsync();
        }
        public async Task<int> ActualizarVenta(Ventas ventas)
        {
            Context.Entry(ventas).State = EntityState.Modified;
            return await Context.SaveChangesAsync();
        }
        public async Task<Ventas> GetVentaId(int id)
        {
            var venta = Context.Ventas.FindAsync(id);
            return await venta;
        }

        public async Task<List<Ventas>> GetVentasPorMes(int year, int month)
        {
            var ventasPorMes = await Context.Ventas
                .Where(v => v.FechaVenta.Year == year && v.FechaVenta.Month == month)
                .ToListAsync();
            return ventasPorMes;
        }

        public async Task<List<Ventas>> GetVentasPorSemana(int year, int week)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = week;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }

            DateTime result = firstThursday.AddDays(weekNum * 7);
            DateTime startOfWeek = result.AddDays(-3);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            var ventasPorSemana = await Context.Ventas
                .Where(v => v.FechaVenta >= startOfWeek && v.FechaVenta < endOfWeek)
                .ToListAsync();

            return ventasPorSemana;
        }



    }
}
