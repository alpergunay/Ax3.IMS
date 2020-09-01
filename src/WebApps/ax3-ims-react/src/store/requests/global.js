import store from 'store';
import actions from 'store/actions/global';

export const getData = ({ url = '', params = {}, data = null, options = {} }) => {
  return store.dispatch(actions.getData({ url, params, data, options }));
};

export const postData = ({ url = '', params = {}, data = null, options = {} }) => {
  return store.dispatch(actions.postData({ url, params, data, options }));
};

export const putData = ({ url = '', params = {}, data = null, options = {} }) => {
  return store.dispatch(actions.putData({ url, params, data, options }));
};

export const patchData = ({ url = '', params = {}, data = null, options = {} }) => {
  return store.dispatch(actions.patchData({ url, params, data, options }));
};

export const deleteData = ({ url = '', params = {}, data = null, options = {} }) => {
  return store.dispatch(actions.deleteData({ url, params, data, options }));
};

export const updateState = ({ url = '', params = {}, data = null, options = {} }) => {
  return store.dispatch(actions.updateState({ url, params, data, options }));
};