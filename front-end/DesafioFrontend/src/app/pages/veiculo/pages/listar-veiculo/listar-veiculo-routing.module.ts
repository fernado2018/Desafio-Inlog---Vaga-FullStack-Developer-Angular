import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarVeiculoComponent } from './listar-veiculo.component';

const routes: Routes = [{
  path: '',
  component: ListarVeiculoComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ListarVeiculoRoutingModule { }
