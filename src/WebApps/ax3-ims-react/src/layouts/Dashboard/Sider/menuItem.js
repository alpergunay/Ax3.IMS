import React from 'react';
import { Menu } from 'antd';
import { useTranslation } from 'react-i18next';
import { Link } from 'react-router-dom';

export default (name = '', path = '', item) => {
  const { t } = useTranslation(['routes']);

  return (
    <Menu.Item key={`${path}${item.path}`} icon={item.icon ? <item.icon /> : null}>
      <Link to={`${path}${item.path}`}>
        {t(`${name}${item.name}`)}
      </Link>
    </Menu.Item>
  );
};