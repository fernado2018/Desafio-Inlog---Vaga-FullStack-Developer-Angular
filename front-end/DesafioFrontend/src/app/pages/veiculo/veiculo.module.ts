import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VeiculoRoutingModule } from './veiculo-routing.module';
import { StoreModule } from '@ngrx/store';
import { effects, reducers } from '@app/store';
import { EffectsModule } from '@ngrx/effects';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    VeiculoRoutingModule,
    StoreModule.forFeature('veiculo', reducers.veiculos),
    EffectsModule.forFeature(effects),
  ],
})
export class VeiculoModule {}
