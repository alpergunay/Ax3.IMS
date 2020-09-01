import React from 'react';
import { Menu, Dropdown, Button, Modal } from 'antd';
import { EyeOutlined, EditOutlined, DeleteOutlined, DownOutlined } from '@ant-design/icons';
import { useHistory } from 'react-router-dom';

export default ({ item, onDelete, t, url }) => {
  const history = useHistory();

  const onViewClick = () => {

  };

  const onEditClick = () => {
    history.push(`${url}/${item.id}`);
  };

  const onDeleteClick = () => {
    Modal.confirm({
      title: t('areYouSure'),
      onOk: () => onDelete(item.id)
    });
  };

  return (
    <Dropdown overlay={
      <Menu>
        <Menu.Item icon={<EyeOutlined />} onClick={onViewClick}>
          {t('view')}
        </Menu.Item>
        <Menu.Item icon={<EditOutlined />} onClick={onEditClick}>
          {t('edit')}
        </Menu.Item>
        <Menu.Item icon={<DeleteOutlined />} onClick={onDeleteClick}>
          {t('delete')}
        </Menu.Item>
      </Menu>
    }>
      <Button type="link">
        {t('operations')}
        <DownOutlined />
      </Button>
    </Dropdown>
  )
};