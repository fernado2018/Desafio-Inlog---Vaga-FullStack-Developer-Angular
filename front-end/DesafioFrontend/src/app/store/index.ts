import { ActionReducerMap } from "@ngrx/store";
import * as fromVeiculo from './veiculo';



export interface State {
  veiculos: fromVeiculo.veiculoState;
}

export const reducers: ActionReducerMap<State> = {
  veiculos: fromVeiculo.reducer
}

export const effects = [
  fromVeiculo.VeiculoEffects
]

