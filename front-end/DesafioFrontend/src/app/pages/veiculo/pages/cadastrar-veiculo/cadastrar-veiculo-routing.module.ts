import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrarVeiculoComponent } from './cadastrar-veiculo.component';

const routes: Routes = [{
  path: '',
  component: CadastrarVeiculoComponent
}];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CadastrarVeiculoRoutingModule { }
