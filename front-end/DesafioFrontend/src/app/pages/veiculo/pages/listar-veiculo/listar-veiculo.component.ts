import { Component, OnInit, ViewChild } from '@angular/core';
import { select, Store } from '@ngrx/store';
import * as fromRoot from '@app/store';
import { Observable } from 'rxjs';
import { Veiculo } from '@app/models/Veiculo';
import * as fromVeiculo from '@app/store/veiculo';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { MapaComponent } from '@app/components/mapa/mapa.component';
import { PagedResult } from '@app/models/Paginacao/PagedResult';

@Component({
  selector: 'app-listar-veiculo',
  templateUrl: './listar-veiculo.component.html',
  styleUrl: './listar-veiculo.component.scss',
})
export class ListarVeiculoComponent {
  veiculos!: PagedResult<Veiculo>;
  loading$!: Observable<boolean | null>;
  colunas: string[] = [
    'chassi',
    'placa',
    'cor',
    'tipoVeiculo',
    'localizacao',
    'acoes',
  ];
  pageSizeAtual: number = 5;
  filtros = '';

  colunasComRotulo = [
    { key: 'chassi', label: 'Chassi' },
    { key: 'placa', label: 'Placa' },
    { key: 'cor', label: 'Cor' },
    { key: 'tipoVeiculo', label: 'Tipo Veiculo' },
    { key: 'localizacao', label: 'Localização' },
    { key: 'acoes', label: 'Ações' },
  ];

  acoes = [{ tipo: 'visualizar', icone: 'visibility', tooltip: 'Visualizar' }];

  constructor(
    private store: Store<fromRoot.State>,
    private router: Router,
    private dialog: MatDialog
  ) {
    this.loading$ = this.store.pipe(select(fromVeiculo.getLoading));
    this.store.dispatch(
      new fromVeiculo.ListarTodosOsVeiculos({
        OrderBy: 've',
        page: 1,
        pageSize: 5,
      })
    );
    this.store
      .pipe(select(fromVeiculo.getTodosVeiculos))
      .subscribe((result: any) => {
        if (result) {
          this.veiculos = result;
        }
      });
  }

  ngOnInit(): void {}

  onFiltroRecebido(inputfiltro: string) {
    this.filtros = inputfiltro;
    const filtro = inputfiltro;
    this.store.dispatch(
      new fromVeiculo.ListarTodosOsVeiculos({
        filtro,
        OrderBy: 've',
        page: 1,
        pageSize: 5,
      })
    );

    this.store
      .pipe(select(fromVeiculo.getTodosVeiculos))
      .subscribe((result: any) => {
        this.veiculos = result;
      });
  }

  onAbrirTelaCadastro(): void {
    this.router.navigate(['veiculo/cadastrar']);
  }

  executarAcao(veiculo: Veiculo): void {
    this.dialog.open(MapaComponent, {
      width: '800px',
      height: '500px',
      data: veiculo.localizacao,
    });
  }

  onPageSizeChange(novaPaginacao: any) {
    this.pageSizeAtual = novaPaginacao.pageSize;
    const filtro = this.filtros;

    this.store.dispatch(
      new fromVeiculo.ListarTodosOsVeiculos({
        filtro,
        OrderBy: 'cor',
        page: novaPaginacao.pageIndex,
        pageSize: novaPaginacao.pageSize,
      })
    );
  }
}
