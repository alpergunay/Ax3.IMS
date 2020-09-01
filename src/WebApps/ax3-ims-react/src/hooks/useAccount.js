import { useHistory } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { getAccount } from 'store/requests/auth';

export default () => {
  const [loading, setLoading] = useState(true);
  const history = useHistory();

  useEffect(() => {
    const getData = async () => {
      try {
        await getAccount();
        setLoading(false);
      } catch (error) {
        history.push('/login');
      }
    };

    getData();
    
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return loading;
};