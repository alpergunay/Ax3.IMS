import { useEffect, useState, useCallback } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import actions from 'store/actions/global';

export default ({ url = '', key = '', params = null, options = null, singleLoad = false }) => {
  const dispatch = useDispatch();
  const [loading, setLoading] = useState(false);
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);
  const stateData = key ? useSelector(state => state.global[key]) : null;

  const getData = useCallback(
    async () => {
      if (!singleLoad || (singleLoad && key && !stateData.loading && !stateData.data)) {
        try {
          !key && setLoading(true);
          const response = await dispatch(actions.getData({ url, key, params, options }));
          !key && setLoading(false);
          !key && setData(response);
        } catch (error) {
          !key && setLoading(false);
          !key && setError(error);
        }
      }
    }, [url, key, params, options, singleLoad, dispatch]
  );

  const refresh = () => {
    getData();
  };

  useEffect(() => {
    if (url) getData();
  }, [url, getData]);


  return stateData ? { ...stateData, refresh } : { data, loading, error, refresh };
};