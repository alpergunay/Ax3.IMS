import React, { useState } from 'react';
import { useTranslation } from 'react-i18next';
import { get } from 'lodash';
import { useGet } from 'hooks';
import Table from './Table';
import Alert from './Alert';
import CreateButton from './CreateButton';

export default ({ url, key, rowKey = 'id', columns = [], addKey = '', addUrl = '' }) => {
  const { t } = useTranslation();
  const [params, setParams] = useState({ page: 1, per_page: 25 });
  const { data, loading, refresh } = useGet({ url, key, params });
  const pagination = {
    pageSize: get(data, 'meta.per_page', 25),
    total: get(data, 'meta.total', 0),
    onChange: (page, per_page) => setParams({ page, per_page }),
  };

  return (
    <div className="DataTable">
      {addUrl &&
        <CreateButton t={t} addKey={addKey} addUrl={addUrl} />
      }
      {data &&
        <Alert t={t} total={pagination.total} />
      }
      <Table
        url={url}
        addUrl={addUrl}
        data={data}
        columns={columns}
        loading={loading}
        rowKey={rowKey}
        refresh={refresh}
        pagination={pagination}
        t={t}
      />
    </div>
  )
};