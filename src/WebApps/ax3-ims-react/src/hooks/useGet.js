import { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import actions from 'store/actions/global';

export default ({ url = '', key = '', params = null, options = null, loadOnce = false }) => {
  const dispatch = useDispatch();
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const [loaded, setLoaded] = useState(false);
  const stateData = key ? useSelector(state => state.global[key]) : null;

  const getData = async () => {
    if (!(loadOnce && loaded)) {
      try {
        !key && setError(null);
        !key && setLoading(true);
        const response = await dispatch(actions.getData({ url, key, params, options }));
        setLoaded(true);
        !key && setData(response);
        !key && setLoading(false);
      } catch (error) {
        !key && setLoading(false);
        !key && setError(error);
      }
    }
  };

  const refresh = () => {
    getData();
  };

  useEffect(() => {
    if (url) {
      getData();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [url, params, options]);

  return stateData ? { ...stateData, refresh } : { data, loading, error, refresh };
};