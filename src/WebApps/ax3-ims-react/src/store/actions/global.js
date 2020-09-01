import { DashboardProxy } from 'proxies';
import types from 'store/types/global';

export default {
  getData: (payload) =>
    async (dispatch) => {
      payload.key && dispatch({ type: types.GLOBAL_REQUEST, payload });
      try {
        const data = await DashboardProxy.getData(payload);
        payload.key && dispatch({ type: types.GLOBAL_SUCCESS, key: payload.key, data });
        return data;
      } catch (error) {
        payload.key && dispatch({ type: types.GLOBAL_ERROR, key: payload.key, error });
        throw error;
      }
    },
  postData: (payload) =>
    async (dispatch) => {
      try {
        const data = await DashboardProxy.postData(payload);
        payload.key && dispatch({ type: types.ADD_DATA, key: payload.key, data });
        return data;
      } catch (error) {
        throw error;
      }
    },
  putData: (payload) =>
    async (dispatch) => {
      try {
        const data = await DashboardProxy.putData(payload);
        payload.key && dispatch({ type: types.UPDATE_DATA, ...payload });
        return data;
      } catch (error) {
        throw error;
      }
    },
  patchData: (payload) =>
    async (dispatch) => {
      try {
        const data = await DashboardProxy.patchData(payload);
        payload.key && dispatch({ type: types.UPDATE_DATA, ...payload });
        return data;
      } catch (error) {
        throw error;
      }
    },
  deleteData: (payload) =>
    async (dispatch) => {
      try {
        const data = await DashboardProxy.deleteData(payload);
        payload.key && dispatch({ type: types.DELETE_DATA, ...payload });
        return data;
      } catch (error) {
        throw error;
      }
    },
  headData: (payload) =>
    async (dispatch) => {
      try {
        const data = await DashboardProxy.headData(payload);
        return data;
      } catch (error) {
        throw error;
      }
    },
  updateState: (payload) =>
    async (dispatch) => {
      dispatch({ type: types.SET_STATE, payload });
      return;
    },
};