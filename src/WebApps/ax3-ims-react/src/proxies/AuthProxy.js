import Proxy from './Proxy';

class AuthProxy extends Proxy {
  constructor() {
    const token = localStorage.getItem('token');
    const headers = token ? { 'Authorization': `Bearer ${token}` } : {};
    super(process.env.REACT_APP_API_URL, headers);
  };

  login = async (data) => {
    try {
      const response = await this.postData({ url: 'login', data });
      this.setHeader('Authorization', `Bearer ${response.access_token}`);
      localStorage.setItem('token', response.access_token);
      return response;
    } catch (error) {
      throw error;
    }
  };
};

export default new AuthProxy();