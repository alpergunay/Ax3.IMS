import React from 'react';
import { Select } from 'antd';
import { useGet } from 'hooks';

export default React.forwardRef(({ url, key }, ref) => {
  const { data, loading } = useGet({ url, key, loadOnce: true });

  return (
    <Select loading={loading}>
      
    </Select>
  )
});