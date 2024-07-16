import { Component } from '@angular/core';
import { trigger, state, style, animate, transition } from '@angular/animations';
import { NzAlertType } from 'src/share/model/NzAlertType';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations: [
    trigger('slideInOut', [
      state('in', style({
        transform: 'translateX(0)',
        opacity: 1
      })),
      transition('void => *', [
        style({
          transform: 'translateX(100%)',
          opacity: 0
        }),
        animate('200ms ease-in')
      ]),
      transition('* => void', [
        animate('200ms ease-out', style({
          transform: 'translateX(100%)',
          opacity: 0
        }))
      ])
    ])
  ]
})
export class AppComponent {
  isCollapsed = false;
  isDanhMucOpen = false;
  isSuccessAlertVisible = false;
  alertMessage: string = 'Success';
  alertDescription: string = '';
  NzAlertType = NzAlertType;
  alertType: NzAlertType = NzAlertType.Success;

  showSuccessAlert(message: string, showAlert: boolean, alertType: NzAlertType) {
    this.alertDescription = message;
    this.isSuccessAlertVisible = showAlert;
    this.alertType = alertType;
    setTimeout(() => {
      this.isSuccessAlertVisible = false;
    }, 5000);
  }
}
