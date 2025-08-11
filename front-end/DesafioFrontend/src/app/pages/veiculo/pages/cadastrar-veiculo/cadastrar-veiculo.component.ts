import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { TipoVeiculo } from '@app/utils/tipoVeiculos';
import { select, Store } from '@ngrx/store';
import * as fromRoot from '@app/store';
import * as fromList from '@app/store/veiculo';
import { Observable } from 'rxjs';
import { VeiculoCreateResquest } from '@app/store/veiculo';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastrar-veiculo',
  templateUrl: './cadastrar-veiculo.component.html',
  styleUrl: './cadastrar-veiculo.component.scss',
})
export class CadastrarVeiculoComponent implements OnInit {
  formulario!: FormGroup;
  loading$!: Observable<boolean | null>;
  mensage$!: Observable<string | null>;
  tiposVeiculo = [
    { value: TipoVeiculo.Caminhao, label: 'Caminhao' },
    { value: TipoVeiculo.Onibus, label: 'Onibus' },
  ];

  constructor(
    private fb: FormBuilder,
    private store: Store<fromRoot.State>,
    private router: Router
  ) {
    this.formulario = this.fb.group({
      chassi: [''],
      tipoVeiculo: [1],
      cor: [''],
      placa: [''],
      numeroSerieRastreador: [''],
      localizacao: this.fb.group({
        latitude: [0],
        longitude: [0],
      }),
    });
  }
  ngOnInit(): void {}

  salvar(): void {
    if (this.formulario.valid) {
      this.loading$ = this.store.pipe(select(fromList.getLoading));

      const veiculoCreateRequest: VeiculoCreateResquest = {
        chassi: this.formulario.value.chassi,
        cor: this.formulario.value.cor,
        tipoVeiculo: this.formulario.value.tipoVeiculo,
        placa: this.formulario.value.placa,
        numeroSerieRastreador: this.formulario.value.numeroSerieRastreador,
        localizacao: {
          latitude: this.formulario.value.localizacao.latitude,
          longitude: this.formulario.value.localizacao.longitude,
        },
      };

      this.store.dispatch(new fromList.CriarVeiculo(veiculoCreateRequest));
    }
  }

  public voltar(): void {
    this.router.navigate(['veiculo/listar']);
  }
}
