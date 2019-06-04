import ShopTypeAndShops from '../views/User/Shop/ShopTypeAndShops';
import ShopDetail from '../views/User/Shop/ShopDetail';
import ShopLists from '../views/User/Shop/ShopLists';
import GBProductDetail from '../views/User/Shop/GBProductDetail';
import Redirect from '../views/User/Shop/Redirect';

export default [{
  path: '/Shops',
  component: ShopTypeAndShops
}, {
  path: '/ShopDetail',
  component: ShopDetail
}, {
  path: '/ShopLists',
  component: ShopLists
}, {
  path: '/GBProductDetail',
  component: GBProductDetail
}, {
  path: '/redirect',
  component: Redirect
}]