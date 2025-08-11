import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CadastrarVeiculoRoutingModule } from './cadastrar-veiculo-routing.module';
import { SpinnerModule } from '@app/shared/indicators';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    CadastrarVeiculoRoutingModule,
    SpinnerModule,
  ]
})
export class CadastrarVeiculoModule { }
