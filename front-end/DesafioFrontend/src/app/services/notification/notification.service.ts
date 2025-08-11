import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NotificationComponent } from './components/notification/notification.component';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private snackBar: MatSnackBar) { }

  error(message: string): void {
      this.snackBar.openFromComponent(NotificationComponent, {
        duration: 1500,
        data: { message },
        panelClass: ['mat-snackbar_error']
      });

    }

    success(message: string): void{
      this.snackBar.openFromComponent(NotificationComponent, {
        duration: 1500,
        data: { message },
        panelClass: ['mat-snackbar_success']
      });

    }
}
