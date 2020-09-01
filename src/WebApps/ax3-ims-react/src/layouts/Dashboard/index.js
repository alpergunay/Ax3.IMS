import React, { useState } from 'react';
import { Layout } from 'antd';
import { useAccount } from 'hooks';
import { Loading, Breadcrumb } from 'components';
import Header from './Header';
import Sider from './Sider';
import Footer from './Footer';

export default ({ children }) => {
  const loading = useAccount();
  const [collapsed, setCollapsed] = useState(localStorage.getItem('collapsed') === 'true');

  return (
    loading ?
      <Loading />
      :
      <Layout className="DashboardLayout">
        <Layout.Sider width={256} collapsed={collapsed}>
          <Sider collapsed={collapsed} />
        </Layout.Sider>
        <Layout>
          <Layout.Header>
            <Header {...{ collapsed, setCollapsed }} />
          </Layout.Header>
          <Layout.Content>
            <Breadcrumb />
            <div className="Content">
              {children}
            </div>
            <Layout.Footer>
              <Footer />
            </Layout.Footer>
          </Layout.Content>
        </Layout>
      </Layout>
  );
};