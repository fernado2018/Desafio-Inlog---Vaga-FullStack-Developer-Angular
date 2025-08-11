import { Component, EventEmitter, Output } from '@angular/core';
import { MatToolbar } from "@angular/material/toolbar";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {
@Output() menuToggle = new EventEmitter<void>();

  onMenuToggleDispatch(): void {
   this.menuToggle.emit();
  }
}
