export default {
  name: 'dashboard',
  component: require('layouts/Dashboard').default,
  routes: [
    {
      path: '/home',
      name: 'home',
      icon: require('@ant-design/icons/PieChartOutlined').default,
      component: require('views/Dashboard/Home').default
    },
    {
      path: '/definitions',
      name: 'definitions',
      icon: require('@ant-design/icons/BookOutlined').default,
      routes: [
        {
          path: '/store-types',
          name: 'storeTypes',
          component: require('views/Dashboard/Definitions/StoreTypes').default
        },
        {
          path: '/investment-tool-types',
          name: 'investmentToolTypes',
          component: require('views/Dashboard/Definitions/InvestmentToolTypes').default
        }
      ]
    }
  ]
};