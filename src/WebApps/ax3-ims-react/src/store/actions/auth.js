import { AuthProxy } from 'proxies';
import types from 'store/types/auth';

export default {
  getAccount: () =>
    async (dispatch, getState) => {
      if (getState().account) return;
      try {
        const response = await AuthProxy.getData({ url: 'me' });
        dispatch({ type: types.AUTH_SET, key: 'account', data: response });
        return response;
      } catch (error) {
        localStorage.removeItem('token');
        throw error;
      }
    },
  login: (data) =>
    async (dispatch) => {
      dispatch({ type: types.AUTH_REQUEST, key: 'login' });
      try {
        const response = await AuthProxy.login(data);
        dispatch({ type: types.AUTH_SUCCESS, key: 'login' });
        dispatch({ type: types.AUTH_SET, key: 'account', data: response });
        return response;
      } catch (error) {
        dispatch({ type: types.AUTH_ERROR, key: 'login', error });
        throw error;
      }
    },
  register: (data) =>
    async (dispatch) => {
      dispatch({ type: types.AUTH_REQUEST, key: 'register' });
      try {
        const response = await AuthProxy.postData(data);
        dispatch({ type: types.AUTH_SUCCESS, key: 'register' });
        return response;
      } catch (error) {
        dispatch({ type: types.AUTH_ERROR, key: 'register', error });
        throw error;
      }
    },
  forgotPassword: (data) =>
    async (dispatch) => {
      dispatch({ type: types.AUTH_REQUEST, key: 'forgotPassword' });
      try {
        const response = await AuthProxy.postData(data);
        dispatch({ type: types.AUTH_SUCCESS, key: 'forgotPassword' });
        return response;
      } catch (error) {
        dispatch({ type: types.AUTH_ERROR, key: 'forgotPassword', error });
        throw error;
      }
    },
  resetPassword: (data) =>
    async (dispatch) => {
      dispatch({ type: types.AUTH_REQUEST, key: 'resetPassword' });
      try {
        const response = await AuthProxy.postData(data);
        dispatch({ type: types.AUTH_SUCCESS, key: 'resetPassword' });
        return response;
      } catch (error) {
        dispatch({ type: types.AUTH_ERROR, key: 'resetPassword', error });
        throw error;
      }
    },
};