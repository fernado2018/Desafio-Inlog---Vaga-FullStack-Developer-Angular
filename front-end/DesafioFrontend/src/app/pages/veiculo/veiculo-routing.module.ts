import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'listar',
    loadChildren: () => import('./pages/listar-veiculo/listar-veiculo.module').then(l => l.ListarVeiculoModule),
  },
  {
    path: 'cadastrar',
    loadChildren: () => import('./pages/cadastrar-veiculo/cadastrar-veiculo.module').then(c => c.CadastrarVeiculoModule),
  },
  {
    path: '**',
    pathMatch: 'full',
    redirectTo: 'listar'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VeiculoRoutingModule { }
