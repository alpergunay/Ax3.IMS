import { set } from 'lodash';
import state from 'store/state/global';
import types from 'store/types/global';

const initialState = state;

export default (state = initialState, action) => {
  const { type, key, data, index, error } = action;
  let obj = state[key];

  switch (type) {
    case types.GLOBAL_REQUEST:
      set(state, key, { ...obj, loading: true, error: null });
      return { ...state };
    case types.GLOBAL_SUCCESS:
      set(state, key, { ...obj, loading: false, data, error: null });
      return { ...state };
    case types.GLOBAL_ERROR:
      set(state, key, { ...obj, loading: false, data: null, error });
      return { ...state };
    case types.ADD_DATA:
      set(state, key, { ...obj, data: [...obj.data, data] });
      return { ...state };
    case types.UPDATE_DATA:
      obj.data[index] = data;
      set(state, key, { ...obj, data: [...obj.data] });
      return { ...state };
    case types.DELETE_DATA:
      obj.data.splice(index, 1);
      set(state, key, { ...obj, data: [...obj.data] });
      return { ...state };
    case types.SET_STATE:
      set(state, key, action.payload.data);
      return { ...state };
    default:
      return state;
  }
};