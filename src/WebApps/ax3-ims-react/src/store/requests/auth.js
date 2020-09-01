import store from 'store';
import actions from 'store/actions/auth';

export const getAccount = async () => {
  return store.dispatch(actions.getAccount());
};

export const login = async (payload) => {
  return store.dispatch(actions.login(payload));
};

export const register = async (payload) => {
  return store.dispatch(actions.register(payload));
};

export const forgotPassword = async (payload) => {
  return store.dispatch(actions.forgotPassword(payload));
};

export const resetPassword = async (payload) => {
  return store.dispatch(actions.resetPassword(payload));
};

export const updateState = async (payload) => {
  return store.dispatch(actions.updateState(payload));
};

export const logout = async () => {
  return store.dispatch(actions.logout());
};