import { Injectable } from '@angular/core';
import * as fromAction from './veiculo.actions';
import { HttpClient } from '@angular/common/http';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError, delay, map, switchMap, tap } from 'rxjs/operators';
import { environment } from '../../../environments/environment.dev';
import {
  VeiculoCreateResquest,
  VeiculoPagedRequest,
  VeiculoResponse,
} from './veiculo.models';
import { Veiculo } from '@app/models/Veiculo';
import { HttpParams } from '@angular/common/http';
import { PagedResult } from '@app/models/Paginacao/PagedResult';
import { NotificationService } from '@app/services';

type Action = fromAction.All;

@Injectable()
export class VeiculoEffects {
  constructor(
    private httpClient: HttpClient,
    private action: Actions,
    private router: Router,
    private notification: NotificationService
  ) {}

  criarVeiculo: Observable<Action> = createEffect(() =>
    this.action.pipe(
      ofType(fromAction.Types.CRIAR_VEICULO),
      map((action: fromAction.CriarVeiculo) => action.veiculo),
      switchMap((request: VeiculoCreateResquest) =>
        this.httpClient
          .post<VeiculoResponse>(
            `${environment.url}api/veiculo/cadastrar`,
            request
          )
          .pipe(
            tap((response: VeiculoResponse) => {
              this.notification.success(response.mensagem);
            }),
            delay(3000),
            map((response: VeiculoResponse) => {
              if (response.mensagem !== null) {
                this.router.navigate(['veiculo/listar']);
              }
              return new fromAction.CriateVeiculoSuccess(response.mensagem);
            }),
            catchError((err) => {
              this.notification.error(
                err.error.mensagem || 'Erro ao criar veículo'
              );
              return of(
                new fromAction.CriateVeiculoError(
                  err.error || 'Erro ao criar veículo'
                )
              );
            })
          )
      )
    )
  );

  listarVeiculosPaginados$: Observable<Action> = createEffect(() =>
    this.action.pipe(
      ofType(fromAction.Types.LISTAR_TODOS_OS_VICULO),
      map((action: fromAction.ListarTodosOsVeiculos) => action.request),
      switchMap((params: VeiculoPagedRequest) =>
        this.httpClient
          .get<PagedResult<Veiculo>>(`${environment.url}api/veiculo/Listar`, {
            params: new HttpParams({ fromObject: { ...params } }),
          })
          .pipe(
            delay(600),
            map(
              (response: PagedResult<Veiculo>) =>
                new fromAction.ListarTodosOsVeiculoSUCCESS(response)
            ),
            catchError((err) => {
              this.notification.error(err.error?.mensagem);

              return of(
                new fromAction.ListarTodosOsVeiculoError(err.error?.mensagem)
              );
            })
          )
      )
    )
  );
}
