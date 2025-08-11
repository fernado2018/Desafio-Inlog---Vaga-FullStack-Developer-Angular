import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ListarVeiculoRoutingModule } from './listar-veiculo-routing.module';
import { SpinnerModule } from '@app/shared/indicators';

@NgModule({
  declarations: [],
  imports: [CommonModule, ListarVeiculoRoutingModule, SpinnerModule],
})
export class ListarVeiculoModule {}
