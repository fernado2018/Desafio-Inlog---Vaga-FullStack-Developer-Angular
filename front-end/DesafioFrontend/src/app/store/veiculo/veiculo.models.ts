import { PagedRequest } from '@app/models/Paginacao/PagedRequest';
import { PagedResult } from '@app/models/Paginacao/PagedResult';
import { Veiculo } from '@app/models/Veiculo';


export interface VeiculoRequest extends Veiculo {}


export type VeiculoCreateResquest = Omit<Veiculo, 'id'>;

export interface VeiculoResponse {
  mensagem: string;
}


export interface  VeiculoPagedRequest extends PagedRequest{}


export interface PagedOutput<Veiculo> extends PagedResult<Veiculo> {}



