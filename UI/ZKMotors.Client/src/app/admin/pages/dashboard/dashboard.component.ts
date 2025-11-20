import { Component, OnInit } from '@angular/core';
import { IDashboardStats, VehicleService } from 'app/core';
import { NgClass } from "@angular/common";

@Component({
  selector: 'admin-dashboard',
  imports: [NgClass],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {
  statsDisplayInformation: { css: string, data: string, text: string, icon: string }[] = <any>[];

  constructor(private _vehicleService: VehicleService) { }

  ngOnInit(): void {
    this.loadDashboardStats();
  }

  private loadDashboardStats() {
    this._vehicleService.getDashboardStats().subscribe({
      next: (value: IDashboardStats) => {
        //vehicle on Sale
        this.statsDisplayInformation.push({
          css: 'bg-primary',
          data: value.onSale.toString(),
          text: 'Vehicles on Sale',
          icon: 'bi-car-front'
        });

        //vehicles sold
        this.statsDisplayInformation.push({
          css: 'bg-success',
          data: value.sold.toString(),
          text: 'Vehicles Sold',
          icon: 'bi-ev-front'
        });

        //vehicles on Hold
        this.statsDisplayInformation.push({
          css: 'bg-warning',
          data: value.onHold.toString(),
          text: 'Vehicles on Hold',
          icon: 'bi-slash-circle'
        });

        //total revenue
        this.statsDisplayInformation.push({
          css: 'bg-info',
          data: value.totalRevenue.toString(),
          text: 'Total Revenue',
          icon: 'bi-cash-coin'
        });
      }
    });
  }
}
