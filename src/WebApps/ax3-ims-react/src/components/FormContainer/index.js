import React, { useEffect, useState } from 'react';
import { Form, Spin, Button } from 'antd';
import { useRouteMatch } from 'react-router-dom';
import { getData, postData, putData } from 'store/requests/global';

export default ({ t, form, children, url = '', contentSize = 'md', labelCol = {} }) => {
  const [loading, setLoading] = useState(true);
  const { params } = useRouteMatch();

  useEffect(() => {
    if (params.id) {
      getData({ url: `${url}/${params.id}` }).then(response => {
        form.setFieldsValue(response.data);
        setLoading(false);
      }).catch(() => {
        setLoading(false);
      });
    } else {
      setLoading(false);
    }
  }, [params]);

  const onFinish = (data) => {
    setLoading(true);
    const request = params.id ? putData : postData;
    const payload = { url: `${url}${params.id ? `/${params.id}` : ''}`, data };

    request(payload).then(() => {
      setLoading(false);
    }).catch(() => {
      setLoading(false);
    });
  };

  return (
    <Form form={form} onFinish={onFinish} labelCol={labelCol}>
      <Spin spinning={loading}>
        <div className={`content content-${contentSize}`}>
          {children}
          <Form.Item className="text-right">
            <Button htmlType="submit" type="primary">
              {t('save')}
            </Button>
          </Form.Item>
        </div>
      </Spin>
    </Form>
  )
};