import { set } from 'lodash';
import state from 'store/state/auth';
import types from 'store/types/auth';

const initialState = state;

export default (state = initialState, action) => {
  const { key, data, error } = action;

  switch (action.type) {
    case types.AUTH_REQUEST:
      state[key] = { loading: true, error: null };
      return { ...state };
    case types.AUTH_SUCCESS:
      state[key] = { loading: false, error: null };
      return { ...state };
    case types.AUTH_ERROR:
      state[key] = { loading: false, error };
      return { ...state };
    case types.AUTH_SET:
      set(state, key, data);
      return { ...state };
    default:
      return state;
  };
};