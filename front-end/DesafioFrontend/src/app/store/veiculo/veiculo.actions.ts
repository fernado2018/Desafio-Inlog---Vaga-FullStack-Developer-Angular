import { Action } from "@ngrx/store";
import { VeiculoCreateResquest, VeiculoResponse } from "./veiculo.models";
import { Veiculo } from "@app/models/Veiculo";
import { PagedRequest } from "@app/models/Paginacao/PagedRequest";
import { PagedResult } from "@app/models/Paginacao/PagedResult";

export enum Types {


  CRIAR_VEICULO = '[Veiculo] Registrar um Veiculo: Criar ',
  CRIAR_VICULO_SUCCESS = '[Veiculo] Registrar um Veiculo: Success',
  CRIAR_VEICULO_ERROR = '[Veiculo] Registrar um veiculo: Error',

  LISTAR_TODOS_OS_VICULO = '[Veiculo] Listar todos os Veiculos',
  LISTAR_TODOS_OS_VICULO_SUCCESS = '[Veiculo] Listar todos os Veiculo: Success',
  LISTAR_TODOS_OS_VICULO_ERROR = '[Veiculo] Listar todos os Veiculo: Error',

}


// Criar

export class CriarVeiculo implements Action {
  readonly type = Types.CRIAR_VEICULO;
  constructor(public veiculo: VeiculoCreateResquest){}
}


export class CriateVeiculoSuccess implements Action{
  readonly type = Types.CRIAR_VICULO_SUCCESS
  constructor(public mensage: string){}
}

export class CriateVeiculoError implements Action{
  readonly type = Types.CRIAR_VEICULO_ERROR
  constructor(public error: string){}
}


// Listar

export class ListarTodosOsVeiculos implements Action {
  readonly type = Types.LISTAR_TODOS_OS_VICULO;
  constructor(public request:  {filtro?:string,OrderBy:string;page: number; pageSize: any }){}
}

export class ListarTodosOsVeiculoSUCCESS implements Action {
  readonly type = Types.LISTAR_TODOS_OS_VICULO_SUCCESS;
  constructor(public pageResult: PagedResult<Veiculo> ){}
}

export class ListarTodosOsVeiculoError implements Action{
  readonly type = Types.LISTAR_TODOS_OS_VICULO_ERROR
  constructor(public error: any){}
}

export type All =
      CriarVeiculo
     | CriateVeiculoSuccess
     | CriateVeiculoError
     | ListarTodosOsVeiculos
     | ListarTodosOsVeiculoSUCCESS
     | ListarTodosOsVeiculoError;

