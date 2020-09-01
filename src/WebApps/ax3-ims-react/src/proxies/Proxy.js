import axios from 'axios';

export default class Proxy {
  constructor(baseURL = '', headers = {}) {
    this.axios = axios.create({ baseURL, headers });
  };

  submit = async ({ method, url, params, data, options }) => {
    try {
      const response = await this.axios({ method, url, params, data, ...options });
      this.onSuccess && this.onSuccess(response);
      return response.data;
    } catch (e) {
      const error = e && e.response ? e.response.data : 'Unknown Error';
      this.onError && this.onError(error);
      throw error;
    }
  };

  /**
   * Sets header for related axios instance.
   * @param {string} key 
   * @param {any} value 
   */
  setHeader = (key, value) => {
    if (value) {
      this.axios.defaults.headers[key] = value;
    } else {
      delete this.axios.defaults.headers[key];
    }
  };

  getData = ({ url = '', params = {}, data = null, options = {} }) => {
    return this.submit({ method: 'get', url, params, data, options });
  };

  postData = ({ url = '', params = {}, data = null, options = {} }) => {
    return this.submit({ method: 'post', url, params, data, options });
  };

  putData = ({ url = '', params = {}, data = null, options = {} }) => {
    return this.submit({ method: 'put', url, params, data, options });
  };

  patchData = ({ url = '', params = {}, data = null, options = {} }) => {
    return this.submit({ method: 'patch', url, params, data, options });
  };

  deleteData = ({ url = '', params = {}, data = null, options = {} }) => {
    return this.submit({ method: 'delete', url, params, data, options });
  };

  headData = ({ url = '', params = {}, data = null, options = {} }) => {
    return this.submit({ method: 'head', url, params, data, options });
  };
};