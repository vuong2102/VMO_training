import { Component } from '@angular/core';
import {Chart, ChartOptions, ChartTypeRegistry, Plugin, registerables} from 'chart.js';
import { ContractType, ContractTypeOverview } from 'src/app/model/ContractType';
import { ContractTypeService } from 'src/app/services/management/contractType/contract-type.service';
import { ResultCode } from 'src/share/model/ResultCode';
import { CanvasJSAngularChartsModule } from '@canvasjs/angular-charts';
import { ContractService } from 'src/app/services/management/contract-profile/contract.service';

Chart.register(...registerables);

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public chart: any;
  public linechart: any;

  ngOnInit(): void {
    this.getAllContractType();
    // this.getContractOverview();
  }

  constructor(private contractTypeService: ContractTypeService,
    private contractService: ContractService
  ){}

  createChart(labels: string[], data: number[]){

    this.chart = new Chart("MyChart", {
      type: 'doughnut',

      data: {
        labels: labels,
        datasets: [{
          label: 'Số lượng',
          data: data,
          backgroundColor: [
            'rgb(255, 99, 132)',
            'rgb(54, 162, 235)',
            'rgb(255, 205, 86)',
            'rgb(255, 99, 10)',
            'rgb(54, 1, 235)',
            'rgb(25, 205, 86)'
          ],
          hoverOffset: 4
        }]
      },
      options: {
        aspectRatio:2.5,
      }

    });

    this.linechart = new Chart("myLineChart", {
      type: 'line',

      data: {
        labels: ['T1', 'T2', 'T3', 'T4', 'T5', 'T6', 'T7', 'T8', 'T9', 'T10', 'T11', 'T12'],
        datasets: [{
          label: 'Nghỉ việc',
          data: data,
          backgroundColor: [
            'rgb(255, 99, 132)',
            'rgb(54, 162, 235)',
            'rgb(255, 205, 86)',
            'rgb(255, 99, 10)',
            'rgb(54, 1, 235)',
            'rgb(25, 205, 86)'
          ],
        },
        {label: 'Tiếp nhận',
          data: data,
          backgroundColor: [
            'rgb(255, 99, 132)',
            'rgb(54, 162, 235)',
            'rgb(255, 205, 86)',
            'rgb(255, 99, 10)',
            'rgb(54, 1, 235)',
            'rgb(25, 205, 86)'
          ],}
      ]
      },
      options: {
        aspectRatio:2.5,
      }

    });
  }

  async getContractOverview(){
    this.contractService.getContractOverViewIncDec()
    const res: any = await this.contractService.getContractOverViewIncDec().toPromise();
    if(res.code == ResultCode.SuccessResult){
      const labels = this.contractTypeOverview.map(ct => ct.contractTypeName);
      const data = res.result;
      console.log(data);
      this.createChart2(labels, data);
    }
  }

  createChart2(labels: string[], data: number[]){

    this.linechart = new Chart("myLineChart", {
      type: 'line',

      data: {
        labels: ['T1', 'T2', 'T3', 'T4', 'T5', 'T6', 'T7', 'T8', 'T9', 'T10', 'T11', 'T12'],
        datasets: [{
          label: 'Nghỉ việc',
          data: data,
          backgroundColor: [
            'rgb(255, 99, 132)',
            'rgb(54, 162, 235)',
            'rgb(255, 205, 86)',
            'rgb(255, 99, 10)',
            'rgb(54, 1, 235)',
            'rgb(25, 205, 86)'
          ],
        },
        {label: 'Tiếp nhận',
          data: data,
          backgroundColor: [
            'rgb(255, 99, 132)',
            'rgb(54, 162, 235)',
            'rgb(255, 205, 86)',
            'rgb(255, 99, 10)',
            'rgb(54, 1, 235)',
            'rgb(25, 205, 86)'
          ],}
      ]
      },
      options: {
        aspectRatio:2.5,
      }

    });
  }



  contractTypeOverview: ContractTypeOverview[] = [];
  async getAllContractType(){
    const res: any = await this.contractTypeService.getAllContractTypeWithFilter().toPromise();
    if(res.code == ResultCode.SuccessResult){
      if(res.result.data != null) {
        this.contractTypeOverview = res.result.data;
        console.log(this.contractTypeOverview);

        const labels = this.contractTypeOverview.map(ct => ct.contractTypeName);
        const data = this.contractTypeOverview.map(ct => ct.number); // Assuming each contract type is counted as 1

        this.createChart(labels, data);
      }
    }
    else{
      console.log("Không thể lấy danh sách loại hợp đồng")
    }
  }

}

