import { Component, OnInit } from '@angular/core';
import { IVehicleCount, VehicleService } from 'app/core';
import { NgClass } from "@angular/common";

@Component({
  selector: 'admin-dashboard',
  imports: [NgClass],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {
  tilesDisplayInformation: { css: string, data: string, text: string, icon: string }[] = <any>[];

  constructor(private _vehicleService: VehicleService) { }

  ngOnInit(): void {
    this.loadTilesInformation();
  }

  private loadTilesInformation() {
    this._vehicleService.getVehicleCount().subscribe({
      next: (value: IVehicleCount) => {
        //vehicle on Sale
        this.tilesDisplayInformation.push({
          css: 'bg-primary',
          data: value.onSale.toString(),
          text: 'Vehicles on Sale',
          icon: 'bi-car-front'
        });

        //vehicles sold
        this.tilesDisplayInformation.push({
          css: 'bg-success',
          data: value.sold.toString(),
          text: 'Vehicles Sold',
          icon: 'bi-ev-front'
        });

        //vehicles on Hold
        this.tilesDisplayInformation.push({
          css: 'bg-warning',
          data: value.onHold.toString(),
          text: 'Vehicles on Hold',
          icon: 'bi-slash-circle'
        });

        this.loadTotalRevenue();
      }
    });
  }


  private loadTotalRevenue() {
    this.tilesDisplayInformation.push({
      css: 'bg-info',
      data: '$73000',
      text: 'Total Revenue',
      icon: 'bi-cash-coin'
    });
  }
}
