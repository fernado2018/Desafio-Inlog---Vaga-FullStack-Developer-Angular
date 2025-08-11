import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotificationComponent } from './components/notification/notification.component';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { NotificationService } from './notification.service';


@NgModule({
  declarations: [
    NotificationComponent
  ],
  imports: [
    CommonModule,
    MatSnackBarModule
  ]
})
export class NotificationModule {
    static forRoot(): ModuleWithProviders<NotificationModule>{
    return  {
      ngModule: NotificationModule,
      providers: [
        NotificationService
      ]
    };

  }
}
