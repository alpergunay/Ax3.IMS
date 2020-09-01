import Proxy from './Proxy';

class DashboardProxy extends Proxy {
  constructor() {
    const token = localStorage.getItem('token');
    const headers = token ? { 'Authorization': `Bearer ${token}` } : {};
    super(process.env.REACT_APP_API_URL, headers);
  };

  onError = (error) => {
    if (error && error.response.status === 401) {
      localStorage.removeItem('token');
      const url = encodeURIComponent(window.location.pathname);
      window.location.replace(`/login?redirect=${url}`);
    }
  };
};

export default new DashboardProxy();