import React from 'react';
import { get } from 'lodash';
import { Table } from 'antd';
import Actions from './Actions';
import { deleteData } from 'store/requests/global';

export default ({ url, addUrl, data, columns, loading, rowKey, refresh, pagination, t }) => {

  const onDelete = (id) => {
    deleteData({ url: `${url}/${id}` }).then(() => {
      refresh();
    });
  };

  return (
    <Table dataSource={get(data, 'data', [])} loading={loading} rowKey={rowKey} pagination={pagination}>
      {columns.map(x => (
        <Table.Column
          align={x.align || 'left'}
          dataIndex={x.key}
          key={x.key}
          render={x.render}
          title={x.title}
        />
      ))}
      <Table.Column width={140} key="actions" render={(a, x) => (
        <Actions item={x} onDelete={onDelete} t={t} url={addUrl} />
      )} />
    </Table>
  );
};