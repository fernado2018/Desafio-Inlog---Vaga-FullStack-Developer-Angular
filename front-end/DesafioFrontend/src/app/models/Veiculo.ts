import { Localizacao } from './Localizacao';
export interface Veiculo {
  id?: number,
  chassi: string,
  tipoVeiculo: number,
  cor: string,
  placa: string,
  numeroSerieRastreador: string,
  localizacao: Localizacao
}
