import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Chart, ChartType } from 'chart.js/auto';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { FormsModule } from '@angular/forms';
import { VentasService } from '../../services/ventas.service';
import dayjs from 'dayjs';
import weekOfYear from 'dayjs/plugin/weekOfYear';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    RouterLink,
    MatButtonToggleModule,
    FormsModule,
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  public chart!: Chart;
  public chartPie!: Chart;
  public viewMode: 'monthly' | 'weekly' = 'monthly';
  ventasByMonth: any[] = [] ;
  ventasByWeek: any[] = [];
  nowDate: dayjs.Dayjs;
  currentYear: any;
  currentMonth: number;
  currentWeek: number;

  constructor(private ventasService: VentasService) {
    dayjs.extend(weekOfYear); // Cargar el plugin de la semana
    this.nowDate = dayjs(); // Obtener la fecha actual
    this.currentYear = this.nowDate.year(); // Obtener el año actual
    this.currentMonth = this.nowDate.month() + 1; // Obtener el mes actual (0-11, se suma 1 para obtener el formato 1-12)
    this.currentWeek = this.nowDate.week(); // Obtener la semana actual
    console.log(`Año: ${this.currentYear}, Mes: ${this.currentMonth}, Semana: ${this.currentWeek}`);
  }

  ngOnInit(): void {
    this.getVentasByMonth(this.currentYear, this.currentMonth);
    this.getVentasByWeek(this.currentYear, this.currentWeek);
  }

  getVentasByMonth(year: number, month: number) {
    this.ventasService.getVentasByMonth(year, month).subscribe({
      next: (response) => {
        if (response.body.length > 0) {
          this.ventasByMonth = response.body;
          if (this.viewMode === 'monthly') {
            const data = this.getMonthlyData();
            this.createBarChart(data);
            this.createPieChart(data);
          }
        }
        console.log('getVentasByMonth:', this.ventasByMonth);
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  getVentasByWeek(year: number, week: number) {
    this.ventasService.getVentasByWeek(year, week).subscribe({
      next: (response) => {
        if (response.body.length > 0) {
          this.ventasByWeek = response.body;
          if (this.viewMode === 'weekly') {
            const data = this.getWeeklyData();
            this.createBarChart(data);
            this.createPieChart(data);
          }
        }
        console.log('getVentasByWeek:', this.ventasByWeek);
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  createBarChart(data: any) {
    if (this.chart) {
      this.chart.destroy();
    }
    this.chart = new Chart("chart", {
      type: 'bar' as ChartType,
      data: data,
      options: {
        scales: {
          y: {
            beginAtZero: true
          }
        }
      },
    });
  }

  createPieChart(data: any) {
    if (this.chartPie) {
      this.chartPie.destroy();
    }
    this.chartPie = new Chart("chartPie", {
      type: 'pie' as ChartType,
      data: data,
    });
  }

  getMonthlyData() {
    const ventasPorMes = Array(12).fill(0);
    this.ventasByMonth.forEach(venta => {
      const mes = dayjs(venta.fechaVenta).month(); // Obtener el mes (0-11)
      ventasPorMes[mes] += venta.total;
    });

    return {
      labels: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
      datasets: [{
        label: 'Ventas',
        data: ventasPorMes,
        backgroundColor: [
          'rgba(255, 99, 132, 0.2)',
          'rgba(255, 159, 64, 0.2)',
          'rgba(255, 205, 86, 0.2)',
          'rgba(75, 192, 192, 0.2)',
          'rgba(54, 162, 235, 0.2)',
          'rgba(153, 102, 255, 0.2)',
          'rgba(201, 203, 207, 0.2)',
          'rgba(255, 205, 86, 0.2)',
          'rgba(255, 99, 132, 0.2)',
          'rgba(153, 102, 255, 0.2)',
          'rgba(255, 159, 64, 0.2)',
        ],
        borderColor: [
          'rgb(255, 99, 132)',
          'rgb(255, 159, 64)',
          'rgb(255, 205, 86)',
          'rgb(75, 192, 192)',
          'rgb(54, 162, 235)',
          'rgb(153, 102, 255)',
          'rgb(201, 203, 207)',
          'rgb(255, 159, 64)',
          'rgb(255, 205, 86)',
          'rgb(75, 192, 192)',
          'rgb(201, 203, 207)',
        ],
        borderWidth: 1
      }]
    };
  }

  getWeeklyData() {
    const ventasPorSemana = Array(4).fill(0);
    this.ventasByWeek.forEach(venta => {
      const semana = dayjs(venta.fechaVenta).week(); // Obtener la semana
      ventasPorSemana[semana % 4] += venta.total; // Agrupar por 4 semanas
    });

    return {
      labels: ['Semana 1', 'Semana 2', 'Semana 3', 'Semana 4'],
      datasets: [{
        label: 'Ventas',
        data: ventasPorSemana,
        backgroundColor: [
          'rgba(255, 99, 132, 0.2)',
          'rgba(255, 159, 64, 0.2)',
          'rgba(255, 205, 86, 0.2)',
          'rgba(75, 192, 192, 0.2)'
        ],
        borderColor: [
          'rgb(255, 99, 132)',
          'rgb(255, 159, 64)',
          'rgb(255, 205, 86)',
          'rgb(75, 192, 192)'
        ],
        borderWidth: 1
      }]
    };
  }

  onViewModeChange() {
    const data = this.viewMode === 'monthly' ? this.getMonthlyData() : this.getWeeklyData();
    this.createBarChart(data);
    this.createPieChart(data);
  }
}
