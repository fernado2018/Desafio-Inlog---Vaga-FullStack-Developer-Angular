 import { createSelector, createFeatureSelector } from "@ngrx/store";
 import { veiculoState } from "./veiculo.reduce";
import { PagedOutput } from "./veiculo.models";
import { Veiculo } from "@app/models/Veiculo";



 export const getVeiculoState = createFeatureSelector<veiculoState>('veiculo');
  // criar
 export const getVeiculo = createSelector(
  getVeiculoState,
  (state) => state.veiculo
  );

export const getLoading = createSelector(
  getVeiculoState,
  (state:veiculoState) => state.loading ?? false
)

 //listar

export const getTodosVeiculos = createSelector(
getVeiculoState,
  (state) : PagedOutput<Veiculo> | null => state.veiculo
);


