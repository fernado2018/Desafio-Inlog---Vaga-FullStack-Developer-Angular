import { VeiculoResponse, PagedOutput } from './veiculo.models';
import * as fromAction from './veiculo.actions';
import { Veiculo } from "@app/models/Veiculo";


export interface veiculoState {
  veiculo: PagedOutput<Veiculo> | null,
  loading: boolean | null;
  error: any;

}

const initialState: veiculoState = {
  veiculo: null,
  loading: null,
  error : null,
}


export function reducer(state = initialState, action: fromAction.All | any):veiculoState {

   switch(action.type){
    // criar
    case fromAction.Types.CRIAR_VEICULO:{
        return {...state, loading: true, error: null};
      }

    case fromAction.Types.CRIAR_VICULO_SUCCESS:{
        return {...state, loading: false, error: null};
      }

     case fromAction.Types.CRIAR_VEICULO_ERROR:{
        return {...state, loading: false, error: action.error};
        };


      //listar

       case fromAction.Types.LISTAR_TODOS_OS_VICULO:{
        return {...state, loading: true, error: null};
      }

      case fromAction.Types.LISTAR_TODOS_OS_VICULO_SUCCESS:{
        return {...state, loading: false, veiculo: action.pageResult, error: null};
      }

       case fromAction.Types.LISTAR_TODOS_OS_VICULO_ERROR:{
        return {...state, loading: false, veiculo: null, error: action.error};
      }


      default: {
        return state;
      }

    }

   }
