export const DynamicAsideMenuConfig = {
  items: [
    {
      title: 'Dashboard',
      root: true,
      icon: 'flaticon2-architecture-and-city',
      svg: './assets/media/svg/icons/Design/Layers.svg',
      page: '/dashboard',
      bullet: 'dot',
    },
    {
      title: 'Hesap Bilgileri',
      root: true,
      bullet: 'dot',
      page: '/accounts',
      icon: 'flaticon2-browser-2',
      svg: './assets/media/svg/icons/Design/Cap-2.svg',
      submenu: [
        {
          title: 'Hesap Listesi',
          bullet: 'dot',
          page: '/accounts/account'
        },
        {
          title: 'Hesap Hareketleri',
          bullet: 'dot',
          page: '/accounts/transaction',
        }
      ]
    },
    {
      title: 'Yatırım Araçları',
      root: true,
      bullet: 'dot',
      page: '/investment-tools',
      icon: 'flaticon2-digital-marketing',
      svg: './assets/media/svg/icons/Shopping/Bitcoin.svg',
      submenu: [
        {
          title: 'Fiyatlar',
          page: '/investment-tools/investment-tools-price'
        }
      ]
    },
    { section: 'Tanımlamalar' },
    {
      title: 'Hesap Tanımlamaları',
      bullet: 'dot',
      icon: 'flaticon2-list-2',
      svg: './assets/media/svg/icons/Shopping/Cart3.svg',
      root: true,
      page: '/account-definitions',
      submenu: [
        {
          title: 'Hesap Türleri',
          page: '/account-definitions/account-types'
        },
        {
          title: 'Hareket Türleri',
          page: '/account-definitions/transaction-types'
        }
      ]
    },
    {
      title: 'Yatırım Aracı Tanımlamaları',
      root: true,
      bullet: 'dot',
      icon: 'flaticon2-user-outline-symbol',
      svg: './assets/media/svg/icons/General/User.svg',
      page: '/investment-tool-definitions',
      submenu: [
        {
          title: 'Yatırım Aracı Tipi',
          page: '/investment-tool-definitions/investment-tool-types'
        },
        {
          title: 'Yatırım Araçları',
          page: '/investment-tool-definitions/investment-tools'
        }
      ]
    },
    {
      title: 'Saklama Yeri Tanımlamaları',
      root: true,
      bullet: 'dot',
      icon: 'flaticon2-list-2',
      svg: './assets/media/svg/icons/Code/Warning-2.svg',
      page: '/store-definitions',
      submenu: [
        {
          title: 'Saklama Yeri Tipi',
          page: '/store-definitions/store-types'
        },
        {
          title: 'Saklama Yerleri',
          bullet: 'dot',
          page: '/store-definitions/stores',
        },
        {
          title: 'Saklama Yeri Şubeleri',
          page: '/store-definitions/store-branches'
        }
      ]
    }
  ]
};
