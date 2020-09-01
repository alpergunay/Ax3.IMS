import React from 'react';
import { Form, Input, Button } from 'antd';
import { useTranslation } from 'react-i18next';
import { register } from 'store/requests/auth';
import { Link } from 'react-router-dom';

export default () => {
  const [form] = Form.useForm();
  const { t } = useTranslation(['common', 'auth']);

  const onFinish = (values) => {
    register(values);
  };

  return (
    <Form layout="vertical" form={form} onFinish={onFinish}>
      <Form.Item label={t('email')} name="email" rules={[{ required: true }, { type: 'email' }]}>
        <Input placeholder={t('email')} />
      </Form.Item>
      <Form.Item label={t('password')} name="password" rules={[{ required: true }]}>
        <Input.Password placeholder={t('password')} />
      </Form.Item>
      <Form.Item label={t('confirmPassword')} name="confirm" rules={[{ required: true }]}>
        <Input.Password placeholder={t('password')} />
      </Form.Item>
      <Form.Item>
        <Button block type="primary" htmlType="submit">
          {t('auth:register')}
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