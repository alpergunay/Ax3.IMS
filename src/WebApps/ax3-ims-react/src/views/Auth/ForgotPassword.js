import React from 'react';
import { Form, Input, Button } from 'antd';
import { useTranslation } from 'react-i18next';
import { forgotPassword } from 'store/requests/auth';
import { Link } from 'react-router-dom';

export default () => {
  const [form] = Form.useForm();
  const { t } = useTranslation(['common', 'auth']);

  const onFinish = (values) => {
    forgotPassword(values).then(() => {

    });
  };

  return (
    <Form layout="vertical" form={form} onFinish={onFinish}>
      <Form.Item label={t('email')} name="email" rules={[{ required: true }, { type: 'email' }]}>
        <Input placeholder={t('email')} />
      </Form.Item>
      <Form.Item>
        <Button block type="primary" htmlType="submit">
          {t('auth:resetPassword')}
        </Button>
      </Form.Item>
      <div className="text-center">
        <Link to="/login">
          {t('auth:goBackToLogin')}
        </Link>
      </div>
    </Form>
  )
};